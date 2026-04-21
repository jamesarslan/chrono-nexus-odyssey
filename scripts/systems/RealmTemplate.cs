using Godot;

namespace ChronoNexusOdyssey.Systems;

/// <summary>
/// Base class for all Nexus Realm scenes. Enforces the standard node hierarchy
/// and provides shared realm functionality (anchor management, enemy spawning,
/// collectible tracking, portal transitions).
///
/// REQUIRED NODE HIERARCHY (design language):
///
/// RealmRoot (Node3D) — script inherits RealmTemplate
/// ├── WorldEnvironment
/// ├── SunLight (DirectionalLight3D)
/// ├── AmbientFill (OmniLight3D)
/// ├── Terrain (StaticBody3D)
/// │   ├── TerrainMesh (MeshInstance3D)
/// │   └── TerrainCollision (CollisionShape3D)
/// ├── PlayerZone (Node3D)
/// │   └── PlayerSpawn (Marker3D)
/// ├── EnemySpawns (Node3D)
/// │   └── EnemySpawn_* (Marker3D) — one per spawn point
/// ├── Interactables (Node3D)
/// │   ├── AnchorNode_* (Area3D) — checkpoint, script: AnchorNode.cs
/// │   ├── ForgeNexus (Area3D) — optional, hub only
/// │   └── Collectible_* (Area3D) — pickups
/// ├── Portals (Node3D)
/// │   └── NexusRift_* (Area3D) — script: NexusRiftPortal.cs
/// ├── LightingMood (Node3D) — realm-specific accent lights
/// └── HUD (CanvasLayer)
///     ├── HealthBar (ProgressBar)
///     ├── ChronosBar (ProgressBar)
///     ├── NexusEnergyLabel (Label)
///     └── RealmName (Label)
/// </summary>
public partial class RealmTemplate : Node3D
{
	[Export] public string RealmName = "Unknown Realm";
	[Export] public string RealmEra = "Unknown Era";
	[Export] public int RequiredShardsToUnlock = 3;

	protected int ShardsCollected;
	protected Node3D PlayerInstance;

	public override void _Ready()
	{
		var realmLabel = GetNodeOrNull<Label>("HUD/RealmName");
		if (realmLabel != null)
			realmLabel.Text = $"{RealmName} - {RealmEra}";

		SpawnPlayer();
		ConnectCollectibles();
	}

	protected virtual void SpawnPlayer()
	{
		var spawnPoint = GetNodeOrNull<Marker3D>("PlayerZone/PlayerSpawn");
		if (spawnPoint == null) return;

		var playerScene = GD.Load<PackedScene>("res://scenes/player/Player.tscn");
		if (playerScene == null) return;

		PlayerInstance = playerScene.Instantiate<Node3D>();
		PlayerInstance.GlobalPosition = spawnPoint.GlobalPosition;
		AddChild(PlayerInstance);
	}

	protected virtual void ConnectCollectibles()
	{
		var interactables = GetNodeOrNull<Node3D>("Interactables");
		if (interactables == null) return;

		foreach (var child in interactables.GetChildren())
		{
			if (child is Area3D area && child.Name.ToString().StartsWith("Collectible_"))
				area.BodyEntered += (body) => OnCollectiblePickup(area, body);
		}
	}

	protected virtual void OnCollectiblePickup(Area3D collectible, Node3D body)
	{
		if (body is not Player.PlayerController) return;

		ShardsCollected++;
		GameManager.Instance.NexusEnergy += 10;
		collectible.QueueFree();

		if (ShardsCollected >= RequiredShardsToUnlock)
			OnAllShardsCollected();
	}

	protected virtual void OnAllShardsCollected()
	{
		var portals = GetNodeOrNull<Node3D>("Portals");
		if (portals == null) return;

		foreach (var child in portals.GetChildren())
		{
			if (child is Area3D portal)
				portal.Monitoring = true;
		}
	}
}

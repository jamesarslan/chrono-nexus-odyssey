using Godot;

namespace ChronoNexusOdyssey.Systems;

public partial class NexusRiftPortal : Area3D
{
	[Export] public string TargetScene = "";
	[Export] public string RealmName = "Unknown Realm";

	private bool _playerInRange;

	public override void _Ready()
	{
		BodyEntered += OnBodyEntered;
		BodyExited += OnBodyExited;
	}

	public override void _Process(double delta)
	{
		if (_playerInRange && Input.IsActionJustPressed("interact"))
		{
			if (!string.IsNullOrEmpty(TargetScene))
				GameManager.Instance.LoadScene(TargetScene);
		}
	}

	private void OnBodyEntered(Node3D body)
	{
		if (body is Player.PlayerController)
		{
			_playerInRange = true;
			var prompt = GetNodeOrNull<Label3D>("PortalPrompt") ?? GetNodeOrNull<Label3D>("ReturnPrompt");
			if (prompt != null) prompt.Visible = true;
		}
	}

	private void OnBodyExited(Node3D body)
	{
		if (body is Player.PlayerController)
		{
			_playerInRange = false;
			var prompt = GetNodeOrNull<Label3D>("PortalPrompt") ?? GetNodeOrNull<Label3D>("ReturnPrompt");
			if (prompt != null) prompt.Visible = false;
		}
	}
}

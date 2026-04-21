using Godot;

namespace ChronoNexusOdyssey.Systems;

public partial class AnchorNode : Area3D
{
	[Export] public bool IsActivated;

	private bool _playerInRange;

	public override void _Ready()
	{
		BodyEntered += OnBodyEntered;
		BodyExited += OnBodyExited;
	}

	public override void _Process(double delta)
	{
		if (_playerInRange && Input.IsActionJustPressed("interact") && !IsActivated)
			Activate();
	}

	private void Activate()
	{
		IsActivated = true;
		var prompt = GetNodeOrNull<Label3D>("AnchorPrompt") ?? GetNodeOrNull<Label3D>("AnchorPrompt1") ?? GetNodeOrNull<Label3D>("AnchorPrompt2");
		if (prompt != null)
			prompt.Text = "Anchored - Rest Point";

		var player = GetTree().GetFirstNodeInGroup("player") as Player.PlayerController;
		if (player != null)
		{
			player.Health = player.MaxHealth;
			player.ChronosStamina = player.MaxChronosStamina;
		}
	}

	private void OnBodyEntered(Node3D body)
	{
		if (body is Player.PlayerController)
		{
			_playerInRange = true;
			var prompt = GetNodeOrNull<Label3D>("AnchorPrompt") ?? GetNodeOrNull<Label3D>("AnchorPrompt1") ?? GetNodeOrNull<Label3D>("AnchorPrompt2");
			if (prompt != null) prompt.Visible = true;
		}
	}

	private void OnBodyExited(Node3D body)
	{
		if (body is Player.PlayerController)
		{
			_playerInRange = false;
			var prompt = GetNodeOrNull<Label3D>("AnchorPrompt") ?? GetNodeOrNull<Label3D>("AnchorPrompt1") ?? GetNodeOrNull<Label3D>("AnchorPrompt2");
			if (prompt != null) prompt.Visible = false;
		}
	}
}

using Godot;

namespace ChronoNexusOdyssey.Player;

public partial class PlayerController : CharacterBody3D
{
	[Export] public float MoveSpeed = 5.0f;
	[Export] public float SprintSpeed = 8.0f;
	[Export] public float JumpVelocity = 4.5f;
	[Export] public float MouseSensitivity = 0.002f;
	[Export] public float Gravity = 12.0f;

	private Node3D _cameraPivot;
	private Camera3D _camera;
	private AnimationPlayer _animPlayer;
	private bool _isSprinting;

	public int Health { get; set; } = 100;
	public int MaxHealth { get; set; } = 100;
	public float ChronosStamina { get; set; } = 100f;
	public float MaxChronosStamina { get; set; } = 100f;

	public override void _Ready()
	{
		_cameraPivot = GetNode<Node3D>("CameraPivot");
		_camera = GetNode<Camera3D>("CameraPivot/Camera3D");
		Input.MouseMode = Input.MouseModeEnum.Captured;
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventMouseMotion mouseMotion)
		{
			RotateY(-mouseMotion.Relative.X * MouseSensitivity);
			_cameraPivot.RotateX(-mouseMotion.Relative.Y * MouseSensitivity);

			var pivotRotation = _cameraPivot.Rotation;
			pivotRotation.X = Mathf.Clamp(pivotRotation.X, Mathf.DegToRad(-80), Mathf.DegToRad(60));
			_cameraPivot.Rotation = pivotRotation;
		}

		if (@event.IsActionPressed("pause_menu"))
			Input.MouseMode = Input.MouseMode == Input.MouseModeEnum.Captured
				? Input.MouseModeEnum.Visible
				: Input.MouseModeEnum.Captured;
	}

	public override void _PhysicsProcess(double delta)
	{
		var velocity = Velocity;

		if (!IsOnFloor())
			velocity.Y -= Gravity * (float)delta;

		if (Input.IsActionJustPressed("dodge") && IsOnFloor())
			velocity.Y = JumpVelocity;

		var inputDir = Input.GetVector("move_left", "move_right", "move_forward", "move_backward");
		var direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();

		var speed = _isSprinting ? SprintSpeed : MoveSpeed;
		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * speed;
			velocity.Z = direction.Z * speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(velocity.X, 0, speed);
			velocity.Z = Mathf.MoveToward(velocity.Z, 0, speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	public void TakeDamage(int amount)
	{
		Health -= amount;
		if (Health <= 0)
			OnDeath();
	}

	private void OnDeath()
	{
		Health = MaxHealth;
		var gm = Systems.GameManager.Instance;
		var energyLost = gm.NexusEnergy / 3;
		gm.NexusEnergy -= energyLost;
	}
}

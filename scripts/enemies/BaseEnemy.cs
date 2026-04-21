using Godot;

namespace ChronoNexusOdyssey.Enemies;

public partial class BaseEnemy : CharacterBody3D
{
	[Export] public int MaxHealth = 50;
	[Export] public float MoveSpeed = 3.0f;
	[Export] public int AttackDamage = 10;
	[Export] public float DetectionRange = 15.0f;
	[Export] public float AttackRange = 2.0f;
	[Export] public int NexusEnergyDrop = 20;

	public int Health { get; set; }

	public enum State { Idle, Patrol, Chase, Attack, Staggered, Dead }
	public State CurrentState { get; set; } = State.Idle;

	private Node3D _target;

	public override void _Ready()
	{
		Health = MaxHealth;
	}

	public override void _PhysicsProcess(double delta)
	{
		if (CurrentState == State.Dead) return;

		var player = GetTree().GetFirstNodeInGroup("player") as Node3D;
		if (player == null) return;

		var distance = GlobalPosition.DistanceTo(player.GlobalPosition);

		if (distance <= AttackRange)
			CurrentState = State.Attack;
		else if (distance <= DetectionRange)
			CurrentState = State.Chase;
		else
			CurrentState = State.Idle;

		switch (CurrentState)
		{
			case State.Chase:
				var direction = (player.GlobalPosition - GlobalPosition).Normalized();
				Velocity = new Vector3(direction.X * MoveSpeed, Velocity.Y - 9.8f * (float)delta, direction.Z * MoveSpeed);
				MoveAndSlide();
				LookAt(new Vector3(player.GlobalPosition.X, GlobalPosition.Y, player.GlobalPosition.Z));
				break;
		}
	}

	public void TakeDamage(int amount)
	{
		Health -= amount;
		if (Health <= 0)
			Die();
		else
			CurrentState = State.Staggered;
	}

	private void Die()
	{
		CurrentState = State.Dead;
		Systems.GameManager.Instance.NexusEnergy += NexusEnergyDrop;
		QueueFree();
	}
}

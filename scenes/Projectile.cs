using Godot;

public partial class Projectile : CharacterBody2D
{
	[Export] public float Speed = 200f; // Speed of the projectile
	private Vector2 _velocity;

	public void Shoot(Vector2 direction)
	{
		_velocity = direction.Normalized() * Speed;
		this.Rotation = _velocity.Angle() + Mathf.Pi/2;
		GD.Print("Velocity: " + _velocity);
	}

	public override void _PhysicsProcess(double delta)
	{
		KinematicCollision2D collision = MoveAndCollide(_velocity * (float)delta);

		if (collision != null)
		{
			HandleCollision(collision);
		}
	}

	private void HandleCollision(KinematicCollision2D collision)
	{
		Node2D hitObject = (Node2D)collision.GetCollider();

		if (hitObject is Enemy enemy)
		{
			enemy.TakeDamage(5, _velocity); 
		}

		QueueFree(); // Destroy the projectile on collision
	}
}

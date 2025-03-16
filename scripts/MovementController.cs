using Godot;
using System;
using System.IO;

public partial class MovementController : BaseMovementController
{
	
	Vector2 acceleration;

	float maxForce = 0.2f;
	float mass = 1;

	[Export] Node2D target;


	public void seekTarget()
	{
		Vector2 desiredDir = target.GlobalPosition - GetParent<Node2D>().GlobalPosition;
		desiredDir = desiredDir.Normalized()*maxSpeed;
		Vector2 steeringForce = desiredDir - this.velocity;
		steeringForce.LimitLength(maxForce);
		ControlledCharacter.Velocity = addForce(steeringForce);
	}


	public Vector2 addForce(Vector2 force)
	{
		acceleration = mass * force;
		velocity += acceleration;
		return velocity;
	}

	public override void _Ready()
	{
		animationBaseString = "Zombie";
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(target != null)
		seekTarget();
		base._Process(delta);
	}
}

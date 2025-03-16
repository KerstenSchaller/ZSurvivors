using System;
using Godot;

public partial class MovementControllerWASD : BaseMovementController
{
	


	public override void _Process(double delta)
	{


		
		Vector2 tempVelocity = new Vector2();
		if (Input.IsKeyPressed(Key.W)) 
		{
			tempVelocity.Y -= 1;
		}
		if (Input.IsKeyPressed(Key.S)) 
		{
			tempVelocity.Y += 1;
		}
		if (Input.IsKeyPressed(Key.A)) 
		{
			tempVelocity.X -= 1;
		}
		if (Input.IsKeyPressed(Key.D)) 
		{
			tempVelocity.X += 1;
		}

		velocity = tempVelocity.Normalized() * maxSpeed;
		ControlledCharacter.Velocity = velocity;
		ControlledCharacter.MoveAndSlide();

		base._Process(delta);
		

		
	
	}
}

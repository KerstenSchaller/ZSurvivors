using Godot;
using Microsoft.VisualBasic.FileIO;
using System;

[Tool]
public partial class BloodSplatter : CpuParticles2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Lifetime = 1;
		DampingMin = 300;
		DampingMax = 300;
		Amount = 100;

		InitialVelocityMin = 0;
		InitialVelocityMax = 50;
		LifetimeRandomness = 0.24;
		Randomness = 0.12f;
		Explosiveness = 0.9f;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	// This is the function that gets called when the particles finish
	public  void on_finished()
	{
		QueueFree();
		// Add any additional code to run after the particles finish
	}

	public void splatter(Vector2 velocity)
	{
		InitialVelocityMin = velocity.Length();
		InitialVelocityMax = velocity.Length();
		Direction = velocity.Normalized();

		
		if(velocity.Y >= 0)
		{
			ZAsRelative = true; // draw in front of parent
		}
		else
		{
			ZAsRelative = false; // draw behind parent
		}

		Emitting = true;
	}
}

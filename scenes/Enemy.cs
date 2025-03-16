using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
	CpuParticles2D cpuParticles2D;
	[Export]public PackedScene ParticleScene;

	float hitpoints = 100;
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		if(hitpoints <= 0)
		{
			QueueFree();
		}
		MoveAndSlide();
	}

	public void TakeDamage(float damage, Vector2 direction)
	{
		hitpoints -= damage;
		BloodSplatter splatterParticles = (BloodSplatter)ParticleScene.Instantiate();
		AddChild(splatterParticles);
		splatterParticles.splatter(direction);
	}
}

using Godot;
using System;

public partial class Weapon : Node2D
{
	[Export] public PackedScene ProjectileScene; // Assign your projectile scene in the inspector

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)
		{
			Shoot();
		}
	}

	private void Shoot()
	{
		if (ProjectileScene == null)
		{
			GD.PrintErr("Projectile scene is not assigned!");
			return;
		}

		// Get mouse position in world space
		Vector2 mousePosition = GetGlobalMousePosition();
		
		// Calculate direction from weapon to mouse
		Vector2 direction = (mousePosition - GlobalPosition).Normalized();

		// Spawn projectile
		Projectile projectile = (Projectile)ProjectileScene.Instantiate();
		GetTree().Root.AddChild(projectile);

		// Set projectile position and shoot
		projectile.GlobalPosition = GlobalPosition;
		projectile.Shoot(direction);
	}
}

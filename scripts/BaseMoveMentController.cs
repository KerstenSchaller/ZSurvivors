using System;
using System.Runtime.CompilerServices;
using ExtensionMethods;
using Godot;

public partial class BaseMovementController : Node
{
	[Export] public CharacterBody2D ControlledCharacter;
	[Export] public AnimatedSprite2D CharacterSprite;
	[Export] public float maxSpeed = 100f;

    protected Vector2 velocity = Vector2.Zero;

	[Export] protected string animationBaseString = "Blue";


	public override void _Process(double delta)
	{
		if (ControlledCharacter == null || CharacterSprite == null)
			return;

		string animationString = animationBaseString + "Walk_";
		
        string animationExtension = "";
		animationExtension = velocity.ClassifyDirection();
		
		if (velocity != Vector2.Zero)
		{
			CharacterSprite.Play(animationString+animationExtension);
		}
		else
		{
			CharacterSprite.Frame = 1;
			CharacterSprite.Pause();
		}
	}
}

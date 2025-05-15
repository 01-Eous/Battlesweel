using Godot;
using System;

public partial class NormalSweel : RigidBody2D
{
	[Export]
	float speedDeltaPerSecond;

	bool isPreparing,inShape;
	
	public override void _Ready()
	{
		isPreparing = false;
		InputPickable = true;
		Vector2 initialPos;
		initialPos.X = 300;
		initialPos.Y = 300;
		Position = initialPos;
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("mouse_left_down"))
		{
			if (inShape)
				isPreparing = true;
		}
		if (Input.IsActionJustReleased("mouse_left_down"))
		{
			if (isPreparing)
			{
				Vector2 nowVelocity = Position - GetGlobalMousePosition();
				LinearVelocity = (float)2.0 * nowVelocity;
				isPreparing = false;
			}
		}
		if (LinearVelocity.Length() > 0)
			SlowDown(delta);
	}

	public void GoInShape()// 准备射击
	{
		inShape = true;
	}
	public void GoOutShape()
	{
		inShape = false;
	}
	private void SlowDown(double delta)
	{
		
	}
}

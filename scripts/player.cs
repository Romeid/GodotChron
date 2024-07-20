using Godot;
using System;

public partial class player : CharacterBody2D
{
	private AnimatedSprite2D _animatedSprite;
	private Marker2D _directionFacing;

	private Area2D _actionableFinder;

	public const float Speed = 250.0f;
	public Vector2 _inputVector;

	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_directionFacing = GetNode<Marker2D>("Direction");
		_actionableFinder = GetNode<Area2D>("Direction/ActionableFinder");
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		HandleMovement();

		if (Input.IsActionJustPressed("interact"))
		{
			var actionables = _actionableFinder.GetOverlappingAreas();
			if (actionables.Count > 0){
				((actionable)actionables[0]).Action();
			}
			// var node = GetTree().Root.GetNode("game").GetNode("castani");
			// if (node != null)
			// {
			// 	node.QueueFree();
			// }
		}
	}

	public void HandleMovement()
	{
		float xdirection = Input.GetAxis("left", "right");
		float ydirection = Input.GetAxis("up", "down");

		if (xdirection != 0)
		{
			_inputVector = xdirection * Vector2.Right;
			if (xdirection < 0)
			{
				_animatedSprite.Play("move_left");
				_directionFacing.RotationDegrees = 90f;
			}
			else if (xdirection > 0)
			{
				_animatedSprite.Play("move_right");
				_directionFacing.RotationDegrees = 270f;
			}
		}
		else if (ydirection != 0)
		{
			_inputVector = ydirection * Vector2.Down;
			if (ydirection > 0)
			{
				_animatedSprite.Play("move_down");
				_directionFacing.RotationDegrees = 0;
			}
			else if (ydirection < 0)
			{
				_animatedSprite.Play("move_up");
				_directionFacing.RotationDegrees = 180f;
			}
		}
		else
		{
			_inputVector = Vector2.Zero;
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		//var velocity = Input.GetVector("left", "right", "up", "down");
		Velocity = _inputVector * Speed;
		MoveAndSlide();
	}
}

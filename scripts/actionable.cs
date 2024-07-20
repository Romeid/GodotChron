using Godot;
using System;
using DialogueManagerRuntime;

public partial class actionable : Area2D
{
	[Export]
	private Resource dialogue_resource;
	[Export]
	private string dialogue_start;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//dialogue_resource = GD.Load<Resource>("res://example.dialogue");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public void Action(){
		DialogueManager.ShowExampleDialogueBalloon(dialogue_resource, dialogue_start);
	}

}

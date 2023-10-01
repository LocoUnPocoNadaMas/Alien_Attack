using Godot;

namespace AlienAttack.scripts;

public partial class Rocket : Area2D
{
	[ExportGroup("My Properties")]
	[Export]
	private float _speed = 5f;
	
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _PhysicsProcess(double delta)
	{
		//base._PhysicsProcess(delta);
		var global = GlobalPosition;
		global.X += _speed;
		GlobalPosition = global;
	}
}
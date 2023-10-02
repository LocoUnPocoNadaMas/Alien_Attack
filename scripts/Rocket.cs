using Godot;

namespace AlienAttack.scripts;

public partial class Rocket : Area2D
{
	[ExportGroup("My Properties")]
	[Export] private float _speed = 300f;

	private VisibleOnScreenNotifier2D _visibleNotifier;
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//_visibleNotifier = GetNode<VisibleOnScreenNotifier2D>("VisibleOnScreenNotifier2D");
		//_visibleNotifier.Connect("screen_exited", this, nameof(OnScreenExited));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _PhysicsProcess(double delta)
	{
		var global = GlobalPosition;
		global.X += _speed * (float)delta;
		GlobalPosition = global;
	}

	private void OnScreenExited()
	{
		QueueFree();
	}

	private void OnAreaEntered(Area2D area2D)
	{
		//area2D.QueueFree();
		if (area2D is not Enemy areaInstance) return;
		QueueFree();
		areaInstance.Die();
	}
	
}
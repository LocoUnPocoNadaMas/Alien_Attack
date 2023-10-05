using Godot;

namespace AlienAttack.scripts;

public partial class PathEnemy : Path2D
{
	private PathFollow2D _pathFollow2D;

	private Enemy _enemy;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_pathFollow2D = GetNode<PathFollow2D>("PathFollow2D");
		_enemy = GetNode<Enemy>("PathFollow2D/Enemy");
		_pathFollow2D.ProgressRatio = 1;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_pathFollow2D.ProgressRatio -= 0.25f * (float)delta;
		if(_pathFollow2D.ProgressRatio <= 0)
			QueueFree();
	}
	
	
	
}
using Godot;
using Godot.Collections;

namespace AlienAttack.scripts;

public partial class EnemySpawner : Node2D
{
	[Export] private Node2D _containerSpawnPos;
	[Export] private PackedScene _enemyScene;
	[Export] private PackedScene _pathScene;

	private Array<Node> _positionsArray;

	[Signal] public delegate void EnemySpawnedEventHandler(Enemy enemy);

	[Signal]
	public delegate void PathEnemyEventHandler(PathEnemy pathEnemy);
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_containerSpawnPos = GetNode<Node2D>("SpawnPositions");
		_enemyScene = ResourceLoader.Load<PackedScene>("res://prefabs/enemy.tscn");
		_positionsArray = _containerSpawnPos.GetChildren();
		_pathScene = ResourceLoader.Load<PackedScene>("res://prefabs/path_enemy.tscn");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnEnemyTimerTimeout()
	{
		SpawnEnemy();
	}

	private void SpawnEnemy()
	{
		var randomSpawn = _positionsArray.PickRandom() as Marker2D;
		
		var enemyInstance = _enemyScene.Instantiate<Enemy>();
        
		enemyInstance.GlobalPosition = randomSpawn!.GlobalPosition;
		
		EmitSignal(SignalName.EnemySpawned, enemyInstance);
		//AddChild(enemyInstance);
	}

	private void OnPathTimerTimeout()
	{
		SpawnPathEnemy();
	}

	private void SpawnPathEnemy()
	{
		var pathInstance = _pathScene.Instantiate<PathEnemy>();
		
		EmitSignal(SignalName.PathEnemy, pathInstance);
	}
}
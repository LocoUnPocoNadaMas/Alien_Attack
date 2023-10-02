using Godot;
using Godot.Collections;

namespace AlienAttack.scripts;

public partial class EnemySpawner : Node2D
{
	[Export] private Node _containerSpawnPos;
	[Export] private PackedScene _enemyScene;

	private Array<Node> _positionsArray;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_containerSpawnPos = GetNode<Node>("SpawnPositions");
		_enemyScene = ResourceLoader.Load<PackedScene>("res://prefabs/enemy.tscn");
		_positionsArray = _containerSpawnPos.GetChildren();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnTimerTimeout()
	{
		SpawnEnemy();
	}

	private void SpawnEnemy()
	{
		var randomSpawn = _positionsArray.PickRandom() as Marker2D;
		
		var enemyInstance = _enemyScene.Instantiate<Area2D>();
        
		enemyInstance.GlobalPosition = randomSpawn!.GlobalPosition;
		AddChild(enemyInstance);
	}
}
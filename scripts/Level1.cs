using Godot;

namespace AlienAttack.scripts;

public partial class Level1 : Node2D
{
	[Export] private int _lives = 3;
	private Player _player;
	private int _score = 0;

	//private EnemySpawner _enemySpawner;

	private Hud _hud; 

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_player = GetNode<Player>("Player");
		_player.TookDamage += OnPlayerTookDamage;

		//_enemySpawner = GetNode<EnemySpawner>("EnemySpawner");
		//_enemySpawner.EnemySpawned += OnEnemySpawnerEnemySpawned;

		_hud = GetNode<Hud>("UI/HUD");
		_hud.SetScoreLabel(_score);
		_hud.SetLivesLabel(_lives);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnDeathZoneAreaEntered(Area2D area2D)
	{
		if (area2D is not Enemy areaInstance) return;
		areaInstance.Die();
	}

	private void OnPlayerTookDamage()
	{
		_lives -= 1;
		if (_lives == 0)
		{
			GD.Print("Game Over");
			_player.Die();
		}
		_hud.SetLivesLabel(_lives);
	}

	private void OnEnemySpawnerEnemySpawned(Enemy enemy)
	{
		enemy.Died += OnEnemyDied;
		AddChild(enemy);
	}

	private void OnEnemyDied()
	{
		//GD.Print(_score += 100);
		_score += 100;
		_hud.SetScoreLabel(_score);
	}

}
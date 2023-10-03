using Godot;

namespace AlienAttack.scripts;

public partial class Level1 : Node2D
{
	[Export] private int _lives = 3;
	private Player _player;
	private int _score = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_player = GetNode<Player>("Player");
		_player.TookDamage += OnPlayerTookDamage;
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
			_player.Die();
			GD.Print("remaining lives: "+_lives);
		}
		else
			GD.Print("Game Over");
	}
	
	
}
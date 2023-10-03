using Godot;

namespace AlienAttack.scripts;

public partial class Hud : Control
{
	private Label _lblScore;
	private Label _lblLives;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_lblScore = GetNode<Label>("Score");
		_lblLives = GetNode<Label>("Node2D/Lives");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void SetScoreLabel(int score)
	{
		_lblScore.Text = "Score: " + score;
	}

	public void SetLivesLabel(int lives)
	{
		_lblLives.Text = lives.ToString();
	}
}
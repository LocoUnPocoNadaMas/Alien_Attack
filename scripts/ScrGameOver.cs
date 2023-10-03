using Godot;

namespace AlienAttack.scripts;

public partial class ScrGameOver : Control
{
	private Label _score;

	[Signal]
	public delegate void BtnRetryPressedEventHandler();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_score = GetNode<Label>("Panel/lblScore");
		_score.Text = "";
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void SetScoreLabel(int score)
	{
		_score.Text = "Score: " + score;
	}

	public void OnBtnRetryPressed()
	{
		EmitSignal(SignalName.BtnRetryPressed);
		GetTree().ReloadCurrentScene();
	}
}
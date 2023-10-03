using Godot;

namespace AlienAttack.scripts;

public partial class Enemy : Area2D
{
    [ExportGroup("My Properties")] [Export]
    private float _speed = 200f;
    
    [Signal] public delegate void DiedEventHandler();

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
        var global = GlobalPosition;
        global.X -= _speed * (float)delta;
        GlobalPosition = global;
    }

    public void Die()
    {
        EmitSignal(SignalName.Died);
        QueueFree();
    }

    private void OnBodyEntered(Node2D body)
    {
        if (body is not Player bodyInstance) return;
        bodyInstance.TakeDamage();
        Die();
    }
    
}
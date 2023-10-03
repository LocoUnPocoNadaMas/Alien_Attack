using System;
using Godot;

namespace AlienAttack.scripts;

public partial class Player : CharacterBody2D
{
    [Export] private const float Speed = 30000.0f;

    private static readonly Vector2 Min = new Vector2(0,10);
    private static readonly Vector2 Max = new Vector2(1260,710);

    //[Export] private Area2D _rocketScene = new Area2D();
    [Export] private Node _container;
    
    [Export] private PackedScene _rocketScene;
    
    [Signal] public delegate void TookDamageEventHandler();
    
    public override void _Ready()
    {
        try
        {
            _container = GetNode<Node>("RocketContainer");
            _rocketScene = ResourceLoader.Load<PackedScene>("res://prefabs/rocket.tscn");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public override void _Process(double delta)
    {
        if(Input.IsActionJustPressed("ui_select"))
            Shoot();
    }

    public override void _PhysicsProcess(double delta)
    {
        var velocity = Velocity;
        var globalPosition = GlobalPosition;

        // Get the input direction and handle the movement/deceleration.
        // As good practice, you should replace UI actions with custom gameplay actions.
        var direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        if (direction != Vector2.Zero)
        {
            //if(GlobalPosition.X is > 0 and < 1280)
            velocity.X = direction.X * Speed * (float)delta;
            //if(GlobalPosition.Y is > 0 and < 720)
            velocity.Y = direction.Y * Speed * (float)delta;

            /*
        if (GlobalPosition.X < 0)
            globalPosition.X = 0;
        else if(GlobalPosition.X > 1260)
            globalPosition.X = 1260;
        if (GlobalPosition.Y < 10)
            globalPosition.Y = 10;
        else if (GlobalPosition.Y > 710)
            globalPosition.Y = 710;
            */
            //GlobalPosition = globalPosition;
            
            GlobalPosition = globalPosition.Clamp(Min, Max);
        }
        else
        {
            //velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
            //velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
            velocity = new Vector2(0, 0);
            
        }
        Velocity = velocity;
        MoveAndSlide();
        
        /*
    Velocity = new Vector2(0, 0);
    var velocity = Velocity;
    if (Input.IsActionPressed("ui_left"))
        velocity.X = -Speed;
    if (Input.IsActionPressed("ui_right"))
        velocity.X = Speed;
    if (Input.IsActionPressed("ui_up"))
        velocity.Y = -Speed;
    if (Input.IsActionPressed("ui_down"))
        velocity.Y = Speed;
    Velocity = velocity;
    MoveAndSlide();
    */
    }

    private void Shoot()
    {
        if (_rocketScene == null) return;
        //AddChild(_rocketScene);
        var rocketInstance = _rocketScene.Instantiate<Area2D>();
        _container.AddChild(rocketInstance);
        rocketInstance.GlobalPosition = GlobalPosition;
        
        var aux = rocketInstance.GlobalPosition;
        aux.X += 80;
        rocketInstance.GlobalPosition = aux;
    }

    public void TakeDamage()
    {
        EmitSignal(SignalName.TookDamage);
    }

    public void Die()
    {
        QueueFree();
    }
}
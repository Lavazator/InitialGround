using Godot;
using System;

public partial class Hero : CharacterBody2D
{
    [Export] public double gravity = 500;
    [Export] public double speed = 200;

    protected enum HeroState {Idle, Move, Death, Jump, None};
    protected HeroState state = HeroState.None;

    // Node
    protected Sprite2D sprite;
    protected AnimationPlayer animationPlayer;

    public override void _Ready()
    {
        base._Ready();
        sprite = GetNode<Sprite2D>("Sprite");
        animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");

        FloorSnapLength = 32;
        FloorConstantSpeed = true;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        
        if (GetDirection() != 0) {
            sprite.FlipH = !(GetDirection() > 0);
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        
        switch (state) {
            case HeroState.Idle:
                StateIdle(delta);
                break;
            case HeroState.Move:
                StateMove(delta);
                break;
            case HeroState.Jump:
                StateJump(delta);
                break;
            case HeroState.Death:
                StateDeath();
                break;
        }

        if (!IsOnFloor()) {
            ApplyGravity(delta);
        }
    }

    public virtual void StateIdle(double delta) {}
    public virtual void StateMove(double delta) {}
    public virtual void StateJump(double delta) {}
    public virtual void StateDeath() {}

    public float GetDirection() {
        return Input.GetAxis("MoveLeft", "MoveRight");
    }

    protected void ApplyGravity(double delta) {
        Vector2 velocity = Velocity;
        velocity.Y += (float)gravity * (float)delta;

        Velocity = velocity;
        MoveAndSlide();
    }
}
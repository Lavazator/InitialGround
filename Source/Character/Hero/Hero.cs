using Godot;
using System;

public partial class Hero : CharacterBody2D
{
    [Export] private double gravity = 980.0;
    [Export] public double speed = 100;

    protected enum HeroState {Idle, Move, Death, Jump, None};
    private HeroState state = HeroState.None;

    public override void _Ready()
    {
        base._Ready();
        Sprite2D sprite = GetNode<Sprite2D>("Sprite");
        AnimationPlayer animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        switch (state) {
            case HeroState.Idle:
                StateIdle(delta);
                break;
            case HeroState.Move:
                StateIdle(delta);
                break;
            case HeroState.Jump:
                StateIdle(delta);
                break;
            case HeroState.Death:
                StateIdle(delta);
                break;
        }
    }

    public virtual void StateIdle(double delta) {}
    public virtual void StateMove(double delta) {}
    public virtual void StateDeath(double delta) {}
    public virtual void StateJump(double delta) {}
}
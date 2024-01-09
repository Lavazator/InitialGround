using Godot;
using System;

public partial class Hero : CharacterBody2D
{
    [Export] private double gravity = 980.0;
    [Export] public double speed = 50;

    protected enum HeroState {Idle, Move, Death, Jump, None};
    HeroState state = HeroState.None;

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
    }

    public virtual void StateIdle(double delta) {}
    public virtual void StateMove(double delta) {}
    public virtual void StateDeath(double delta) {}
    public virtual void StateJump(double delta) {}
}
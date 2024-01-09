using Godot;
using System;

public partial class Cyborg : Hero
{

    public override void _Ready()
    {
        base._Ready();
        state = HeroState.Idle;
    }

    public override void StateIdle(double delta)
    {
        base.StateIdle(delta);
        animationPlayer.Play("Cyborg/Idle");

        if (GetDirection() != 0) {
            state = HeroState.Move;
        }
    }

    public override void StateMove(double delta)
    {
        base.StateMove(delta);
        Vector2 velocity = Velocity;
        float direction = GetDirection();

        velocity.X = (float) speed * direction;
        animationPlayer.Play("Cyborg/Move");

        if (direction == 0) {
            state = HeroState.Idle;
        }

        MoveAndSlide();
    }
}

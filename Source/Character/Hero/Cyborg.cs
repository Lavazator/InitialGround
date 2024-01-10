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

        if (IsOnFloor() && Input.IsActionJustPressed("Jump")) {
            state = HeroState.Jump;
            Jump();
            animationPlayer.Play("Cyborg/Jump");
        }
    }

    public override void StateMove(double delta)
    {
        base.StateMove(delta);
        Vector2 velocity = Velocity;
        float direction = GetDirection();

        velocity.X = (float) speed * direction;
        Velocity = velocity;

        animationPlayer.Play("Cyborg/Move");

        if (direction == 0) {
            state = HeroState.Idle;
        }

        MoveAndSlide();
    }

    public override void StateJump(double delta)
    {
        base.StateJump(delta);

        if (IsOnFloor()) {
            state = HeroState.Idle;
        }
    }
}

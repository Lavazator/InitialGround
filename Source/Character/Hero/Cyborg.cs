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

        if (direction == 0) {
            state = HeroState.Idle;
            return;
        }

        if (IsOnFloor() && Input.IsActionJustPressed("Jump")) {
            state = HeroState.Jump;
            Jump();
            animationPlayer.Play("Cyborg/Jump");
            return;
        }

        velocity.X = (float) speed * direction;
        Velocity = velocity;

        animationPlayer.Play("Cyborg/Move");

        MoveAndSlide();
    }

    public override void StateJump(double delta)
    {
        base.StateJump(delta);

        Vector2 velocity = Velocity;
        float direction = GetDirection();

        velocity.X = (float)speed * direction;
        Velocity = velocity;

        if (IsOnFloor()) state = HeroState.Idle;
        if (IsOnFloor() && direction != 0) state = HeroState.Move;
    }
}

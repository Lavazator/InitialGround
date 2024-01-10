using Godot;
using System;

public partial class Cyborg : Hero
{

    public override void _Ready()
    {
        base._Ready();
        state = HeroState.Idle;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
    }

    public override void StateIdle(double delta)
    {
        base.StateIdle(delta);
        animationPlayer.Play("Cyborg/Idle");

        if (GetDirection() != 0) {
            state = HeroState.Move;
        }

        if (EnterJump()) {
            StartJump();
        }

        Vector2 velocity = Velocity;
        velocity.Y += (float)gravity * (float)delta;

        Velocity = velocity;
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

        if (EnterJump()) {
            StartJump();
            return;
        }

        if (!IsOnFloor()) {
            state = HeroState.Fall;
            return;
        }

        velocity.X = (float) speed * direction;
        velocity.Y += (float)gravity * (float)delta;

        Velocity = velocity;

        animationPlayer.Play("Cyborg/Move");

        MoveAndSlide();
    }

    public override void StateJump(double delta)
    {
        base.StateJump(delta);
        CheckJumpPeak();

        if (jumpPeak) return;

        Vector2 velocity = Velocity;
        float direction = GetDirection();
        

        velocity.X = (float)speed * direction;
        velocity.Y += (float)gravity * (float)delta;

        Velocity = velocity;
        MoveAndSlide();
    }

    public override void StateFall(double delta)
    {
        base.StateFall(delta);

        Vector2 velocity = Velocity;
        float direction = GetDirection();

        velocity.X = (float)speed * direction;
        velocity.Y += (float)gravity * (float)delta;

        Velocity = velocity;
        MoveAndSlide();

        if (IsOnFloor()) {
            if (direction != 0) {
                state = HeroState.Move;
            } else {
                state = HeroState.Idle;
            }
        }
    }
}

using Godot;
using System;

public partial class DroneTypeA : Enemy
{
    private enum EnemyState {Idle, Move, Death, Attack}
    private EnemyState state;

    // Property
    [Export] private double moveSpeed = 100.0d;
    [Export] private double gravity = 980.0d;
    private double direction = 1.0d;

    public override void _Ready()
    {
        base._Ready();
        state = EnemyState.Move;
    }

    public override void _PhysicsProcess(double delta)
    {
        switch (state) {
            case EnemyState.Idle:
                StateIdle();
                break;
            case EnemyState.Move:
                StateMove(delta);
                break;
        }
    }

    private void StateIdle() {
        PlayAnim("Idle");
    }

    private void StateMove(double delta) {
        Vector2 velocity = Velocity;

        velocity.X = (float)(moveSpeed * direction);
        Velocity = velocity;

        PlayAnim("Move");
        MoveAndSlide();
    }

    private void PlayAnim(string animName) {
        animationPlayer.Play($"DroneTypeA/{animName}");
    }

}

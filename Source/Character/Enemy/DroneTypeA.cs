using Godot;
using System;

public partial class DroneTypeA : Enemy
{
    private enum EnemyState {Idle, Move, Death, Attack}
    private EnemyState state;

    // Property
    [Export] private double moveSpeed = 100.0d;
    [Export] private double gravity = 980.0d;

    public override void _Ready()
    {
        base._Ready();
        state = EnemyState.Idle;
    }

    public override void _PhysicsProcess(double delta)
    {
        switch (state) {
            case EnemyState.Idle:
                StateIdle();
                break;
        }
    }

    private void StateIdle() {
        PlayAnim("Idle");
    }

    private void StateMove(double delta) {
        
    }

    private void PlayAnim(string animName) {
        animationPlayer.Play($"DroneTypeA/{animName}");
    }

}

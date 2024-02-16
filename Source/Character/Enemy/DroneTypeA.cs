using Godot;
using System;

public partial class DroneTypeA : Enemy
{
    private enum EnemyState {Idle, Move, Death, Attack}
    private EnemyState state;

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

    private void PlayAnim(string animName) {
        animationPlayer.Play($"DroneTypeA/{animName}");
    }

}

using System;
using Godot;

public partial class DroneTypeA : Enemy
{
    private enum EnemyState
    {
        Idle,
        Chase,
        Wander,
        Death,
        Attack
    }

    private EnemyState state;

    // Node
    private WanderControllerA wanderController;

    // Property
    [Export]
    private double moveSpeed = 100.0d;

    [Export]
    private double gravity = 980.0d;
    private double direction = 1.0d;

    // Flag
    private bool isHeroDetected = false;
    private Hero heroDetected;
    private Vector2 wanderWaypoint = Vector2.Zero;

    public override void _Ready()
    {
        base._Ready();
        wanderController = GetNode<WanderControllerA>("WanderControllerA");

        wanderController.EnteringWander += OnEnterWander;
        state = EnemyState.Idle;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);

        if (Input.IsActionJustPressed("Interact")) {
            wanderController.StartWander();
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        switch (state)
        {
            case EnemyState.Idle:
                StateIdle();
                break;
            case EnemyState.Chase:
                StateChase(delta);
                break;
            case EnemyState.Wander:
                StateWander(delta);
                break;
        }
    }

    private void StateIdle()
    {
        // Exit to Chase state
        if (isHeroDetected)
        {
            state = EnemyState.Chase;
            return;
        }

        PlayAnim("Idle");
    }

    private void StateChase(double delta)
    {
        Vector2 velocity = Velocity;

        if (heroDetected != null)
            direction = GetHeroDirection(heroDetected.GlobalPosition);

        // Exit to idle state
        if (!isHeroDetected)
        {
            state = EnemyState.Idle;
            return;
        }

        velocity.X = (float)(moveSpeed * direction);
        Velocity = velocity;

        PlayAnim(direction > 0 ? "MoveRight" : "MoveLeft");
        MoveAndSlide();
    }

    private void StateWander(double delta) {
        Vector2 velocity = Velocity;
        const double JITTER_THREESOLD = 10.0;
        double positionDifference = wanderWaypoint.X - GlobalPosition.X;
        double direction = positionDifference > 0 ? 1.0 : -1.0;

        if (Math.Abs(positionDifference) > JITTER_THREESOLD) {
            velocity.X = (float)(moveSpeed * direction);
            Velocity = velocity;

            PlayAnim(direction > 0 ? "MoveRight" : "MoveLeft");
            MoveAndSlide();
        }
        else {
            state = EnemyState.Idle;
            wanderWaypoint = Vector2.Zero;
        }
    }

    private void PlayAnim(string animName)
    {
        animationPlayer.Play($"DroneTypeA/{animName}");
    }

    private double GetHeroDirection(Vector2 HeroPosition)
    {
        double positionDifference = HeroPosition.X - GlobalPosition.X;
        return positionDifference > 0 ? 1.0 : -1.0;
    }

    void OnBodyEntered(Node2D body)
    {
        if (body is Hero)
        {
            Hero hero = (Hero)body;

            isHeroDetected = true;
            heroDetected = hero;
            direction = GetHeroDirection(hero.GlobalPosition);
        }
    }

    void OnBodyExited(Node2D body)
    {
        if (body is Hero)
        {
            Hero hero = (Hero)body;
            isHeroDetected = false;
            heroDetected = null;
        }
    }

    void OnEnterWander(int waypoint) {
        wanderWaypoint.X = waypoint;
        state = EnemyState.Wander;
    }
}

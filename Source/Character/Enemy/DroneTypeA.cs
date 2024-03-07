using Godot;

public partial class DroneTypeA : Enemy
{
    private enum EnemyState
    {
        Idle,
        Chase,
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

    public override void _Ready()
    {
        base._Ready();
        wanderController = GetNode<WanderControllerA>("WanderControllerA");

        state = EnemyState.Idle;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (Input.IsActionJustPressed("Interact")) {
            GodotExtension.PrintList(wanderController.waypoints);
        }

        switch (state)
        {
            case EnemyState.Idle:
                StateIdle();
                break;
            case EnemyState.Chase:
                StateChase(delta);
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

        if (direction > 0)
        {
            PlayAnim("MoveRight");
        }
        else
        {
            PlayAnim("MoveLeft");
        }

        MoveAndSlide();
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
}

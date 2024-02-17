using Godot;

public partial class DroneTypeA : Enemy
{
    private enum EnemyState
    {
        Idle,
        Move,
        Death,
        Attack
    }

    private EnemyState state;

    // Property
    [Export]
    private double moveSpeed = 100.0d;

    [Export]
    private double gravity = 980.0d;
    private double direction = 1.0d;

    // Flag
    private bool isHeroDetected = false;

    public override void _Ready()
    {
        base._Ready();
        state = EnemyState.Idle;
    }

    public override void _PhysicsProcess(double delta)
    {
        switch (state)
        {
            case EnemyState.Idle:
                StateIdle();
                break;
            case EnemyState.Move:
                StateMove(delta);
                break;
        }
    }

    private void StateIdle()
    {
        // Exit to Move state
        if (isHeroDetected)
        {
            state = EnemyState.Move;
            return;
        }

        PlayAnim("Idle");
    }

    private void StateMove(double delta)
    {
        Vector2 velocity = Velocity;

        // Exit to idle state
        if (!isHeroDetected)
        {
            state = EnemyState.Idle;
            return;
        }

        velocity.X = (float)(moveSpeed * direction);
        Velocity = velocity;

        PlayAnim("Move");
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
            direction = GetHeroDirection(hero.GlobalPosition);
        }
    }

    void OnBodyExited(Node2D body)
    {
        if (body is Hero)
        {
            Hero hero = (Hero)body;
            isHeroDetected = false;
        }
    }
}

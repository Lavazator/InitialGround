using Godot;
using System;

public partial class Hero : CharacterBody2D
{
    [Export] public double gravity = 980.0d;
    [Export] public double speed = 200.0d;
    [Export] public double jumpImpulse = 100.0d;

    protected bool jumpPeak = false;

    protected enum HeroState {Idle, Move, Death, Jump, Fall, None};
    protected HeroState state = HeroState.Idle;

    // Node
    protected Sprite2D sprite;
    protected AnimationPlayer animationPlayer;
    protected RemoteTransform2D remoteTransform;

    // Constants
    private const int FloorSnapLengthValue = 32;

    public override void _Ready()
    {
        base._Ready();
        sprite = GetNode<Sprite2D>("Sprite");
        animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        remoteTransform = GetNode<RemoteTransform2D>("RemoteTransform");

        FloorSnapLength = FloorSnapLengthValue;
        FloorConstantSpeed = true;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        
        if (GetDirection() != 0) {
            sprite.FlipH = !(GetDirection() > 0);
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        
        switch (state) {
            case HeroState.Idle:
                StateIdle(delta);
                break;
            case HeroState.Move:
                StateMove(delta);
                break;
            case HeroState.Jump:
                StateJump(delta);
                break;
            case HeroState.Fall:
                StateFall(delta);
                break;
            case HeroState.Death:
                StateDeath();
                break;
        }

        // if (!IsOnFloor()) {
        //     ApplyGravity(delta);
        // }
    }

    // State Handlers
    public virtual void StateIdle(double delta) {}
    public virtual void StateMove(double delta) {}
    public virtual void StateJump(double delta) {}
    public virtual void StateFall(double delta) {}
    public virtual void StateDeath() {}


    public void ConnectCamera(Camera2D camera) {
        NodePath cameraPath = camera.GetPath();
        remoteTransform.RemotePath = cameraPath;
    }

    public float GetDirection() {
        return Input.GetAxis("MoveLeft", "MoveRight");
    }

    protected void ApplyGravity(double delta) {
        Vector2 velocity = Velocity;
        velocity.Y += (float)gravity * (float)delta;

        Velocity = velocity;
        MoveAndSlide();
    }

    protected bool EnterJump() {
        return IsOnFloor() && Input.IsActionJustPressed("Jump");
    }

    protected void StartJump() {
        state = HeroState.Jump;
        jumpPeak = false;
        animationPlayer.Play("Cyborg/Jump");
        
        Vector2 velocity = Velocity;
        velocity.Y = (float)-jumpImpulse;
        Velocity = velocity;
        MoveAndSlide();
    }

    protected void CheckJumpPeak() {
        if (Velocity.Y >= 0 && !jumpPeak) {
            jumpPeak = true;
            state = HeroState.Fall;
        }
    }

    void _OnSensorAreaEntered(Area2D area) {
        
        // Coins
        if (area is Coin) {
            Coin coin = (Coin)area;
            GameData.collectedCoins += coin.value;
            coin.EmitSignal("Collected");
        }

    }
}
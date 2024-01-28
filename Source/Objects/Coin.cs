using Godot;
using System;

public partial class Coin : Area2D
{
    // Signal
    [Signal] public delegate void CollectedEventHandler();

    // Export
    [Export] public int value = 5;

    // Node
    private AnimatedSprite2D _animatedSprite;
    private CollisionShape2D _collisionShape;

    public override void _Ready()
    {
        base._Ready();
        _animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite");
        _collisionShape = GetNode<CollisionShape2D>("CollisionShape");

        _animatedSprite.Play();
    }

    private void OnCollected() {
        QueueFree();
    }
}

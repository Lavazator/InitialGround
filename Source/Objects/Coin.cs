using Godot;
using System;

public partial class Coin : Area2D
{
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
}

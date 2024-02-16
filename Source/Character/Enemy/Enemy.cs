using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
    protected int health;

    // Node
    protected Sprite2D sprite;
    protected AnimationPlayer animationPlayer;

    public override void _Ready()
    {
        sprite = GetNode<Sprite2D>("Sprite");
        animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
    }
}

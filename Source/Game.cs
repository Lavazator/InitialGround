using Godot;
using System;

public partial class Game : Node2D
{
    private Hero player;
    private Camera2D camera;

    public override void _Ready()
    {
        base._Ready();
        player = GodotExtension.GetChildByType<Hero>(this);
        camera = GetNode<Camera2D>("Camera");

        // set up the player camera
        player.ConnectCamera(camera);
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
    }
}

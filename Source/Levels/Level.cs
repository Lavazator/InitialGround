using Godot;
using System;

public partial class Level : Node2D
{

    protected Hero player;
    protected Camera2D camera;

    public override void _Ready()
    {
        base._Ready();
        player = GodotExtension.GetChildByType<Hero>(this);
        camera = GetNode<Camera2D>("Camera");

        // set up the player camera
        player.ConnectCamera(camera);
    }
}
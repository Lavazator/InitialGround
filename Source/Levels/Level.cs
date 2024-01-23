using Godot;
using System;

public partial class Level : Node2D
{
    [ExportGroup("World Boundary Limit")]
    [Export] public int boundaryTop = -10000000;
    [Export] public int boundaryRight = 10000000;
    [Export] public int boundaryBottom = 10000000;
    [Export] public int boundaryLeft = -10000000;

    public override void _Ready()
    {
        base._Ready();
        Hero hero = GodotExtension.GetChildByType<Hero>(this);
        Camera2D camera = GodotExtension.GetChildByType<Camera2D>(hero);
        camera.LimitTop = boundaryTop;
        camera.LimitRight = boundaryRight;
        camera.LimitBottom = boundaryBottom;
        camera.LimitLeft = boundaryLeft;
    }
}
using Godot;
using System;

public partial class Level : Node2D
{
    [ExportGroup("World boundaries")]
    [Export] public int boundryTop = -10000000;
    [Export] public int boundryRight = 10000000;
    [Export] public int boundryBottom = 10000000;
    [Export] public int boundryLeft = -10000000;

    // Node
    private Marker2D basePosition;

    // Property
    public Vector2 initPosition;

    public override void _Ready()
    {
        basePosition = GetNode<Marker2D>("%BasePosition");
        initPosition = basePosition.Position;
    }
}

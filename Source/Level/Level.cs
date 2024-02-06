using Godot;
using System;

public partial class Level : Node2D
{
    [ExportGroup("World boundaries")]
    [Export] public int boundryTop = -10000000;
    [Export] public int boundryRight = 10000000;
    [Export] public int boundryBottom = 10000000;
    [Export] public int boundryLeft = -10000000;

    public Vector2 GetBaseLocalPosition() {
        return  GetNode<Marker2D>("BasePosition").Position;
    }
}

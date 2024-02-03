using Godot;
using System;

public partial class Level : Node2D
{
    [ExportGroup("World boundaries")]
    [Export] int boundryTop = 9999;
    [Export] int boundryRight = 9999;
    [Export] int boundryBottom = 9999;
    [Export] int boundryLeft = 9999;
}

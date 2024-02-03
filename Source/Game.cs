using Godot;
using System;

public partial class Game : Node2D
{
    private Hero player;
    private Camera2D camera;
    private GUI gui;
    private Level level;

    public override void _Ready()
    {
        base._Ready();
        player = GodotExtension.GetChildByType<Hero>(this);
        camera = GetNode<Camera2D>("Camera");
        gui = GetNode<GUI>("GUI");
        level = GodotExtension.GetChildByType<Level>(this);

        // set up the player
        player.ConnectCamera(camera);
        player.Collect += HandleCollectable;

        // set up the level
        SetCameraLimit();
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        GD.Print(camera.LimitTop);
        GD.Print(camera.LimitRight);
    }

    private void HandleCollectable(Collectable items) {
        if (items is Coin) {
            gui.UpdateCoin(GameData.collectedCoins);
        } 
    }

    private void SetCameraLimit() {
        camera.LimitTop = level.boundryTop;
        camera.LimitRight = level.boundryRight;
        camera.LimitBottom = level.boundryBottom;
        camera.LimitLeft = level.boundryLeft;
    }
}

using Godot;
using System;

public partial class Game : Node2D
{
    private Hero player;
    private Camera2D camera;
    private GUI gui;
    private Level level;
    private Portal portal;

    public override void _Ready()
    {
        player = GodotExtension.GetChildByType<Hero>(this);
        camera = GetNode<Camera2D>("Camera");
        gui = GetNode<GUI>("GUI");
        level = GodotExtension.GetChildByType<Level>(this);
        portal = GodotExtension.GetChildByType<Portal>(level);

        // set up the player
        player.ConnectCamera(camera);
        player.Collect += HandleCollectable;
        player.GlobalPosition = level.GetBaseLocalPosition();

        SetCameraLimit();
        portal.RequestLevelChange += ChangeLevel;
    }


    private void ChangeLevel(PackedScene NextLevel) {
        level.QueueFree();
        Level nextLevel = (Level)NextLevel.Instantiate();
        level = nextLevel;

        player.GlobalPosition = level.GetBaseLocalPosition();
        portal = GodotExtension.GetChildByType<Portal>(level);
        portal.RequestLevelChange += ChangeLevel;
        AddChild(nextLevel);
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

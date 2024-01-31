using Godot;
using System;

public partial class Game : Node2D
{
    private Hero player;
    private Camera2D camera;
    private GUI gui;

    public override void _Ready()
    {
        base._Ready();
        player = GodotExtension.GetChildByType<Hero>(this);
        camera = GetNode<Camera2D>("Camera");
        gui = GetNode<GUI>("GUI");

        // set up the player
        player.ConnectCamera(camera);
        player.Collect += HandleCollectable;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
    }

    private void HandleCollectable(Collectable items) {
        if (items is Coin) {
            gui.UpdateCoin(GameData.collectedCoins);
        } 
    }
}

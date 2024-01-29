using Godot;
using System;

public partial class Level : Node2D
{

    protected Hero player;
    protected Camera2D camera;
    Label coinGUI;

    public override void _Ready()
    {
        base._Ready();
        player = GodotExtension.GetChildByType<Hero>(this);
        camera = GetNode<Camera2D>("Camera");
        coinGUI = GetNode<Label>("CoinGUI");

        // set up the player camera
        player.ConnectCamera(camera);
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        coinGUI.Text = GameData.collectedCoins.ToString();
    }
}
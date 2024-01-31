using Godot;
using System;

public partial class GUI : CanvasLayer
{
    private CoinUI coinUI;

    public override void _Ready()
    {
        base._Ready();
        coinUI = GetNode<CoinUI>("%CoinUI");
    }

    public void UpdateCoin(int value) => coinUI.EmitSignal("UpdateCoin", value);
}

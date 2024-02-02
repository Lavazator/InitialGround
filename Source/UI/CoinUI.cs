using Godot;
using System;

public partial class CoinUI : HBoxContainer
{
    [Signal] public delegate void UpdateCoinEventHandler(int value);

    private TextureRect textureRect;
    private CounterLabel label;

    public override void _Ready()
    {
        base._Ready();
        textureRect = GetNode<TextureRect>("TextureRect");
        label = GetNode<CounterLabel>("Label");

        // Connecting signal
        UpdateCoin += UpdateUI;
    }

    private void UpdateUI(int value) {
        label.UpdateValue(value);
    }
}

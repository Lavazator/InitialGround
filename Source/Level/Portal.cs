using Godot;
using System;

public partial class Portal : Area2D
{
    [Export] PackedScene NextLevel;

    private bool isPlayerEnter = false;

    public override void _Process(double delta)
    {
        if (isPlayerEnter && Input.IsActionJustPressed("Interact")) {
            ChangeScene();
        }
    }

    private void ChangeScene() {
        GD.Print(true);
    }

    private void PlayerEntered(Node2D body) {
        if (body is Hero) {
            isPlayerEnter = true;
        }
    }

    private void PlayerExited(Node2D body) {
        if (body is Hero) {
            isPlayerEnter = false;
        }
    }
}

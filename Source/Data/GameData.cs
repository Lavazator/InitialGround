using Godot;
using System;

public partial class GameData : Node
{
    public static int collectedCoins {get; set;}

    public static int CollectedCoins {
        get {return collectedCoins;}
        set {collectedCoins = value;}
    }
}

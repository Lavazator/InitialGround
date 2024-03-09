using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

// This wander controller is use for only ground 2D platformer character

// It generate random waypoints in x-axis under waypoints limit

public partial class WanderControllerA : Node2D
{
    [ExportCategory("Wander Properties")]

    [ExportGroup("Waypoints properties")]
    [Export] int waypointLimitLeft = 0;
    [Export] int waypointLimitRight = 0;
    [Export(PropertyHint.Range, "0, 5")] int waypointAmount = 0;

    [ExportGroup("Wander time")]
    [Export(PropertyHint.Range, "1, 10")] double wanderTimeDelay;

    // Signal
    [Signal] public delegate void EnteringWanderEventHandler(int waypoint);

    // Node
    private Timer delayTimer;

    // Fields
    private List<int> waypoints;

    // Flag
    private int targetWaypoint;

    public override void _Ready()
    {
        base._Ready();
        GD.Randomize();

        delayTimer = GetNode<Timer>("DelayTimer");
        waypoints = GetRandomWaypoints();
    }

    public void StartWander() {
        targetWaypoint = GetWaypoint();
        EmitSignal("EnteringWander", targetWaypoint);
    }

    private List<int> GetRandomWaypoints() {
        Random random = new(); // Ensure correct constructor call
        List<int> waypoints = []; // This will store our waypoints

        for (int x = 0; x < waypointAmount; x++) {
            int waypoint = random.Next(waypointLimitLeft, waypointLimitRight + 1);
            waypoints.Add(waypoint); // Directly add to the list
        }

        return waypoints; // Return the populated list
    }

    private int GetWaypoint() {
        Random random = new();

        if (targetWaypoint == 0) {
            return waypoints[random.Next(0, waypoints.Count)];
        }

        List<int> filteredWaypoints = waypoints.Where(num => num != targetWaypoint).ToList();
        return filteredWaypoints[random.Next(0, filteredWaypoints.Count)];
    }
}

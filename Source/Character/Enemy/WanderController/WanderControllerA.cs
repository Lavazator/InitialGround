using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

// This wander controller is use for only ground 2D platformer character

// It generate random waypoints in x-axis under waypoints limit

public partial class WanderControllerA : Node2D
{
    // Waypoints field
    [ExportCategory("Waypoints properties")]
    [Export] int waypointLimitLeft = 0;
    [Export] int waypointLimitRight = 0;
    [Export(PropertyHint.Range, "0, 5")] int waypointAmount = 0;

    // Fields
    public List<int> waypoints;

    public override void _Ready()
    {
        base._Ready();
        GD.Randomize();
        waypoints = GetRandomWaypoints();
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
}

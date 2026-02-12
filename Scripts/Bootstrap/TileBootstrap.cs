using System;
using System.Collections.Generic;
using Raylib_cs;

public class TileBootstrap
{
    public static void Bootstrap(TileRegistry registry)
    {
        registry.RegisterTile(0,new TileDefinition
        {
            Id = 0,
            Name = "Grass",
            Color = Color.Green,
            BlocksMovement = false,
            BlocksVision = false,
            IsTrigger = false,
            MovementCost = 1f,
            DamagePerSecond = 0
        });

        registry.RegisterTile(1,new TileDefinition
        {
            Id = 1,
            Name = "Wall",
            Color = Color.Gray,
            BlocksMovement = true,
            BlocksVision = true,
            IsTrigger = false,
            MovementCost = 1f,
            DamagePerSecond = 0
        });
    }
}
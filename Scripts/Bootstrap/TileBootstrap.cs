using System;
using System.Collections.Generic;
using Raylib_cs;

public class TileBootstrap
{
    public static void Bootstrap(TileRegistry registry)
    {
        registry.RegisterTile(1, new TileDefinition
        {
            Id = 1,
            Name = "Wall",
            Texture = Raylib.LoadTexture("TileSetsPng/Ase/Spr_wall.png"),
            BlocksMovement = true,
            BlocksVision = true,
            IsTrigger = false,
            MovementCost = 1f,
            DamagePerSecond = 0
        });

        registry.RegisterTile(2, new TileDefinition
        {
            Id = 2,
            Name = "Grass",
            Texture = Raylib.LoadTexture("TileSetsPng/Ase/Spr_Grass.png"),
            BlocksMovement = false,
            BlocksVision = false,
            IsTrigger = false,
            MovementCost = 1f,
            DamagePerSecond = 0
        });
    }
}
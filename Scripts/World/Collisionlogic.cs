using System;
using Raylib_cs;
using System.Numerics;

public class CollisionLogic
{
    public GridWorldManager _world;

    public CollisionLogic(GridWorldManager world)
    {
        _world = world;
    }

    public bool ClampToWorld(ref Vector2 Position, ref int playerRadius)
    {
        int maxWidth = _world.WorldWidth - playerRadius;
        int maxHeight = _world.WorldHeight - playerRadius;
        
        if (Position.X < playerRadius) Position.X = playerRadius;
        if (Position.X > maxWidth)   Position.X = maxWidth;

        if (Position.Y < playerRadius) Position.Y = playerRadius;
        if (Position.Y > maxHeight)   Position.Y = maxHeight;

        return true;
    }
}
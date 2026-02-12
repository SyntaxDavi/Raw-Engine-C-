using System;
using Raylib_cs;
using System.Numerics;

public class CollisionLogic
{
    public GridWorldManager _world;
    public TileRegistry _tileRegistry;

    public CollisionLogic(GridWorldManager world, TileRegistry tileRegistry)
    {
        _tileRegistry = tileRegistry;
        _world = world;
    }

    public bool IsTileWalkable(Vector2 worldPos)
    {
        if (worldPos.X < 0 || worldPos.Y < 0 || worldPos.X > _world.WorldWidth || worldPos.Y > _world.WorldHeight)
        {
            return false;
        }

        Vector2 gridPos = _world.WorldToGrid(worldPos);
        int tileId = _world.GetTileAtWorldPos(worldPos);
        TileDefinition tile = _tileRegistry.GetTile(tileId);
        return !tile.BlocksMovement;
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
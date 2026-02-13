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

    public bool IsAreaWalkable(Vector2 topLeftPos, Vector2 size)
    {
        if (topLeftPos.X < 0 || topLeftPos.X + size.X > _world.WorldWidth) return false;
        if (topLeftPos.Y < 0 || topLeftPos.Y + size.Y > _world.WorldHeight) return false;

        float epsilon = 0.1f;
        Vector2 tl = new Vector2(topLeftPos.X + epsilon, topLeftPos.Y + epsilon);
        Vector2 tr = new Vector2(topLeftPos.X + size.X - epsilon, topLeftPos.Y + epsilon);
        Vector2 bl = new Vector2(topLeftPos.X + epsilon, topLeftPos.Y + size.Y - epsilon);
        Vector2 br = new Vector2(topLeftPos.X + size.X - epsilon, topLeftPos.Y + size.Y - epsilon);

        if (isPointBlocked(tl)) return false;
        if (isPointBlocked(tr)) return false;
        if (isPointBlocked(bl)) return false;
        if (isPointBlocked(br)) return false;

        return true;
    }

    public bool isPointBlocked(Vector2 worldPos)
    {
        int tileId = _world.GetTileAtWorldPos(worldPos);
        TileDefinition tile = _tileRegistry.GetTile(tileId);
        return tile.BlocksMovement;
    }
}
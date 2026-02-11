using System;
using Raylib_cs;
using System.Numerics;

public class CollisionLogic
{
    public MainSceneData MainSceneData = new MainSceneData();

    public bool CheckBounds( ref Vector2 Position, ref float playerRadius)
    {
        int worldWidth = MainSceneData.getXSize();
        int worldHeight = MainSceneData.getYSize();
        
        //Limitar o X
        if (Position.X < playerRadius)
            Position.X = playerRadius;
        if (Position.X > worldWidth - playerRadius)
            Position.X = worldWidth - playerRadius;

        //Limitar o Y
        if (Position.Y < playerRadius)
            Position.Y = playerRadius;
        if (Position.Y > worldHeight - playerRadius)
            Position.Y = worldHeight - playerRadius;

        return true;
    }
}
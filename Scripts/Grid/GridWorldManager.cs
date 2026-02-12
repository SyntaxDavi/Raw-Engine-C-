using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

//Script responsável por criar e manter a grid do mundo
//Apenas o Manager

public class GridWorldManager
{
    public int Width;
    public int Height;
    public int TileSize;

    public int[,] _tiles;

    public int WorldWidth => Width * TileSize;
    public int WorldHeight => Height * TileSize;

    public GridWorldManager(int width,int height,int tileSize)
    {
        Width = width;
        Height = height;
        TileSize = tileSize;

        _tiles = new int[Width,Height];
    }

    public Vector2 GridToWorld(int x, int y)
    {
        return new Vector2(x * TileSize, y * TileSize);
    }

    public Vector2 WorldToGrid(Vector2 worldPos)
    {
        return new Vector2((int)worldPos.X / TileSize, (int)worldPos.Y / TileSize);
    }

    public int GetTileAtWorldPos(Vector2 worldPos)
    {
        Vector2 gridPos = WorldToGrid(worldPos);
        int x = (int)gridPos.X;
        int y = (int)gridPos.Y;

        if (x < 0 || x >= Width || y < 0 || y >= Height) return 1; // Retorna Wall (1) se estiver fora dos limites
        return _tiles[x, y];
    }
}
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

    private int[,] _tiles;

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

    public Vector2 WorldToGrid(int x, int y)
    {
        return new Vector2(x / TileSize, y / TileSize);
    }

    public void Draw()
    {
        for(int x = 0; x < Width; x++){
            for(int y = 0; y < Height; y++)
            {
                Vector2 pos = GridToWorld(x,y);
                Color color = _tiles[x,y] == 0 ? Color.DarkGreen : Color.Green;

                Raylib.DrawRectangleV(pos, new Vector2(TileSize,TileSize),color);
                Raylib.DrawRectangleLinesEx(new Rectangle(pos.X, pos.Y, TileSize, TileSize), 1, Color.Black);
            }
        }
    }
}
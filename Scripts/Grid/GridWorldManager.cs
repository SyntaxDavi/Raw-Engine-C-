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

    private int[,] _tiles;

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

    public Vector2 WorldToGrid(int x, int y)
    {
        return new Vector2(x / TileSize, y / TileSize);
    }

    public void Draw(Camera2D camera)
    {
        // Calcula os limites da visualização da câmera para desenhar apenas o que está na tela
        Vector2 screenTopLeft = Raylib.GetScreenToWorld2D
        (new Vector2(0, 0), camera);
        Vector2 screenBottomRight = Raylib.GetScreenToWorld2D
        (new Vector2(Raylib.GetScreenWidth(), Raylib.GetScreenHeight()), camera);

        int startX = (int)(screenTopLeft.X / TileSize);
        int startY = (int)(screenTopLeft.Y / TileSize);

        int endX = (int)(screenBottomRight.X / TileSize) + 2;
        int endY = (int)(screenBottomRight.Y / TileSize) + 2;

        // Limita os índices aos limites da grid
        startX = Math.Max(0, startX);
        startY = Math.Max(0, startY);

        endX = Math.Min(Width, endX);
        endY = Math.Min(Height, endY);

        for (int x = startX; x < endX; x++)
        {
            for (int y = startY; y < endY; y++)
            {
                Vector2 pos = GridToWorld(x, y);
                Color color = _tiles[x, y] == 0 ? Color.DarkGreen : Color.Red;

                Raylib.DrawRectangleV(pos, new Vector2(TileSize, TileSize), color);
                Raylib.DrawRectangleLinesEx(new Rectangle(pos.X, pos.Y, TileSize, TileSize), 1, Color.Black);
            }
        }
    }
}
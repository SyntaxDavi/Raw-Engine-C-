using Raylib_cs;
using System.Numerics;
using System;

// Parte do RendererPipeline focada apenas no Grid
public partial class RendererPipeline
{
    private void RenderTiles()
    {
        Camera2D camera = _mainCamera._camera;

        Vector2 screenTopLeft = Raylib.GetScreenToWorld2D(new Vector2(0, 0), camera);
        Vector2 screenBottomRight = Raylib.GetScreenToWorld2D(new Vector2(Raylib.GetScreenWidth(), Raylib.GetScreenHeight()), camera);

        int tileSize = _gridWorldManager.TileSize;
        int startX = Math.Max(0, (int)(screenTopLeft.X / tileSize));
        int startY = Math.Max(0, (int)(screenTopLeft.Y / tileSize));

        int endX = Math.Min(_gridWorldManager.Width, (int)(screenBottomRight.X / tileSize) + 2);
        int endY = Math.Min(_gridWorldManager.Height, (int)(screenBottomRight.Y / tileSize) + 2);

        for (int x = startX; x < endX; x++)
        {
            for (int y = startY; y < endY; y++)
            {
                Vector2 pos = _gridWorldManager.GridToWorld(x, y);
                
                // Pega o ID do tile e busca a cor no registro
                int tileId = _gridWorldManager._tiles[x, y];
                TileDefinition tileDef = _tileRegistry.GetTile(tileId);
                
                if (tileDef != null)
                {
                    Texture2D texture = tileDef.Texture;
                    Raylib.DrawTexturePro(texture, new Rectangle(0, 0, texture.Width, texture.Height), 
                    new Rectangle(pos.X, pos.Y, tileSize, tileSize), Vector2.Zero, 0, Color.White);
                }
                else 
                {
                     // Opcional: Desenhar um quadrado magenta para indicar erro/vazio
                     Raylib.DrawRectangleV(pos, new Vector2(tileSize, tileSize), Color.Magenta);
                }
                
                Raylib.DrawRectangleLinesEx(new Rectangle(pos.X, pos.Y, tileSize, tileSize), 1, Color.Black);
            }
        }
    }
}
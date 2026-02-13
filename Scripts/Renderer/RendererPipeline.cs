using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System;

//Sistema de renderer é quem decide como cada coisa aparece na tela
//É responsabilidade do renderer organizar a ordem de desenho (pipeline)

public partial class RendererPipeline
{
    public TileRegistry _tileRegistry;
    public MainCamera _mainCamera;
    public GridWorldManager _gridWorldManager;
    public List<Entity> _entities;

    //O renderer recebe todas as informações que ele precisa para desenhar
    public RendererPipeline(TileRegistry tileRegistry, MainCamera mainCamera, GridWorldManager gridWorldManager, List<Entity> entities)
    {
        _tileRegistry = tileRegistry;
        _mainCamera = mainCamera;
        _gridWorldManager = gridWorldManager;
        _entities = entities;
    }

    //Esse script vai ser o que chama os outros draw, vai ser o pipeline explicito principal
    public void DrawPipeline()
    {
        Raylib.BeginDrawing();
            RendererClear();
            
            // Desenho que segue a câmera
            Raylib.BeginMode2D(_mainCamera._camera);
                RenderTiles();
                RenderEntities();
            Raylib.EndMode2D();
            
            // Desenho fixo na tela (UI)
            RenderUI();
            RenderDebug();
        Raylib.EndDrawing();
    }

    private void RendererClear()
    {
        Raylib.ClearBackground(Color.Black);
    }

    private void RenderUI()
    {
        Raylib.DrawFPS(10, 10);
    }

    private void RenderDebug()    
    {
        // Aqui você pode colocar grades de debug, etc
    }
}
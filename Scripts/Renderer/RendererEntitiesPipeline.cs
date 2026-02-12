using Raylib_cs;
using System.Collections.Generic;
using System.Numerics;

// Parte do RendererPipeline focada apenas nas Entidades
public partial class RendererPipeline
{
    private void RenderEntities()
    {
        foreach(var entity in _entities)
        {
            // Por enquanto desenhamos um retângulo simples para todas as entidades
            Raylib.DrawRectangleV(entity.Position, entity.Size, Color.Red);
        }
    }   
}

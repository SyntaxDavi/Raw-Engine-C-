using Raylib_cs;
using System.Collections.Generic;
using System.Numerics;

// Parte do RendererPipeline focada apenas nas Entidades
public partial class RendererPipeline
{
    private void RenderEntities()
    {
        //Ordena as entidades por posição Y
        //manter lista já ordenada ou usar sort in-place:
        _entities.Sort((a, b) => a.Position.Y.CompareTo(b.Position.Y));
        
        foreach(var entity in _entities)
        {
            entity.Draw();
        }
    }   
}

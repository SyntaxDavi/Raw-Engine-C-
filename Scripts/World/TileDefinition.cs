using Raylib_cs;
using System.Numerics;
using System;
using System.Collections.Generic;

public class TileDefinition
{
    public int Id;                 // Identificador do tipo
    public string Name;            // Nome lógico (debug, editor)

    // RENDER
    public Color Color;            // Visual simples (ou depois Sprite)

    // FÍSICA
    public bool BlocksMovement;    // Impede atravessar (parede, pedra)

    // VISÃO
    public bool BlocksVision;      // Bloqueia linha de visão

    // INTERAÇÃO
    public bool IsTrigger;         // Dispara evento ao entrar

    // GAMEPLAY MODIFIERS
    public float MovementCost;     // 1 = normal, >1 = lento (lama), <1 = gelo
    public int DamagePerSecond;    // 0 = não causa dano
}

public class TileRegistry
{
   private Dictionary<int, TileDefinition> _tiles = new Dictionary<int, TileDefinition>();

   public void RegisterTile(int Id, TileDefinition tile)
   {
    _tiles[tile.Id] = tile;
   }

   public TileDefinition GetTile(int Id)
   {
    return _tiles[Id];
   }

}
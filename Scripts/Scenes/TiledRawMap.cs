using Raylib_cs;
using System.Collections.Generic;
using System.Text.Json;

public class TiledRawMap
{
    public int Width {get; set;}
    public int Height {get; set;}
    public int TileWidth {get; set;}
    public int TileHeight {get; set;}
    public List<TiledLayer> Layers {get; set;} = null!;
}

public class TiledLayer
{
    public int[] Data {get; set;} = null!;
}
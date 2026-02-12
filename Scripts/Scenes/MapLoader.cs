using System.Text.Json;
using System.IO;
using Raylib_cs;
using System.Numerics;

public class MapData 
{
    public int Width;
    public int Height;
    public int TileSize;
    public int[,] Tiles;
}

public class MapLoader
{
    public MapData Load(string path)
    {
        TileRawMap raw = JsonSerializer.Deserialize<TileRawMap>(json);

        MapData mapData = new MapData();
        mapData.Width = raw.Width;
        mapData.Height = raw.height;
        mapData.TileSize = raw.tileWidth;
        mapData.Tiles = ConvertTo2D(raw.layers[0].data,raw.width,raw.height)

        return data;
    }
}
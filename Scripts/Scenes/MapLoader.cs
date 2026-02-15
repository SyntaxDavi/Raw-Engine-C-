using System.Text.Json;
using System.IO;
using Raylib_cs;
using System.Numerics;

public class MapData 
{
    public int Width;
    public int Height;
    public int TileSize;
    public int [,] Tiles = null!;
}

public class MapLoader
{
    public MapData Load(string path)
    {
        string json = File.ReadAllText(path);
        
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        TiledRawMap raw = JsonSerializer.Deserialize<TiledRawMap>(json, options)!;

        if (raw == null || raw.Layers == null || raw.Layers.Count == 0)
        {
            throw new System.Exception("Failed to load map or map has no layers.");
        }

        MapData mapData = new MapData();
        mapData.Width = raw.Width;
        mapData.Height = raw.Height;
        mapData.TileSize = raw.TileWidth;

        mapData.Tiles = ConvertTo2D(raw.Layers[0].Data, raw.Width, raw.Height);

        return mapData;
    }

    private int[,] ConvertTo2D(int[] flatData, int width, int height)
    {
        int [,] result = new int[width, height];
        
        for(int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                int index = y * width + x;
                result[x,y] = flatData[index];
            }
        }
        return result;
    }
}
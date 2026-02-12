using Raylib_cs;
using System.Numerics;

//Quando o jogo começa, ela não cria um grid gigante genérico. 
//Ela lê as informações do JSON (ex: "esse mapa tem 40x30") e só então ela inicializa o
//GridWorldManager com esses tamanhos exatos.

public class SceneManager
{
    public GridWorldManager CurrentGrid;

    public void LoadScene(string scenePath)
    {
        MapLoader loader = new MapLoader();
        MapData mapData = loader.Load(scenePath);

        CurrentGrid = new GridWorldManager(
            mapData.Width,
            mapData.Height,
            mapData.TileSize
        );

        CurrentGrid._tiles = mapData.Tiles;
    }
}

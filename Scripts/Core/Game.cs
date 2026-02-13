using Raylib_cs; 
using System.Numerics;
using System.Collections.Generic;

// Esse script é responsável por iniciar e manter a lista de entidades
// Também é responsável por atualizar e desenhar as entidades

public class Game 
{   
    private List<Entity> _entities = new List<Entity>();
    private List<GameObjects> _gameObjects = new List<GameObjects>();

    public PlayerController _player;
    public MainCamera _mainCamera;
    public GridWorldManager _gridWorldManager;
    public TileRegistry _tileRegistry;
    public RendererPipeline _renderer;

    public Game(int screenWidth, int screenHeight)
    {
        _tileRegistry = new TileRegistry();
        TileBootstrap.Bootstrap(_tileRegistry);

        // Agora usamos o SceneManager para carregar o mapa do Tiled
        SceneManager sceneManager = new SceneManager();
        sceneManager.LoadScene("Tiled/MainScene/MainSceneMap.tmj");
        
        _gridWorldManager = sceneManager.CurrentGrid;

        _player = new PlayerController(new Vector2(500, 500), _gridWorldManager, _tileRegistry);
        _entities.Add(_player);
        _mainCamera = new MainCamera();
        _mainCamera.Init(_player, screenWidth, screenHeight, _gridWorldManager);

        // Inicializamos o renderer UMA VEZ no começo carregando todas as ferramentas
        _renderer = new RendererPipeline(_tileRegistry, _mainCamera, _gridWorldManager, _entities);
    }

    public void Update(float dt)
    {
        foreach(var entity in _entities)
        {
            entity.Update(dt);
        }

        _mainCamera.Update(dt);
    }

    public void Draw()
    {
        // Agora o Draw apenas pede para o pipeline rodar
        _renderer.DrawPipeline();
    }
}
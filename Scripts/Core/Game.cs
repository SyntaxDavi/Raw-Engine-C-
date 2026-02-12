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

    public Game(int screenWidth, int screenHeight)
    {
        _gridWorldManager = new GridWorldManager(250,250,64);
        _player = new PlayerController(new Vector2(500, 500), _gridWorldManager);
        _entities.Add(_player);
        _mainCamera = new MainCamera();
        _mainCamera.Init(_player, screenWidth, screenHeight);
    }

    public void Update(float dt)
    {
        foreach(var entity in _entities)
        {
            entity.Update(dt);
        }

        _mainCamera.Update();
    }

    public void Draw()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Black);

        Raylib.BeginMode2D(_mainCamera._camera);

        _gridWorldManager.Draw(_mainCamera._camera);

        foreach(var entity in _entities)
        {
            entity.Draw();
        }
        Raylib.EndMode2D();
        Raylib.EndDrawing();
    }
}
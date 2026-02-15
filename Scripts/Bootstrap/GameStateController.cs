using System;
using System.Collections.Generic;
using Raylib_cs;

public class GameStateController 
{
    private GameState _gameState;
    public Game _game;

    public GameStateController(Game game)
    {
        _game = game;
        _gameState = GameState.Init;
    }

    public bool CanChangeState(GameState newState)
    {
        if(_gameState == newState) return false;
        if(_gameState == GameState.Exiting) return false;
        return true;
    }

    public void ChangeState(GameState newState)
    {
        if( CanChangeState(newState))
            _gameState = newState;
    }

    public void Update(float dt)
    {
        switch (_gameState)
        {
            case GameState.Init:
                Init();
                break;
            case GameState.Playing:
                Playing(dt);
                break;
            case GameState.Exiting:
                Exiting();
                break;
        }
    }

    public void Playing(float dt)
    {
        _game.Update(dt);
        _game.Draw();
    }

    public void Init()
    {
        _game.Load();
        _gameState = GameState.Playing;
    }

    public void Exiting()
    {
        _game.Save();
        Raylib.CloseWindow();
    }
}
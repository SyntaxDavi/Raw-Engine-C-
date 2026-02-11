using Raylib_cs; 
using System.Numerics;

public class Game 
{   
    public Player _player;
    public CollisionLogic _collisionLogic;
    public Game()
    {
        _player = new Player();
        _collisionLogic = new CollisionLogic();
    }
    public void Update(float dt)
    {
        _player.Input(dt, _collisionLogic);
    }
}
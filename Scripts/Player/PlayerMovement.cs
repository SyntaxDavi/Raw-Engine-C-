using System.Numerics;
using Raylib_cs;

public class PlayerMovement
{
    private PlayerController _playerController;
    private InputManager _inputManager;
    private CollisionLogic _collisionLogic;
    private PlayerData _playerData;
    
    public PlayerMovement(PlayerController playerController, InputManager inputManager, CollisionLogic collisionLogic, PlayerData playerData)
    {
        _playerController = playerController;
        _inputManager = inputManager;
        _collisionLogic = collisionLogic;
        _playerData = playerData;
    }

    public void ApplyMovement(Vector2 direction, float dt)
    {
        Vector2 moveAmount = direction * _playerData.BaseSpeed * dt;
            
        // Tenta mover no X
        Vector2 nextPosX = new Vector2(_playerController.Position.X + moveAmount.X, _playerController.Position.Y);
        Vector2 collisionPos = nextPosX + _playerData.CollisionOffset;
        if (_collisionLogic.IsAreaWalkable(collisionPos, _playerData.CollisionSize)) 
        {
            _playerController.Position.X = nextPosX.X;
        }
        
        // Tenta mover no Y
        Vector2 nextPosY = new Vector2(_playerController.Position.X, _playerController.Position.Y + moveAmount.Y);
        collisionPos = nextPosY + _playerData.CollisionOffset;
        if (_collisionLogic.IsAreaWalkable(collisionPos, _playerData.CollisionSize)) 
        {
            _playerController.Position.Y = nextPosY.Y;
        }
    }

    public void Input(float dt)
    {
        Vector2 direction = _inputManager.GetInput();

        if (direction != Vector2.Zero)
        {
            _playerController.PlayerChangeState(PlayerState.Walking);
            ApplyMovement(direction, dt);
        } else {
            _playerController.PlayerChangeState(PlayerState.Idle);
        }  
    }
}
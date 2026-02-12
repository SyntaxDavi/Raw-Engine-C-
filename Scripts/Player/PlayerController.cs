using Raylib_cs;
using System.Numerics;
using System.Reflection;

// Esse script é responsável por controlar o player
// Era pra ser apenas o cérebro do player
// Não deixar ficar muito grande
public class PlayerController : Entity
{
    public PlayerData _playerData;
    public InputManager _inputManager;
    public CollisionLogic _collisionLogic;
    public GridWorldManager gridWorldManager;
    public TileRegistry _tileRegistry;
    // Construtor com posição específica
    public PlayerController(Vector2 startPos, GridWorldManager worldManager, TileRegistry tileRegistry) : base(startPos, new Vector2(50, 50)) 
    {
        gridWorldManager = worldManager;
        _tileRegistry = tileRegistry;
        Initialize();
        Position = startPos; // Garante que a posição da Entity seja a desejada
    }

    // Construtor padrão
    public PlayerController(GridWorldManager worldManager, TileRegistry tileRegistry) : base(new Vector2(500, 500), new Vector2(50, 50))
    {
        gridWorldManager = worldManager;
        _tileRegistry = tileRegistry;
        Initialize();
    }

    private void Initialize()
    {
        _inputManager = new InputManager();
        _collisionLogic = new CollisionLogic(gridWorldManager, _tileRegistry);
        _playerData = new PlayerData();
        
        // Sincroniza os dados iniciais do PlayerData com a Entity herdada
        this.Radius = _playerData.Radius;
        this.Size = _playerData.Size;
        this.IsActive = _playerData.IsActive;
    }
    
    public void Input(float dt)
    {
        Vector2 direction = _inputManager.GetInput();

        if (direction != Vector2.Zero)
        {
            Vector2 moveAmount = direction * _playerData.BaseSpeed * dt;
            
            // Tenta mover no X
            Vector2 nextPosX = new Vector2(Position.X + moveAmount.X, Position.Y);
            if (_collisionLogic.IsTileWalkable(nextPosX)) 
            {
                Position.X = nextPosX.X;
            }
            
            // Tenta mover no Y
            Vector2 nextPosY = new Vector2(Position.X, Position.Y + moveAmount.Y);
            if (_collisionLogic.IsTileWalkable(nextPosY)) 
            {
                Position.Y = nextPosY.Y;
            }
        }

        // Garante que o player não saia das bordas do mapa (SSoT do grid)
        _collisionLogic.ClampToWorld(ref Position, ref Radius);           
    }

    public override void Update(float dt)
    {
        Input(dt);
    }
}
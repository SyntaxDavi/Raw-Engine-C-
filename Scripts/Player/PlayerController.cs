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
    // Construtor com posição específica
    public PlayerController(Vector2 startPos, GridWorldManager worldManager) : base(startPos, new Vector2(50, 50)) 
    {
        gridWorldManager = worldManager;
        Initialize();
        Position = startPos; // Garante que a posição da Entity seja a desejada
    }

    // Construtor padrão
    public PlayerController(GridWorldManager worldManager) : base(new Vector2(500, 500), new Vector2(50, 50))
    {
        gridWorldManager = worldManager;
        Initialize();
    }

    private void Initialize()
    {
        _inputManager = new InputManager();
        _collisionLogic = new CollisionLogic(gridWorldManager);
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
            Position += direction * _playerData.BaseSpeed * dt;
        }

        // Passamos a Position e Radius da Entity por referência
        _collisionLogic.ClampToWorld(ref Position, ref Radius);           
    }

    public override void Draw()
    {
        Raylib.DrawRectangleV(Position, Size, Color.Red);
        Raylib.DrawText($"Posição X: {Position.X}", 30, 20, 20, Color.White);
        Raylib.DrawText($"Posição Y: {Position.Y}", 30, 40, 20, Color.White);
        Raylib.DrawText("Use WASD keys to move the circle", 30, 60, 20, Color.White);
    }

        public override void Update(float dt)
        {
            Input(dt);
        }
}
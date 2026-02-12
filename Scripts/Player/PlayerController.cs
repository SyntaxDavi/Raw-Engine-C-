using Raylib_cs;
using System.Numerics;
using System.Reflection;

// Esse script é responsável por controlar o player
// Era pra ser apenas o cérebro do player
// Não deixar ficar muito grande
public class PlayerController : Entity
{
    public float BaseSpeed = 200f;
    public InputManager inputManager;
    public CollisionLogic _collisionLogic;

    public PlayerController(Vector2 startPos) : base(startPos, new Vector2(50, 50)) 
    {
        Initialize();
    }

    public PlayerController() : base(new Vector2(500, 500), new Vector2(50, 50))
    {
        Initialize();
    }

    private void Initialize()
    {
        inputManager = new InputManager();
        _collisionLogic = new CollisionLogic();
        Radius = 25f;
        BaseSpeed = 200f;
        IsActive = true;
        IsVisible = true;
        IsCollidable = true;
    }
    
        public void Input(float dt)
        {
         Vector2 direction = inputManager.GetInput();

            if(direction != Vector2.Zero)
                {
                    Position += direction * BaseSpeed * dt;
                }
                _collisionLogic.CheckBounds(ref Position, ref Radius);           
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
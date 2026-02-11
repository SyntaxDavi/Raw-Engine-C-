using Raylib_cs;
using System.Numerics;
using System.Reflection;
public class Player
{
    public float BaseSpeed = 200f;
    public float Radius = 25f;
    public Vector2 Position;
    public InputManager inputManager;

    public Player()
    {
        Position = new Vector2(960, 540);
        inputManager = new InputManager();
    }
    
        public void Input(float dt, CollisionLogic collisionLogic)
        {
         Vector2 direction = inputManager.GetInput();

            if(direction != Vector2.Zero)
                {
                    Position += direction * BaseSpeed * dt;
                }
                collisionLogic.CheckBounds(ref Position, ref Radius);           
        }

        public void Draw()
        {
            Raylib.DrawCircleV(Position, Radius, Color.Red);
            Raylib.DrawText($"Posição X: {Position.X}", 30, 20, 20, Color.White);
            Raylib.DrawText($"Posição Y: {Position.Y}", 30, 40, 20, Color.White);
            Raylib.DrawText("Use WASD keys to move the circle", 30, 60, 20, Color.White);
        }
}
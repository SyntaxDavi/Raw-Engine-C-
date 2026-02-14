using System.Numerics;
using Raylib_cs;

public class PlayerData
{
    public float BaseSpeed = 300f;
    public Vector2 Position = new Vector2(0, 0);
    public Vector2 Size = new Vector2(128, 128);
    public Vector2 CollisionSize = new Vector2(32, 32);
    public Vector2 CollisionOffset = new Vector2(-16, -32);
    
    public int Radius = 25;
    public bool IsActive = true;
    public bool IsVisible = true;
    public bool IsCollidable = true;
    public bool IsTrigger = false;
}
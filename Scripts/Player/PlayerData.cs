using System.Numerics;
using Raylib_cs;

public class PlayerData
{
    public float BaseSpeed = 350f;
    public Vector2 Position = new Vector2(500, 500);
    public Vector2 Size = new Vector2(32, 96);
    public int Radius = 25;
    public bool IsActive = true;
    public bool IsVisible = true;
    public bool IsCollidable = true;
    public bool IsTrigger = false;
}
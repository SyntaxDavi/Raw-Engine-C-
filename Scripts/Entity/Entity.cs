using System.Numerics;
using Raylib_cs;

public abstract class Entity
{
    public Vector2 Position;
    public Vector2 Size;
    public Vector2 Pivot;

    public int Radius;
    public float Speed;
    public float Rotation;

    public bool IsActive;
    public bool IsVisible;
    public bool IsCollidable;
    public bool IsTrigger;

    public Entity(Vector2 StartPos, Vector2 size)
    {
        Position = StartPos;
        Size = size;
        Pivot = new Vector2(0.5f,1.0f);
    }
    public abstract void Update(float dt);

    public Rectangle GetBounds()
    {
        return new Rectangle(Position.X - Size.X * Pivot.X, Position.Y - Size.Y * Pivot.Y, Size.X, Size.Y);
    }
}
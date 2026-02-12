using Raylib_cs;
using System.Numerics;

public abstract class GameObjects
{
    public Vector2 Position;
    public bool IsActive;
    public float Rotation;
    public Vector2 Scale = new Vector2(1, 1);
    
    public virtual void Update (float dt){}
    public virtual void Draw () {}    
}
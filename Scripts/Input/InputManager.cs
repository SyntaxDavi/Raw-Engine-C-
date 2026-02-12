using Raylib_cs;
using System.Numerics;
using System.Data;


public class InputManager
{
    const KeyboardKey upKey = KeyboardKey.W;
    const KeyboardKey downKey = KeyboardKey.S;
    const KeyboardKey leftKey = KeyboardKey.A;
    const KeyboardKey rightKey = KeyboardKey.D;
    const KeyboardKey exitKey = KeyboardKey.Escape;
    const KeyboardKey interactKey = KeyboardKey.E;
    public const KeyboardKey fullscreenKey = KeyboardKey.F11;
 
    public static bool IsKeyPressed(KeyboardKey key)
    {
        return Raylib.IsKeyPressed(key);
    }

    public Vector2 GetInput()
    {
        Vector2 input = new Vector2(0, 0);

        if (Raylib.IsKeyDown(upKey))
            input.Y -= 1;
        if (Raylib.IsKeyDown(downKey))
            input.Y += 1;
        if (Raylib.IsKeyDown(leftKey))
            input.X -= 1;
        if (Raylib.IsKeyDown(rightKey))
            input.X += 1;

        if (input != Vector2.Zero)
            input = Vector2.Normalize(input);

        return input;
    }
}
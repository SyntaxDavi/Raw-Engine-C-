using Raylib_cs;
using System.Numerics;

public class Application
{
    public int ScreenWidth {get; private set;}
    public int ScreenHeight {get; private set;}

    public void Init()
    {
        Raylib.InitWindow(1280, 720, "Game");
        Raylib.SetTargetFPS(60);
        UpdateDimensions();
    }

    public void ToggleFullscreen()
    {
        Raylib.ToggleFullscreen();
        UpdateDimensions();
    }

    private void UpdateDimensions()
    {
        ScreenWidth = Raylib.GetScreenWidth();
        ScreenHeight = Raylib.GetScreenHeight();
    }
}
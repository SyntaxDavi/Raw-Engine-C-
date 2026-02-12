using Raylib_cs;
using System.Data;
using System.Numerics;

//Esse script tem a função de iniciar o jogo e manter o loop principal

public static class Program
{
    static void Main()
    {
        Application app = new Application();
        app.Init();

        Game game = new Game(app.ScreenWidth, app.ScreenHeight);

       while(!Raylib.WindowShouldClose())
       {
            float dt = Raylib.GetFrameTime();

            if (InputManager.IsKeyPressed(InputManager.fullscreenKey))
            {
                app.ToggleFullscreen();
            }

            game.Update(dt);
            game.Draw();
       }
        Raylib.CloseWindow();
    }
}
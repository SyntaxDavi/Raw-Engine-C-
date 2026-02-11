using Raylib_cs;
using System.Data;
using System.Numerics;

public static class Program
{
    static void Main()
    {
        MainCamera mainCamera = new MainCamera();

        Raylib.InitWindow(MainCamera.screenWidth, MainCamera.screenHeight, "MyGame");
        Raylib.SetTargetFPS(60);

        Game game = new Game();
        mainCamera.Init(game._player);

       while(!Raylib.WindowShouldClose())
       {
            float dt = Raylib.GetFrameTime();

            game.Update(dt);
            mainCamera.Update();

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            Raylib.BeginMode2D(mainCamera.camera);

            Raylib.DrawRectangle(0, 0, game._collisionLogic.MainSceneData.XSize,
            game._collisionLogic.MainSceneData.YSize,Color.Green);
            game._player.Draw();

            Raylib.EndMode2D();
            Raylib.EndDrawing();
       }
        Raylib.CloseWindow();
    }
}
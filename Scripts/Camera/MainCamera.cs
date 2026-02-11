    using Raylib_cs;
    using System.Numerics;

    public class MainCamera
    {
        public const int screenWidth = 1920;
        public const int screenHeight = 1080;
        public Camera2D camera = new Camera2D();
        private Player player;

        public float zoom = 1.0f;
        public float rotation = 0.0f;
        public float Delay = 3.0f;
        public void Init(Player player)
        {
            this.player = player;

            camera.Target = new Vector2(player.Position.X + 20, player.Position.Y + 20);
            camera.Offset = new Vector2(screenWidth / 2, screenHeight / 2);
            camera.Rotation = rotation;
            camera.Zoom = zoom;
        }

        public void Update()
        {
            camera.Target = new Vector2(player.Position.X + 20, player.Position.Y + 20);
        }
    }

    using Raylib_cs;
    using System.Numerics;

    public class MainCamera
    {
        public Camera2D _camera;
        private CameraFollow _cameraFollow;

        public void Init(PlayerController player, int screenWidth, int screenHeight, GridWorldManager world)
        {
            _camera = new Camera2D();
            _camera.Offset = new Vector2(screenWidth / 2, screenHeight / 2);
            _camera.Zoom = 1f;
            _camera.Rotation = 0f;

            _cameraFollow = new CameraFollow();
            _cameraFollow.Init(player, world, screenWidth, screenHeight);
        }

        public void Update(float dt)
        {
            _cameraFollow.Update(ref _camera, dt);    
        }
    }

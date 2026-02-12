    using Raylib_cs;
    using System.Numerics;

    public class MainCamera
    {
        public Camera2D _camera;
        private CameraFollow _cameraFollow;

        public void Init(PlayerController player, int screenWidth, int screenHeight)
        {
            _camera = new Camera2D();
            _camera.Offset = new Vector2(screenWidth / 2, screenHeight / 2);
            _camera.Zoom = 0.5f;
            _camera.Rotation = 0f;

            _cameraFollow = new CameraFollow();
            _cameraFollow.Init(player);
        }

        public void Update()
        {
            _cameraFollow.Update(ref _camera);    
        }
    }

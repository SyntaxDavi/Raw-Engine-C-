using Raylib_cs;
using System.Numerics;

public class CameraFollow
{
    private PlayerController _player;
    private GridWorldManager _world;
    private float _baseOffsetX = 5f;
    private float _baseOffsetY = -25f; 
    private int _screenWidth;
    private int _screenHeight;
    private float _margin = 175f; 
    private float _SmoothSpeed = 5f; 

    public void Init(PlayerController player, GridWorldManager world, int screenWidth, int screenHeight)
    {
        _player = player;
        _world = world;
        _screenWidth = screenWidth;
        _screenHeight = screenHeight;
    }

    public void Update(ref Camera2D camera, float dt)
    {
        if (_player == null) return;

        // 1. Alvo desejado (jogador + offset)
        Vector2 desiredTarget = new Vector2(
            _player.Position.X + _baseOffsetX,
            _player.Position.Y + _baseOffsetY
        );

        // 2. Clamp nos limites do mapa
        Vector2 clampedTarget = ClampCamera(desiredTarget, camera);

        // 3. Suavização orgânica usando LERP
        // Quanto maior o _SmoothSpeed, mais rápido a câmera chega no alvo.
        camera.Target = Vector2.Lerp(camera.Target, clampedTarget, _SmoothSpeed * dt);
    }

    private Vector2 ClampCamera(Vector2 target, Camera2D camera)
    {
        float zoom = camera.Zoom;
        
        float minX = (camera.Offset.X / zoom) - _margin;
        float maxX = (_world.WorldWidth - (camera.Offset.X / zoom)) + _margin;
        
        float minY = (camera.Offset.Y / zoom) - _margin;
        float maxY = (_world.WorldHeight - (camera.Offset.Y / zoom)) + _margin;

        if (_world.WorldWidth < (_screenWidth / zoom)) 
            target.X = _world.WorldWidth / 2f;
        else 
            target.X = Math.Clamp(target.X, minX, maxX);

        if (_world.WorldHeight < (_screenHeight / zoom)) 
            target.Y = _world.WorldHeight / 2f;
        else 
            target.Y = Math.Clamp(target.Y, minY, maxY);

        return target;
    }
}
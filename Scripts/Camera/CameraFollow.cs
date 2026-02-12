using Raylib_cs;
using System.Numerics;

public class CameraFollow
{
    private PlayerController _player;
    private float _offset = 20f;

    public void Init(PlayerController player)
    {
        _player = player;
    }

    public void Update(ref Camera2D camera)
    {
        if (_player == null) return;

        camera.Target = new Vector2(
            _player.Position.X + _offset,
            _player.Position.Y + _offset
        );
    }
}
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

public class PlayerAnimator
{
    private SpriteAnimator _animator;
    private Texture2D _spriteSheet;

    public void Init()
    {
        _animator = new SpriteAnimator();
        
        _spriteSheet = AssetManager.Instance.LoadTexture("player_sheet", "TileSetsPng/Ase/Player_Sheet.png");

        var idleFrames = new List<Rectangle>{
            new Rectangle(0, 0, 64, 64),
            new Rectangle(64, 0, 64, 64),
            new Rectangle(128, 0, 64, 64),
            new Rectangle(192, 0, 64, 64)
        };
        _animator.AddAnimation("Idle", new Animation(idleFrames, 0.15f));

        var walkingFrames = new List<Rectangle>{
            new Rectangle(256, 0, 64, 64),
            new Rectangle(320, 0, 64, 64),
            new Rectangle(384, 0, 64, 64)
        };
        _animator.AddAnimation("Walking", new Animation(walkingFrames, 0.12f));
    }

    public void UpdateState(PlayerState state, float dt)
    {
        _animator.SetCurrentAnimation(state.ToString());
        _animator.Update(dt);
    }

    public void Draw(Vector2 position, Vector2 size, Vector2 pivot, float rotation)
    {
        Rectangle source = _animator.GetCurrentFrame();
        
        // DEST: Onde na tela o sprite vai aparecer e em qual tamanho
        Rectangle dest = new Rectangle(position.X, position.Y, size.X, size.Y);
        
        // ORIGIN: O ponto de rotação/ancoragem relativo ao tamanho do sprite (Size * Pivot)
        Vector2 origin = new Vector2(size.X * pivot.X, size.Y * pivot.Y);

        // DrawTexturePro permite escalar a source de 64x64 para o dest (ex: 32x96)
        Raylib.DrawTexturePro(_spriteSheet, source, dest, origin, rotation, Color.White);
    }
}
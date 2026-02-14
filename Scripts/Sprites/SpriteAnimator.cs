using System;
using System.Collections.Generic;
using Raylib_cs;

public class SpriteAnimator
{
    private Dictionary<string, Animation> _animations = new Dictionary<string, Animation>();
    private Animation? _currentAnimation;
    private string _currentAnimationName = "";
    private float _timer;
    private int _currentFrame;

    public void AddAnimation(string name, Animation animation)
    {
        if (!_animations.ContainsKey(name))
        {
            _animations.Add(name, animation);
        }
    }

    public void SetCurrentAnimation(string name)
    {
        if (_currentAnimationName == name) return;

        if (_animations.TryGetValue(name, out var animation))
        {
            _currentAnimation = animation;
            _currentAnimationName = name;
            _currentFrame = 0;
            _timer = 0;
        }
        else
        {
            Console.WriteLine($"Erro: Animação '{name}' não encontrada no Animator.");
        }
    }

    public void Update(float dt)
    {
        if (_currentAnimation == null) return;

        _timer += dt;
        if (_timer >= _currentAnimation.FrameTime)
        {
            _timer = 0;
            _currentFrame++;

            if (_currentFrame >= _currentAnimation.Frames.Count)
            {
                if (_currentAnimation.IsLooping)
                {
                    _currentFrame = 0;
                }
                else
                {
                    // Mantém no último frame se não for loop
                    _currentFrame = _currentAnimation.Frames.Count - 1;
                }
            }
        }
    }

    public Rectangle GetCurrentFrame()
    {
        if (_currentAnimation == null || _currentAnimation.Frames.Count == 0)
        {
            // Retorna um retângulo vazio ou padrão se nada estiver definido
            return new Rectangle(0, 0, 0, 0);
        }
        return _currentAnimation.Frames[_currentFrame];
    }
}
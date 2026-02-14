using System.Collections.Generic;
using Raylib_cs;

public class Animation
{
    public List<Rectangle> Frames { get; set; } = new List<Rectangle>();
    public float FrameTime { get; set; } = 0.1f; // Segundos por frame
    public bool IsLooping { get; set; } = true;

    public Animation(List<Rectangle> frames, float frameTime, bool isLooping = true)
    {
        Frames = frames;
        FrameTime = frameTime;
        IsLooping = isLooping;
    }
}

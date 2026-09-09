using Express.Scene.Objects;
using Microsoft.Xna.Framework;
using System.Collections.Generic;


namespace Express.Graphics;
/// <summary>
/// Defines a frame of an animation sprite.
/// </summary>
public class AnimatedSprite
{
    protected List<AnimatedSpriteFrame> _frames; // The frames of the animation
    protected double _duration; // The duration of the animation
    protected bool _looping; // Boolean whether the animation loops or not
    protected Lifetime _lifeTime;

    public AnimatedSprite(string src, Rectangle sourceRectange, Vector2 origin, int frames, double duration, bool looping)
    { 
        _duration = duration;
        _looping = looping;

        _frames = new List<AnimatedSpriteFrame>();

        for (int i = 0; i < frames; i++)
        {
            Rectangle frameRectange = new Rectangle(sourceRectange.X + i * sourceRectange.Width, sourceRectange.Y, sourceRectange.Width, sourceRectange.Height);
            _frames.Add(new AnimatedSpriteFrame(new Sprite(src, frameRectange, origin), i * (duration/frames)));
        }
    }


    /// <summary>
    /// Creates a new <see cref="AnimatedSprite"/> that lasts <paramref name="duration"/> ms.
    /// </summary>
    /// <param name="duration">The duration of the animation in ms.</param>
    public AnimatedSprite(double duration)
    {
        _frames = new List<AnimatedSpriteFrame>();
        _duration = duration;
    }
    /// <summary>
    /// The duration of the animation in ms.
    /// </summary>
    public double Duration {
        get => _duration;
        set => _duration = value;
    }
    /// <summary>
    /// Defines whether the animation loops.
    /// </summary>
    public bool Looping { 
        get => _looping;
        set => _looping = value;
    }
    /// <summary>
    /// Sets the looping duration.
    /// </summary>
    /// <param name="duration">The duration of the animation in ms.</param>
    void SetLoopingDuration(double duration)
    { 
        _looping = true;
        _duration = duration;
    }
    /// <summary>
    /// Adds a frame onto the animation.
    /// </summary>
    /// <param name="frame">The frame to be added.</param>
    public void AddFrame(AnimatedSpriteFrame frame) { 
        _frames.Add(frame);
        _frames.Sort((x, y) => x.Start.CompareTo(y.Start));
    }
    /// <summary>
    /// Finds the frame at a given timeframe.
    /// </summary>
    /// <param name="time">The timeframe of the animation.</param>
    /// <returns><see cref="AnimatedSpriteFrame"/> at the given <paramref name="time"/>.</returns>
    public Sprite SpriteAtTime(double time)
    {

        if (_looping)
        {
            
            int loops = (int)System.Math.Floor(time / _duration);
            time -= loops * _duration;
        }
        /*
        else
        {
            if (_lifeTime == null)
            { 
                _lifeTime = new Lifetime(time, _duration);
            }
            time = _lifeTime.Progress;
        }*/

            
        

        for (int i = 0; i < _frames.Count - 1; i++)
        {
            AnimatedSpriteFrame nextFrame = _frames[i + 1];
            if (nextFrame.Start > time)
            {
                AnimatedSpriteFrame frame = _frames[i];
                return frame.Sprite;
            }
        }
        AnimatedSpriteFrame frameDefault = _frames[^1];
        return frameDefault.Sprite;
    }
}

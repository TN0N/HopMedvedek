using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace Express.Graphics;

public class AnimatedSprite
{
    protected List<AnimatedSpriteFrame> _frames;
    protected double _duration;
    protected bool _looping;

    public AnimatedSprite(double duration)
    {
        _frames = new List<AnimatedSpriteFrame>();
        _duration = duration;
    }
    public AnimatedSprite(Texture2D texture, Rectangle sourceRectangle, Vector2 origin, int frames, double duration, bool looping) {
        _frames = new List<AnimatedSpriteFrame>();
        _duration = duration;
        _looping = looping;

        for (double i = 0; i < frames; i++)
        { 
            Sprite frame = new Sprite();
            frame.Texture = texture;
            frame.SourceRectangle = new Rectangle(sourceRectangle.X + (int)i* sourceRectangle.Width, sourceRectangle.Y, sourceRectangle.Width, sourceRectangle.Height);
            frame.Origin = origin;
            _frames.Add(new AnimatedSpriteFrame(frame, _duration * (i/frames)));
        }
    }

    public double Duration {
        get => _duration;
        set => _duration = value;
    }

    public bool Looping { 
        get => _looping;
        set => _looping = value;
    }

    void SetLoopingDuration(double duration)
    { 
        _looping = true;
        _duration = duration;
    }
    public void AddFrame(AnimatedSpriteFrame frame) { 
        _frames.Add(frame);
        _frames.Sort((x, y) => x.Start.CompareTo(y.Start));
    }
    public Sprite SpriteAtTime(double time)
    {
        if (_looping)
        {
            int loops = (int)System.Math.Floor(time / _duration);
            time -= loops * _duration;
        }
        if (time >= Duration)
            return null;
        for (int i = 0; i < _frames.Count - 1; i++)
        { 
            AnimatedSpriteFrame nextFrame = _frames[i+1];
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

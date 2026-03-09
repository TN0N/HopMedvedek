using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Express.Graphics;

public class TextureData : ITextureData
{
    protected string _name;
    protected Sprite _sprite;
    protected Dictionary<Enum, AnimatedSprite> _animation = null;

    protected TextureData()
    {
        _name = "no_texture";
        _sprite = sprite;
        _animation = animation;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }
    public Sprite Sprite
    {
        get => _sprite;
        set => _sprite = value;
    }
    public Dictionary<Enum, AnimatedSprite> Animation
    {
        get => _animation;
        set => _animation = value;
    }
}

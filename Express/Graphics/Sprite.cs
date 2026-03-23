using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Express.Graphics;
/// <summary>
/// Defines a sprite.
/// </summary>
public class Sprite
{
    public SpriteSortMode _spriteSortMode = SpriteSortMode.FrontToBack;
    public BlendState _blendState =null;
    public SamplerState _samplerState = SamplerState.PointClamp;
    public DepthStencilState _depthStencilState = null;
    public RasterizerState _rasterizerState = null;
    public Effect _effect = null;

    public string _src = "no_texture";

    public Rectangle _sourceRectangle; // The source rectangle for the sprite.
    public Vector2 _origin; // The origin for the sprite.


    public Sprite(string src, Rectangle sourceRectange, Vector2 origin)
    { 
        _src = src;
        _sourceRectangle = sourceRectange;
        _origin = origin;
    }
    /// <summary>
    /// The source <see cref="Rectangle"/> of the sprite.
    /// </summary>
    public Rectangle SourceRectangle
    {
        get => _sourceRectangle;
        set => _sourceRectangle = value;
    }
    /// <summary>
    /// The origin of the sprite.
    /// </summary>
    public Vector2 Origin
    {
        get => _origin;
        set => _origin = value;
    }

    public SpriteSortMode SpriteSortMode 
    { 
        get => _spriteSortMode; 
        set => _spriteSortMode = value; 
    }
    public BlendState BlendState 
    { 
        get => _blendState; 
        set => _blendState = value; 
    }
    public SamplerState SamplerState 
    { 
        get => _samplerState; 
        set => _samplerState = value; 
    }
    public DepthStencilState DepthStencilState 
    { 
        get => _depthStencilState; 
        set => _depthStencilState = value; 
    }
    public RasterizerState RasterizerState
    { 
        get => _rasterizerState; 
        set => _rasterizerState = value; 
    }
    public Effect Effect 
    { 
        get => _effect; 
        set => _effect = value; 
    }

    public string Src 
    { 
        get => _src; 
        set => _src = value; 
    }
}

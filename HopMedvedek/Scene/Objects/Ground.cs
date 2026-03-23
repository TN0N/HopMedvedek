using Express.Graphics;
using Express.Scene.Objects.Colliders;
using Express.Scene.Objects.Physical_Properties;
using HopMedvedek.Data;
using HopMedvedek.Scene.Objects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;


public enum GroundState
{ 
    Default
}
public class Ground : GameComponent, ICustomCollider, IAARectangleCollider, ITextured
{
    protected float _width; 
    protected float _height;
    //protected float _mass = 999999999999999999f;
    //protected Sprite _groundSprite = new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_GRASS_TEXTURE, new Rectangle(0, 0, 256, 256), new Vector2(128, 128));

    
    protected Dictionary<Enum, AnimatedSprite> _groundAnimations = new()
    {
        [GroundState.Default] = new AnimatedSprite(HopMedvedekConstants.HOP_MEDVEDEK_GRASS_TEXTURE, new Rectangle(0, 0, 272, 122), new Vector2(136, 61), 6, 1200, true),
    };

    public Ground(Game game) : base(game)
    {
        _width = 408;
        _height = 183;
    }

    protected Vector2 _position = new();
    public float Width
    {
        get => _width;
        set => _width = value;
    }
    public float Height
    {
        get => _height;
        set => _height = value;
    }
    public ref Vector2 Position => ref _position;

    public bool CollidingWith(object item)
    {
        System.Diagnostics.Debug.WriteLine("colliding");
        return false;
    }
    public void CollidedWith(object item)
    {
        if (item is Bear bear)
        {
            bear.Grounded = true;
            //bear.Velocity.Y -= bear.Velocity.Y;
            bear.Jumping = false;
        }
    }
    
    public Sprite Sprite(GameTime gameTime)
    {
        return _groundAnimations[GroundState.Default].SpriteAtTime(gameTime.TotalGameTime.TotalMilliseconds);
    }
    public float LayerDepth => 0.9f;
    /*
    public float Mass
    {
        get => _mass;
        set => _mass = value;
    }*/
}
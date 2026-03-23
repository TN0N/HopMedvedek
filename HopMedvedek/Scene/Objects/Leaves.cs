using Express.Graphics;
using Express.Math;
using Express.Scene.Objects;
using Express.Scene.Objects.Colliders;
using Express.Scene.Objects.Movement;
using Express.Scene.Objects.Physical_Properties;
using Express.Scene.Objects.Rotation;
using HopMedvedek.Data;
using HopMedvedek.Scene.Objects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;


public enum LeavesState
{
    Default,
    BearLanding,
    BearLanded
}
public class Leaves : GameComponent, ICustomCollider, IConvexCollider, IPosition, ICustomDrawRect, ITextured, IRotatable, IAngularMass, IAngularVelocity//, ICustomOrigin
{
    protected float _width;
    protected float _height;

    protected List<Vector2> _boundVerticies;
    protected ConvexPolygon _bounds;

    protected Vector2 _pivotPoint;
    protected float _angularMass = 1f;

    protected float _rotationAngle;
    protected float _angularVelocity;

    protected float _drawWidth;
    protected float _drawHeight;

    protected bool _playerLanded;
    protected Lifetime _stateLifeTime;

    protected Sprite _defaultSprite = new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_NATURE_TEXTURE, new Rectangle(0, 37, 62, 33), new Vector2(31, 16));
    protected Sprite _bearLanededSprite = new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_NATURE_TEXTURE, new Rectangle(372, 37, 62, 33), new Vector2(31, 16));
    //protected Sprite _groundSprite = new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_GRASS_TEXTURE, new Rectangle(0, 0, 256, 256), new Vector2(128, 128));
    protected LeavesState _state;

    protected Dictionary<Enum, AnimatedSprite> _leafAnimations = new()
    {
        [LeavesState.BearLanding] = new AnimatedSprite(HopMedvedekConstants.HOP_MEDVEDEK_NATURE_TEXTURE, new Rectangle(0, 37, 62, 33), new Vector2(31, 16), 7, HopMedvedekConstants.HOP_MEDVEDEK_LEAVES_BEAR_LANDED_ANIMATION_DURATION, true),
    };

    public Leaves(Game game) : base(game)
    {
        _width = 40;
        _height = 10;

        _drawWidth = 62;
        _drawHeight = 34;

        _rotationAngle =0f;
        _angularVelocity = 0f;

        _state = LeavesState.Default;
        _playerLanded = false;

        _pivotPoint = new();
        _boundVerticies = new List<Vector2>
        {
            
            new Vector2(-_width, -_height),
            new Vector2(_width, -_height),
            new Vector2(_width, _height),
            new Vector2(-_width, _height),
        };
        _bounds = new ConvexPolygon(_boundVerticies);
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

    public float CustomWidth
    {
        get => _drawWidth;
        set => _drawWidth = value;
    }
    public float CustomHeight
    {
        get => _drawHeight;
        set => _drawHeight = value;
    }
    public ref Vector2 Position => ref _position;



    public bool CollidingWith(object item, bool defaultValue = false)
    {
        if (item is Bear bear)
        {
            float bearBottom = bear.Position.Y + bear.Height / 2;
            float leafTop = _position.Y - _height / 2;

            // Only collide if falling AND above the leaf
            if (bear.Velocity.Y > 0 && bearBottom <= leafTop + 5) // small tolerance
            {
                bear.Velocity.Y = 0;
                bear.Position.Y = leafTop - bear.Height / 2; // snap on top
                return true;
            }
        }
        return false;
    }
    private void ChangeState(GameTime gameTime)
    {
        if (_state == LeavesState.Default)
        {
            if (_playerLanded == true && _stateLifeTime == null)
            {
                _stateLifeTime = new Lifetime(gameTime.TotalGameTime.TotalMilliseconds, (HopMedvedekConstants.HOP_MEDVEDEK_LEAVES_BEAR_LANDED_ANIMATION_DURATION)/1000);
                _state = LeavesState.BearLanding;
            }
        }
        if (_state == LeavesState.BearLanding)
        {
            if (_stateLifeTime.IsAlive)
                _stateLifeTime.Update(gameTime);
            else
                _state = LeavesState.BearLanded;
        }
    }
    public override void Update(GameTime gameTime)
    {
        ChangeState(gameTime);
    }
    public void CollidedWith(object item)
    {
        
        if (item is Bear bear)
        {
            bear.Grounded = true;
            _playerLanded = true;
            //bear.Velocity.Y -= bear.Velocity.Y;
            bear.Jumping = false;
        }
    }

    public Sprite Sprite(GameTime gameTime)
    {
        switch (_state)
        {
            case LeavesState.Default: return _defaultSprite;
            case LeavesState.BearLanding: return _leafAnimations[_state].SpriteAtTime(gameTime.TotalGameTime.TotalMilliseconds);
            case LeavesState.BearLanded: return _bearLanededSprite;
            default: return _defaultSprite;
        }
    }
    public float LayerDepth => 0.6f;
    public float RotationAngle
    {
        get => _rotationAngle;
        set => _rotationAngle = value;
    }
    public float AngularVelocity
    {
        get => _angularVelocity;
        set => _angularVelocity = value;
    }
    
    public Vector2 PivotPoint
    { 
        get => _pivotPoint;
        set => _pivotPoint = value;
    }
    public float AngularMass
    {
        get => _angularMass;
        set => _angularMass = value;
    }
    public ConvexPolygon Bounds
    { 
        get => _bounds;
        set => _bounds = value;
    }
}
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
public class Leaves : GameComponent, ICustomCollider, ICoefficientOfRestitution, IAARectangleCollider, IPosition, ICustomDrawRect, ITextured, IRotatable
{
    protected float _leafBottomBound;
    protected float _leafTopBound;

    protected float _width;
    protected float _height;
    protected float _coefficientOfRestitution;
    protected List<Vector2> _boundVerticies;
    protected ConvexPolygon _bounds;

    protected Bear _bear;

    protected Vector2 _pivotPoint;
    protected float _angularMass;

    protected float _rotationAngle;
    protected float _angularVelocity;

    protected float _drawWidth;
    protected float _drawHeight;

    protected bool _playerLanded;
    protected Lifetime _stateLifeTime;

    protected Sprite _defaultSprite = new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_NATURE_TEXTURE, new Rectangle(0, 37, 62, 33), new Vector2(31, 16));
    protected Sprite _bearLanededSprite = new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_NATURE_TEXTURE, new Rectangle(372, 37, 62, 33), new Vector2(31, 16));
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

        _angularMass = 125000f;
        _rotationAngle =0f;
        _angularVelocity = 0f;

        _coefficientOfRestitution = 0f;
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

    public float CoefficientOfRestitution
    {
        get => _coefficientOfRestitution;
        set => _coefficientOfRestitution = value;
    }

    public bool CollidingWith(object item, bool defaultValue = false)
    {
        
        if (item is Bear bear)
        {
            float bearBottom = bear.Position.Y + bear.Height / 2;
            float leafTop = _position.Y - _height / 2;

            if (bear.Velocity.Y > 0 && bearBottom <= leafTop + 5)
                return true;
        }
        return false;
    }
    private void ChangeState(GameTime gameTime)
    {
        if (_state == LeavesState.Default)
        {
            if (_playerLanded == true && (_stateLifeTime == null || !_stateLifeTime.IsAlive))
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
        if (_state == LeavesState.BearLanded)
        { 
            if (!_playerLanded)
                _state = LeavesState.Default;
        }
    }
    public override void Update(GameTime gameTime)
    {
        bool side = (_position.X <= Game.Window.ClientBounds.Width/2)? false : true;
        float angle = 0.05f;
        float speed = 1f;

        if (side)
        {
            if (_playerLanded)
            {
                _angularVelocity = speed;
                if (_rotationAngle >= angle)
                {
                    _rotationAngle = angle;
                    _angularVelocity = 0;
                }
            }
            else
            {
                _angularVelocity = -speed;
                if (_rotationAngle <= 0)
                {
                    _rotationAngle = 0f;
                    _angularVelocity = 0;
                }

            }

        }
        else
        {
            if (_playerLanded)
            {
                _angularVelocity = -speed;
                if (_rotationAngle <= -angle)
                {
                    _rotationAngle = -angle;
                    _angularVelocity = 0;
                }
            }
            else
            {
                _angularVelocity = speed;
                if (_rotationAngle >= 0)
                {
                    _rotationAngle = 0f;
                    _angularVelocity = 0;
                }

            }
        }
        if (_bear is not null && (_bear.Velocity.Y < 0 || _bear.Velocity.Y > 100))
            _playerLanded = false;
        ChangeState(gameTime);
    }
    public void CollidedWith(object item)
    {
        
        if (item is Bear bear)
        {
            bear.Grounded = true;
            _playerLanded = true;
            bear.Jumping = false;

            _bear = bear;
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
    public float LayerDepth => 0.7f;
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
    public Boolean PlayerLanded
    {
        get => _playerLanded;
    }
}
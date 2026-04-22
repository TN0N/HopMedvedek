using Express.Graphics;
using Express.Scene.Objects.Colliders;
using Express.Scene.Objects.Movement;
using Express.Scene.Objects.Physical_Properties;
using Express.Scene.Objects.Rotation;
using Express.Scene.Objects.Shapes;
using HopMedvedek.Data;
using Microsoft.Xna.Framework;

namespace HopMedvedek.Scene.Objects;

public class Entity : GameComponent, IMass, IMovable, IAARectangleCollider, IRectangleSize, ITextured, ICoefficientOfRestitution, IAngularVelocity, IRotatable
{
    protected float _mass;
    protected Vector2 _position;
    protected Vector2 _velocity;
    protected Vector2 _acceleration;
    protected Vector2 _decay;
    protected float _width;
    protected float _height;
    protected Sprite _sprite;
    protected float _layerDepth;
    protected float _coefficientOfRestitution;
    protected float _angularVelocity;
    protected float _rotationAngle;
    protected Vector2 _pivotPoint;
    protected bool _facing;

    public Entity(Game game) : base(game)
    {
        _mass = 1.0f;
        _width = 2f;
        _height = 2f;
        _layerDepth = 0.1f;
        _facing = true;

        _velocity = new();
        _acceleration = new();
        _position = new();
        _decay = new Vector2(0.9f, 1f);
        _sprite = new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_DEFAULT_TEXTURE, new Rectangle(0, 0, 2, 2), new Vector2(1, 1));
        _coefficientOfRestitution = 0.1f;

        _angularVelocity = 0f;
        _rotationAngle = 0f;
        _pivotPoint = new Vector2(_width / 2, _height / 2);
    }

    public float Mass { 
        get => _mass; 
        set => _mass = value;
    }

    public ref Vector2 Position => ref _position;
    public ref Vector2 Velocity => ref _velocity;
    public ref Vector2 Acceleration => ref _acceleration;
    public ref Vector2 Decay => ref _decay;

    public float Width {
        get => _width;
        set => _width = value;
    }
    public float Height
    {
        get => _height;
        set => _height = value;
    }
    public float LayerDepth
    {
        get => _layerDepth;
        set => _layerDepth = value;
    }
    public float CoefficientOfRestitution
    {
        get => _coefficientOfRestitution;
        set => _coefficientOfRestitution = value;
    }
    public virtual Sprite Sprite(GameTime gameTime)
    {
        return _sprite;
    }
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
    public bool Facing
    { 
        get => (_velocity.X >= 0);
    }
}

using Express.Graphics;
using Express.Scene.Objects.Movement;
using Express.Scene.Objects.Rotation;
using Express.Scene.Objects.Shapes;
using Microsoft.Xna.Framework;

namespace HopMedvedek.Gui.Elements;

public class Image : IRectangleSize, IPosition, ITextured, IRotatable, IMovable//, ICustomOrigin
{
    protected float _width;
    protected float _height;
    protected float _rotationAngle;
    protected float _angularVelocity;
    protected Vector2 _pivotPoint;
    protected float _layerDepth;
    protected Vector2 _velocity;
    protected Vector2 _acceleration;
    protected Vector2 _decay;
    protected bool _facing;
    protected Sprite _sprite;
    protected Vector2 _position;
    protected AnimatedSprite _animatedSprite;
    protected Color _color;

    public Image(Sprite sprite, Rectangle dstRectangle)
    {

        _width = dstRectangle.Width;
        _height = dstRectangle.Height;
        _position = new Vector2(dstRectangle.X, dstRectangle.Y);
        _layerDepth = 0.1f;
        _sprite = sprite;
        _color = Color.White;
    }
    public Image(AnimatedSprite animatedSprite, Rectangle dstRectangle)
    {
        _width = dstRectangle.Width;
        _height = dstRectangle.Height;
        _position = new Vector2(dstRectangle.X, dstRectangle.Y);
        _layerDepth = 0.1f;
        _animatedSprite = animatedSprite;
        _color = Color.White;
    }

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

    public Sprite Sprite(GameTime gameTime)
    {
        if (_animatedSprite != null)
            return _animatedSprite.SpriteAtTime(gameTime.TotalGameTime.TotalMilliseconds);
        return _sprite;
    }
    public float LayerDepth {
        get => _layerDepth;
        set => _layerDepth = value;

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
    public ref Vector2 Velocity => ref _velocity;

    public ref Vector2 Acceleration => ref _acceleration;

    public ref Vector2 Decay => ref _decay;

    public bool Facing
    {
        get => _facing;
        set => _facing = value;
    }
    public Color Color
    {
        get => _color;
        set => _color = value;
    }

}

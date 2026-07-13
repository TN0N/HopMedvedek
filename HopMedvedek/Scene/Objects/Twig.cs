using Express.Graphics;
using Express.Scene.Objects.Movement;
using Express.Scene.Objects.Rotation;
using Express.Scene.Objects.Shapes;
using HopMedvedek.Data;
using Microsoft.Xna.Framework;

namespace HopMedvedek.Scene.Objects;

public class Twig : IRectangleSize, IPosition, ITextured, IRotatable
{
    protected float _width;
    protected float _height;
    protected float _rotationAngle;
    protected float _angularVelocity;
    protected Vector2 _pivotPoint;
    protected Color _color;

    protected Sprite _twigSprite;
    protected Vector2 _position;

    public Twig(int width)
    {
        //_angularVelocity = 1f;
        //_rotationAngle = 2f;
        _width = width;
        _height = 7;
        _color = Color.White;
        _position = new();
        _twigSprite = new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_NATURE_TEXTURE, new Rectangle(45, 4, 4, 7), new Vector2(2, 3));
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
        return _twigSprite;
    }
    public float LayerDepth => 0.5f;
    
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
    public Color Color
    {
        get => _color;
        set => _color = value;
    }
}

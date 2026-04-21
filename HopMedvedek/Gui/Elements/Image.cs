using Express.Graphics;
using Express.Scene.Objects.Movement;
using Express.Scene.Objects.Rotation;
using Express.Scene.Objects.Shapes;
using Microsoft.Xna.Framework;

namespace HopMedvedek.Gui.Elements;

public class Image : IRectangleSize, IPosition, ITextured, IRotatable//, ICustomOrigin
{
    protected float _width;
    protected float _height;
    protected float _rotationAngle;
    protected float _angularVelocity;
    protected Vector2 _pivotPoint;
    protected float _layerDepth;
    //protected Vector2 _origin;
    protected Sprite _sprite;
    protected Vector2 _position;

    public Image(Sprite sprite, Rectangle dstRectangle/*, Vector2 Origin*/)
    {
        //_angularVelocity = 1f;
        //_rotationAngle = 2f;
        //_origin = Origin;
        _width = dstRectangle.Width;
        _height = dstRectangle.Height;
        _position = new Vector2(dstRectangle.X, dstRectangle.Y);
        _layerDepth = 0.1f;
        _sprite = sprite;
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
    /*public Vector2 CustomOrigin
    {
        get => _origin;
        set => _origin = value;
    }*/
}

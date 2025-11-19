using Express.Scene.Objects.Movement;
using Express.Scene.Objects.Shapes;
using Microsoft.Xna.Framework;

public class Ground : IRectangleSize, IPosition
{
    protected float _width = 16;
    protected float _height = 16;

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
}
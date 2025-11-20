using Express.Scene.Objects.Colliders;
using Express.Scene.Objects.Movement;
using Express.Scene.Objects.Physical_Properties;
using Express.Scene.Objects.Shapes;
using HopMedvedek.Scene.Objects;
using Microsoft.Xna.Framework;

public class Ground : IAARectangleCollider, ICustomCollider
{
    protected float _width = 320;
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

    public bool CollidingWith(object item)
    {
        System.Diagnostics.Debug.WriteLine("colliding");
        return true;
    }
    public void CollidedWith(object item)
    {
        if (item is Bear bear)
        {
            //bear.Grounded = true;
            bear.Velocity.Y -= bear.Velocity.Y;
            bear.Jumping = false;
        }
    }
}
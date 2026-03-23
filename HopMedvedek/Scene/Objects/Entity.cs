using Express.Scene.Objects.Movement;
using Express.Scene.Objects.Physical_Properties;
using Microsoft.Xna.Framework;

namespace HopMedvedek.Scene.Objects;

public class Entity : GameComponent, IMass, IMovable
{
    protected float _mass = 1.0f;
    protected Vector2 _position;
    protected Vector2 _velocity;
    protected Vector2 _acceleration;
    protected Vector2 _decay;

    public Entity(Game game) : base(game)
    {
        _mass = 1.0f;
        _velocity = new();
        _acceleration = new();
        _position = new();
        _decay = new Vector2(0.9f, 1f);
    }

    public float Mass { 
        get => _mass; 
        set => _mass = value;
    }

    public ref Vector2 Position => ref _position;
    public ref Vector2 Velocity => ref _velocity;
    public ref Vector2 Acceleration => ref _acceleration;
    public ref Vector2 Decay => ref _decay;

    public bool Facing
    { 
        get => (_velocity.X >= 0);
    }
}

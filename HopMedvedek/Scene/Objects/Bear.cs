using System;
using Express.Scene.Objects.Colliders;
using Express.Scene.Objects.Composites;
using Microsoft.Xna.Framework;

namespace HopMedvedek.Scene.Objects;

public class Bear: IAARectangle
{
    protected Vector2 _velocity = new();
    protected Vector2 _position = new();
    protected Vector2 _acceleration = new();
    protected float _width = 23;
    protected float _height = 32;
    protected float _mass = 1;
    protected float _decay = 0.85f;
    protected float _maxSpeed = 150;
    protected bool _grounded = false;
    protected bool _jumping = false;

    public ref Vector2 Position => ref _position;
    public ref Vector2 Velocity => ref _velocity;
    public ref Vector2 Acceleration => ref _acceleration;
    public ref float Decay => ref _decay;

    public bool Grounded { get => _grounded; set => _grounded = value; }
    public bool Jumping { get => _jumping; set => _jumping = value; }
    public float Mass { get => _mass; set => _mass = value; }
    public float Width { get => _width; set => _width = value; }
    public float Height { get => _height; set => _height = value; }

    public float MaxSpeed { get => _maxSpeed; set => _maxSpeed = value; }

    public enum StateEnum
    {
        Idle,
        JumpUp,
        JumpDown,
        Walk,
        WalkThrow,
        JumpThrow,
        Dazed
    }
    public enum FacingEnum
    {
        Left,
        Right
    }
    protected StateEnum _state;
    protected FacingEnum _facing;

    public StateEnum State { get; set; }
    public FacingEnum Facing { get; set; }
    public bool CollidingWith(object item)
    {
        return true;
    }
    public void CollidedWith(object item)
    {
    }
}

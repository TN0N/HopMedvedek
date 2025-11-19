using System;
using Express.Scene.Objects.Colliders;
using Microsoft.Xna.Framework;

namespace HopMedvedek.Scene.Objects;

public class Bear: IAARectangleCollider, ICustomCollider
{
    protected Vector2 _position = new();
    protected float _width = 112;
    protected float _height = 40;

    public ref Vector2 Position => ref _position;
    public enum StateEnum
    {
        Idle,
        JumpUp,
        JumpDown,
        Walk
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

    public float Width { 
        get => _width; 
        set => _width = value;
    }
    public float Height {
        get => _height;
        set => _height = value;
    }
    public bool CollidingWith(object item)
    {
        return true;
    }
    public void CollidedWith(object item)
    {
        System.Diagnostics.Debug.WriteLine("Collided With");
    }
}

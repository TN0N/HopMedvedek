using Express.Scene.Objects.Colliders;
using Express.Scene.Objects.Composites;
using Microsoft.Xna.Framework;

namespace HopMedvedek.Scene.Objects;

public class Bear: Entity, IAARectangleCollider, ICustomCollider
{
    protected float _width = 23;
    protected float _height = 32;

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

using Express.Graphics;
using Express.Scene.Objects.Colliders;
using Express.Scene.Objects.Movement;
using HopMedvedek.Data;
using HopMedvedek.Level;
using Microsoft.Xna.Framework;
using System.Runtime.InteropServices;

namespace HopMedvedek.Scene.Objects;
public enum CrowAnimationState
{
    Flying
}
public class Crow : Entity, IAARectangleCollider, IPosition, ICustomCollider
{
    protected LevelBase _level;
    protected AnimatedSprite _animation = new AnimatedSprite(HopMedvedekConstants.HOP_MEDVEDEK_CROW_TEXTURE, new Rectangle(0, 0, 53, 42), new Vector2(26, 21), 4, 700, true);

    protected BearState _state = BearState.BearIdle;
    public Crow(Game game, LevelBase level) : base(game)
    {
        _width = 32;
        _height = 42;

        _level = level;

        _mass = 10f;
        _layerDepth = 0.8f;
    }
    public BearState State
    {
        get => _state;
        set => _state = value;
    }
    public LevelBase Level
    {
        get => _level;
        set => _level = value;
    }
    public bool CollidingWith(object item, bool defaultValue = false)
    {
        
        if (item is Bear bear && bear.State != BearState.BearDazed)
        {
            return true;
        }
        return false;
    }
    public void CollidedWith(object item)
    {

        if (item is Bear bear)
        {
            if (bear.Position.Y > _position.Y)
            {
                bear.State = BearState.BearDazed;

                Vector2 _hitDirection = _velocity;
                _hitDirection.Normalize();

                bear.Velocity.X *= -1;
                if (bear.Velocity.Y < 0)
                    bear.Velocity.Y *= -1;
            }
        }

    }

    public override Sprite Sprite(GameTime gameTime)
    {
        return _animation.SpriteAtTime(gameTime.TotalGameTime.TotalMilliseconds);
    }
}

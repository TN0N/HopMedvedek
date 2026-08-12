using Express.Graphics;
using Express.Scene.Objects.Colliders;
using Express.Scene.Objects.Physical_Properties;
using HopMedvedek.Data;
using Microsoft.Xna.Framework;

namespace HopMedvedek.Scene.Objects;

public class Pinecone : Entity, IGravity, ICustomCollider
{
    protected float _gravitationalAcceleration;
    protected AnimatedSprite _animation;
    public Pinecone(Game game) : base(game)
    {
        _width = 30;
        _height = 32;

        _decay = new Vector2(1f, 1f);
        _coefficientOfRestitution = 1f;
        _gravitationalAcceleration = HopMedvedekConstants.HOP_MEDVEDEK_GRAVITATIONAL_ACCELERATION;
        _mass = 0;
        _angularVelocity = 0f;
        _rotationAngle = 0f;
        _layerDepth = 0.8f;

        _animation = new AnimatedSprite(HopMedvedekConstants.HOP_MEDVEDEK_MENU_ELEMENTS, new Rectangle(88, 238, 30, 32), new Vector2(15, 16), 9, 500, true);
    }
    public float GravitationalAcceleration
    {
        get => _gravitationalAcceleration;
        set => _gravitationalAcceleration = value;
    }
    public override Sprite Sprite(GameTime gameTime)
    {
        return _animation.SpriteAtTime(gameTime.TotalGameTime.TotalMilliseconds);
    }
    public bool CollidingWith(object item, bool defaultValue = false)
    {
        if (item is Bear bear)
        {
            return false;
        }
        return true;
    }
}

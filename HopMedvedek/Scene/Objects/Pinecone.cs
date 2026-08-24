using Express.Graphics;
using Express.Scene.Objects.Colliders;
using Express.Scene.Objects.Physical_Properties;
using HopMedvedek.Audio;
using HopMedvedek.Data;
using HopMedvedek.Level;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;

namespace HopMedvedek.Scene.Objects;

public class Pinecone : Entity, IGravity, ICustomCollider
{
    protected float _gravitationalAcceleration;
    protected AnimatedSprite _animation;
    protected SoundEffectInstance _sound;

    protected LevelBase _level;
    public Pinecone(Game game, LevelBase level) : base(game)
    {
        _width = 30;
        _height = 32;
        _level = level;
        _decay = new Vector2(1f, 1f);
        _coefficientOfRestitution = 1f;
        _gravitationalAcceleration = HopMedvedekConstants.HOP_MEDVEDEK_GRAVITATIONAL_ACCELERATION;
        _mass = 0;
        _angularVelocity = 0f;
        _rotationAngle = 0f;
        _layerDepth = 0.8f;

        _animation = new AnimatedSprite(HopMedvedekConstants.HOP_MEDVEDEK_MENU_ELEMENTS, new Rectangle(0, 238, 30, 32), new Vector2(15, 16), 9, 500, true);
        _sound = SoundEngine.Play(SoundEffectType.PineconeFlying, _level.Bear.Position, _position, Options.Options.Current.GameVolume, looping: true);  
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
    public void CollidedWith(object item)
    {
        if (item is Crow crow || item is Ground)
        {
            _level.Scene.Remove(this);
            SoundEngine.Instance.StopSound(_sound);
        }
    }
    public override void Update(GameTime gameTime)
    {
        _pivotPoint = _position;
        _angularVelocity = (_velocity.X > 0) ? 5f : -5f;

        SoundEngine.Instance.Calculate3DSound(_sound, _level.Bear.Position, _position);
        /*
        _sound.Apply3D(_player, _pinecone);

        // Manual distance attenuation (Apply3D won't do this for you)
        float distance = Vector3.Distance(_player.Position, _pinecone.Position);
        const float minDistance = 50f;   // full volume within this range
        const float maxDistance = 600f;  // silent beyond this range

        float attenuation = MathHelper.Clamp(
            1f - (distance - minDistance) / (maxDistance - minDistance),
            0f, 1f);

        _sound.Volume = Options.Options.Current.GameVolume * attenuation;*/
    }
}

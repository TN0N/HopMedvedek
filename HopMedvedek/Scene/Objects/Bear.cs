using Express.Graphics;
using Express.Scene.Objects.Colliders;
using Express.Scene.Objects.Movement;
using Express.Scene.Objects.Physical_Properties;
using HopMedvedek.Data;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace HopMedvedek.Scene.Objects;
public enum BearState { 
    BearIdle,
    BearWalk,
    BearJumpUp,
    BearJumpDown,
    BearWalkThrow,
    BearJumpThrow,
    BearDazed
}
public class Bear : Entity, IAARectangleCollider, IPosition, IGravity
{
    protected bool _grounded;
    protected bool _jumping;
    protected float _gravitationalAcceleration;

    protected BearState _state = BearState.BearIdle;
    public Bear(Game game) : base(game)
    {
        _width = 32;
        _height = 45;
        _grounded = false;
        _jumping = false;

        _coefficientOfRestitution = 0f;
        _gravitationalAcceleration = HopMedvedekConstants.HOP_MEDVEDEK_GRAVITATIONAL_ACCELERATION;
        _mass = 10f;
        _angularVelocity = 0f;
        _rotationAngle = 0f;
        _layerDepth = 0.8f;
    }

    protected Dictionary<Enum, AnimatedSprite> _bearStateAnimations = new()
    {
        [BearState.BearIdle] =      new AnimatedSprite(HopMedvedekConstants.HOP_MEDVEDEK_BEAR_TEXTURE, new Rectangle(0, 0, 23, 32),     new Vector2(12, 16), 12, 700, true),
        [BearState.BearWalk] =      new AnimatedSprite(HopMedvedekConstants.HOP_MEDVEDEK_BEAR_TEXTURE, new Rectangle(0, 64, 23, 32),    new Vector2(12, 16), 12, 700, true),
        [BearState.BearJumpUp] =    new AnimatedSprite(HopMedvedekConstants.HOP_MEDVEDEK_BEAR_TEXTURE, new Rectangle(0, 96, 23, 32),    new Vector2(12, 16), 6,  350, true),
        [BearState.BearJumpDown] =  new AnimatedSprite(HopMedvedekConstants.HOP_MEDVEDEK_BEAR_TEXTURE, new Rectangle(138, 96, 23, 32),  new Vector2(12, 16), 6,  350, true),
        [BearState.BearWalkThrow] = new AnimatedSprite(HopMedvedekConstants.HOP_MEDVEDEK_BEAR_TEXTURE, new Rectangle(0, 32, 23, 32),    new Vector2(12, 16), 12, 700, true),
        [BearState.BearJumpThrow] = new AnimatedSprite(HopMedvedekConstants.HOP_MEDVEDEK_BEAR_TEXTURE, new Rectangle(0, 128, 23, 32),   new Vector2(12, 16), 12, 700, true),
        [BearState.BearDazed] =     new AnimatedSprite(HopMedvedekConstants.HOP_MEDVEDEK_BEAR_TEXTURE, new Rectangle(0, 160, 23, 32),   new Vector2(12, 16), 12, 700, true),
    };

    public float GravitationalAcceleration
    {
        get => _gravitationalAcceleration;
        set => _gravitationalAcceleration = value;
    }
    public bool Jumping
    {
        get => _jumping;
        set => _jumping = value;
    }
    public bool Grounded
    {
        get => _grounded;
        set => _grounded = value;
    }
    public BearState State
    {
        get => _state;
        set => _state = value;
    }
    public override Sprite Sprite(GameTime gameTime)
    {
        return _bearStateAnimations[_state].SpriteAtTime(gameTime.TotalGameTime.TotalMilliseconds);
    }
}

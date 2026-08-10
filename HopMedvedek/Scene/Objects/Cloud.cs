using Express.Graphics;
using Express.Scene.Objects.Movement;
using Express.Scene.Objects.Shapes;
using HopMedvedek.Data;
using Microsoft.Xna.Framework;
using System;

namespace HopMedvedek.Scene.Objects;

public class Cloud : IRectangleSize, IPosition, ITextured, IMovable
{
    protected float _width;
    protected float _height;
    protected Color _color;

    protected Vector2 _velocity;
    protected Sprite _cloudSprite;
    protected Vector2 _position;

    protected Vector2 _decay;
    protected Vector2 _acceleration;

    public Cloud()
    {
        _width = 69;
        _height = 42;
        _decay = new Vector2(1f, 1f);
        _color = Color.White;
        _velocity = new Vector2(0, 0);
        _position = new();
        _cloudSprite = new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_SCENE_ELEMENTS, new Rectangle(356, 0, 69, 42), new Vector2(34, 21));
    }

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

    public Sprite Sprite(GameTime gameTime)
    {
        return _cloudSprite;
    }
    public float LayerDepth => 0.3f;
    public Color Color
    {
        get => _color;
        set => _color = value;
    }
    public Boolean Facing => true;

    public ref Vector2 Decay => ref _decay;

    public ref Vector2 Acceleration => ref _acceleration;
    public ref Vector2 Velocity => ref _velocity;
}

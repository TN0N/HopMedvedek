using Express.Graphics;
using Express.Scene.Objects.Movement;
using Express.Scene.Objects.Shapes;
using HopMedvedek.Data;
using Microsoft.Xna.Framework;

namespace HopMedvedek.Scene.Objects;

public class TreeMid : IRectangleSize, IPosition, ITextured
{
    protected float _width;
    protected float _height;
    protected Color _color;

    protected Sprite _treeMidSprite;
    protected Vector2 _position;

    public TreeMid()
    {
        _width = 28;
        _height = 37;
        _color = Color.White;
        _position = new();
        _treeMidSprite = new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_SCENE_ELEMENTS, new Rectangle(0, 5, 28, 37), new Vector2(14, 18));
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
        return _treeMidSprite;
    }
    public float LayerDepth => 0.6f;
    public Color Color
    {
        get => _color;
        set => _color = value;
    }
}

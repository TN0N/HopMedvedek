using Express.Graphics;
using Express.Scene.Objects.Movement;
using Express.Scene.Objects.Shapes;
using HopMedvedek.Data;
using Microsoft.Xna.Framework;

namespace HopMedvedek.Scene.Objects;

public class TreeBase: IRectangleSize, IPosition, ITextured
{
    protected float _width;
    protected float _height;

    protected Sprite _treeBaseSprite;
    protected Vector2 _position;

    public TreeBase()
    {
        _width = 47;
        _height = 27;
        _position = new();
        _treeBaseSprite = new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_NATURE_TEXTURE, new Rectangle(28, 10, 47, 27), new Vector2(23, 13));
    }

    public float Width { 
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
        return _treeBaseSprite;
    }
    public float LayerDepth => 0.6f;
}

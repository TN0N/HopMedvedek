using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Express.Graphics;

public class Sprite
{
    private Texture2D _texture;
    private Rectangle _sourceRectangle;
    private Vector2 _origin;

    public Texture2D Texture
    { 
        get { return _texture; }
        set { _texture = value; }
    }

    public Rectangle SourceRectangle
    {
        get { return _sourceRectangle; }
        set { _sourceRectangle = value; }
    }

    public Vector2 Origin
    {
        get { return _origin; }
        set { _origin = value; }
    } 
}

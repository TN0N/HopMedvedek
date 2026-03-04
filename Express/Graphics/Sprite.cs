using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Express.Graphics;
/// <summary>
/// Defines a sprite.
/// </summary>
public class Sprite
{
    private Texture2D _texture; // The texture of the sprite.
    private Rectangle _sourceRectangle; // The source rectangle for the sprite.
    private Vector2 _origin; // The origin for the sprite.
    /// <summary>
    /// The <see cref="Texture2D"/> of the sprite.
    /// </summary>
    public Texture2D Texture
    {
        get => _texture;
        set => _texture = value;
    }
    /// <summary>
    /// The source <see cref="Rectangle"/> of the sprite.
    /// </summary>
    public Rectangle SourceRectangle
    {
        get => _sourceRectangle;
        set => _sourceRectangle = value;
    }
    /// <summary>
    /// The origin of the sprite.
    /// </summary>
    public Vector2 Origin
    {
        get => _origin;
        set => _origin = value;
    } 
}

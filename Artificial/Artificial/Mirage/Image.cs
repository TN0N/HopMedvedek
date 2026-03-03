using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Artificial.Artificial.Mirage;
/// <summary>
/// Defines static images shown outside of scene (UI).
/// </summary>
public class Image
{
    protected Texture2D _texture; // The texture of the image
    protected Rectangle _sourceRectangle; // The original source rectangle of the image 
    protected Color _color; // The colour the image
    protected Vector2 _poisition; // The position coordinates of the image
    protected Vector2 _origin; // The origin of the image
    protected Vector2 _scale;// The scaling factor
    protected float _rotation; // The rotation of the image
    protected float _layerDepth; // The layer depth of the image

    /// <summary>
    /// Defines a new <see cref="Image"/> by passing a <see cref="Texture2D"/> and a <see cref="Vector2"/> for its position.
    /// </summary>
    /// <param name="texture">The texture of the image.</param>
    /// <param name="position">The position of the image</param>
    public Image(Texture2D texture, Vector2 position)
    { 
        _texture = texture;
        _poisition = position;
        _sourceRectangle = texture?.Bounds ?? Rectangle.Empty; // Images assume that the entire texture is the image. There is not texture mapping 
        _color = Color.White; // No difference in colouring
        _origin = Vector2.Zero;
        _scale = Vector2.One;
    }
    /// <summary>
    /// The images texture.
    /// </summary>
    public Texture2D Texture
    { 
        get => _texture;
        set { 
            // When setting a new texture, we must also update the source rectangle
            _texture = value;
            _sourceRectangle = value.Bounds;
        }
    }
    /// <summary>
    /// The images source rectangle.
    /// </summary>
    public Rectangle SourceRectangle
    {
        get => _sourceRectangle;
        set => _sourceRectangle = value;
    }
    /// <summary>
    /// The images color.
    /// </summary>
    public Color Color
    { 
        get => _color;
        set => _color = value;
    }
    /// <summary>
    /// The images origin.
    /// </summary>
    public Vector2 Origin
    { 
        get => _origin; 
        set => _origin = value;
    }
    /// <summary>
    /// The images scale.
    /// </summary>
    public Vector2 Scale
    { 
        get => _scale;
        set => _scale = value;
    }
    /// <summary>
    /// The images rotation.
    /// </summary>
    public float Rotation
    {
        get => _rotation;
        set => _rotation = value;
    }
    /// <summary>
    /// The images layer depth.
    /// </summary>
    public float LayerDepth
    { 
        get => _layerDepth;
        set => _layerDepth = value;
    }
    /// <summary>
    /// Sets the scale of the image along the X and Y axis to the given value./>
    /// </summary>
    /// <param name="value">The value to scale the image.</param>
    public void SetScaleUniform(float value)
    { 
        _scale.X = value;
        _scale.Y = value;
    }
}

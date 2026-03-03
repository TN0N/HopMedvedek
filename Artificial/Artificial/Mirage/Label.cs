using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Artificial.Artificial.Mirage;

/// <summary>
/// Defines labels - text that is drawn.
/// </summary>
public class Label
{
    protected SpriteFont _font;
    protected string _text;
    protected Color _color;
    protected Vector2 _position;
    protected Vector2 _origin;
    protected Vector2 _scale;
    protected float _rotation;
    protected float _layerDepth;
    protected HorizontalAlign _horizontalAlign;
    protected VerticalAlign _verticalAlign;

    /// <summary>
    /// Defines a new <see cref="Label"/> by passing a font, text, and position coordinates.
    /// </summary>
    /// <param name="font">The font to be used.</param>
    /// <param name="text">The text to be drawn.</param>
    /// <param name="position">The position of the text.</param>
    public Label(SpriteFont font, string text, Vector2 position)
    {
        _font = font;
        _text = text;
        _position = position;
        _color = Color.White;
        _origin = Vector2.Zero;
        _scale = Vector2.One;

        UpdateOrigin(); // Makes sure the text is displayed according to its alignment
    }
    /// <summary>
    /// The sprite font used for the <see cref="Label"/>.
    /// </summary>
    public SpriteFont Font
    {
        get => _font;
        set => _font = value;
    }
    /// <summary>
    /// The <see langword="string"/> used for the <see cref="Label"/>'s text.
    /// </summary>
    public string Text
    {
        get => _text;
        set {
            _text = value;
            UpdateOrigin(); // Make sure the text is displayed according to its alignment
        }
    }
    /// <summary>
    /// The color of the <see cref="Label"/>'s text.
    /// </summary>
    public Color Color { 
        get => _color;
        set => _color = value;
    }
    /// <summary>
    /// The coordinates of the  <see cref="Label"/>'s position.
    /// </summary>
    public ref Vector2 Position => ref _position;
    /// <summary>
    /// The rotation of the  <see cref="Label"/>.
    /// </summary>
    public float Rotation {
        get => _rotation;
        set => _rotation = value;
    }
    /// <summary>
    /// The layer depth of the <see cref="Label"/>.
    /// </summary>
    public float LayerDepth {
        get => _layerDepth;
        set => _layerDepth = value;
    }
    /// <summary>
    /// The <see cref="Label"/>'s alignment along X.
    /// </summary>
    public HorizontalAlign HorizontalAlign
    {
        get => _horizontalAlign;
        set {
            _horizontalAlign = value;
            UpdateOrigin(); // Make sure the text is displayed according to its alignment
        }
    }
    /// <summary>
    /// The <see cref="Label"/>'s alignment along Y.
    /// </summary>
    public VerticalAlign VerticalAlign
    {
        get => _verticalAlign;
        set
        {
            _verticalAlign = value;
            UpdateOrigin(); // Make sure the text is displayed according to its alignment
        }
    }
    /// <summary>
    /// Set the <see cref="Label"/>'s scale along both X and Y axis.
    /// </summary>
    /// <param name="value"></param>
    public void SetScaleUniform(float value)
    {
        _scale.X = value;
        _scale.Y = value;
    }
    /// <summary>
    /// Updates the <see cref="Label"/>'s origin according to the alignents that were set.
    /// </summary>
    public void UpdateOrigin()
    { 
        Vector2 size = _font.MeasureString(_text);
        switch (_horizontalAlign)
        { 
            case HorizontalAlign.Left:   _origin.X = 0; break;
            case HorizontalAlign.Center: _origin.X = size.X/2; break;
            case HorizontalAlign.Right:  _origin.X = size.X; break;
        }
        switch (_verticalAlign)
        { 
            case VerticalAlign.Top:    _origin.Y = 0; break;
            case VerticalAlign.Middle: _origin.Y = size.Y/2; break;
            case VerticalAlign.Bottom: _origin.Y = size.Y; break;
        }
    }
}

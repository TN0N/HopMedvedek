using Artificial.Artificial.Mirage;
using Express.Graphics;
using Express.Scene;
using HopMedvedek.Audio;
using HopMedvedek.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HopMedvedek.Gui.Elements;

public class Button
{
    protected IScene _scene;
    protected Sprite _backgroundImage;
    protected Label _label;
    protected Rectangle _inputArea;
    protected bool _enabled;
    protected bool _isDown;
    protected bool _wasPressed;
    protected bool _wasReleased;
    protected float _layerDepth;
    protected bool _isHovering;

    protected Color _activeBackgroundColor, _activeLabelColor;
    protected Color _labelColor, _labelHoverColor, _labelPressedColor, _backgroundColor, _backgroundHoverColor, _backgroundPressedColor;

    public Button(Rectangle inputArea, Sprite backgroundImage, SpriteFont font, string text)
    { 
        _inputArea = inputArea;
        _enabled = true;
        _backgroundImage = backgroundImage;
        _label = new Label(font, text, new Vector2(_inputArea.X + inputArea.Width/2, _inputArea.Y + inputArea.Height/2));
        _label.VerticalAlign = VerticalAlign.Middle;
        _label.HorizontalAlign = HorizontalAlign.Center;

        _backgroundColor = Color.White;
        _backgroundHoverColor = Color.DarkGoldenrod;
        _backgroundPressedColor = Color.DimGray;
        _labelColor = Color.White;
        _labelHoverColor = Color.Gray;
        _labelPressedColor = Color.DarkGray;
        _label.LayerDepth = 0.9f;

        _layerDepth = 0.8f;

        _activeBackgroundColor = _backgroundColor;
        _activeLabelColor = _labelColor;
    }
    public Rectangle InputArea => _inputArea;

    public bool Enabled
    {
        get => _enabled;
        set => _enabled = value;
    }

    public bool IsDown => _isDown;

    public bool WasPressed => _wasPressed;

    public bool WasReleased => _wasReleased;

    public ref Sprite BackgroundImage => ref _backgroundImage;

    public bool IsHovering
    {
        get => _isHovering;
        set => _isHovering = value;
    }

    public ref Label Label => ref _label;
    public float LayerDepth
    {
        get => _layerDepth;
        set => _layerDepth = value;
    }
    public Sprite Sprite(GameTime gameTime)
    {
        return _backgroundImage;
    }
    public Color LabelColor
    {
        get => _labelColor;
        set
        {
            _labelColor = value;
            _label.Color = _labelColor;
        }
    }
    public Color Color
    {
        get => _activeBackgroundColor;
        set => _activeBackgroundColor = value;
    }
    public Color LabelHoverColor
    {
        get => _labelHoverColor;
        set => _labelHoverColor = value;
    }
    public Color LabelPressedColor
    {
        get => _labelPressedColor;
        set => _labelPressedColor = value;
    }

    public Color BackgroundColor
    {
        get => _backgroundColor;
        set
        {
            _backgroundColor = value;
        }
    }

    public Color BackgroundHoverColor
    {
        get => _backgroundHoverColor;
        set => _backgroundHoverColor = value;
    }
    public Color BackgroundPressedColor
    {
        get => _backgroundPressedColor;
        set => _backgroundPressedColor = value;
    }

    public Vector2 Position
    {
        get => _inputArea.Center.ToVector2();
        set {
            _inputArea.X = (int)value.X;
            _inputArea.Y = (int)value.Y;
        }
    }

    public IScene Scene { get; set; }

    public virtual void AddedToScene(IScene theScene)
    {
        theScene.Add(_backgroundImage);
        theScene.Add(_label);
    }

    public virtual void RemovedFromScene(IScene theScene)
    {
        theScene.Remove(_backgroundImage);
        theScene.Remove(_label);
    }

    public void UpdateWithInverseView(Matrix inverseView)
    {
        if (!_enabled)
            return;

        bool wasDown = _isDown;
        _isDown = false;
        _wasPressed = false;
        _wasReleased = false;

        var mousePositionOnScreen = HopInput.GetMouseState().Position.ToVector2();
        var mousePositionInScene = Vector2.Transform(mousePositionOnScreen, inverseView);

        if (_inputArea.Contains(mousePositionInScene))
        {
            if (wasDown)
            {
                if (HopInput.GetMouseState().LeftButton != ButtonState.Pressed)
                {
                    SoundEngine.Play(SoundEffectType.ButtonPressed, null, null, Options.Options.Current.GameVolume);
                    _wasReleased = true;
                    _activeBackgroundColor = _backgroundColor;
                    _label.Color = _labelColor;
                }
                else
                {
                    _isDown = true;
                    _wasPressed = true;
                    _activeBackgroundColor = _backgroundPressedColor;
                    _label.Color = _labelPressedColor;
                }
            }
            else
            {
                if (HopInput.GetMouseState().LeftButton == ButtonState.Pressed)
                {
                    _isDown = true;
                    _wasPressed = true;

                    _activeBackgroundColor = _backgroundPressedColor;
                    _label.Color = _labelPressedColor;
                }
                else
                {
                    if (!_isHovering)
                        SoundEngine.Play(SoundEffectType.ButtonHover, null, null, Options.Options.Current.GameVolume);
                    _isHovering = true;
                    _activeBackgroundColor = _backgroundHoverColor;
                    _label.Color = _labelHoverColor;
                }
            }
        }
        else
        {
            _isHovering = false;
            _activeBackgroundColor = _backgroundColor;
            _label.Color = _labelColor;
        }
    }
}

using Artificial.Artificial.Mirage;
using Express.Graphics;
using Express.Scene;
using HopMedvedek.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace HopMedvedek.Gui.Elements;

public class Slider
{
    protected IScene _scene;
    //protected Image _backgroundImage;
    protected Sprite _trackTexture, _thumbTexture;
    protected float _value;


    protected Label _valueFill;
    protected Rectangle _inputArea, _thumbArea;
    protected bool _enabled;
    protected bool _isDown;
    protected bool _wasPressed;
    protected bool _wasReleased;
    protected float _layerDepth;

    protected Color _activeBackgroundColor, _activeLabelColor;
    protected Color _labelColor, _labelHoverColor, _labelPressedColor, _backgroundColor, _backgroundHoverColor, _backgroundPressedColor;

    public Slider(Rectangle inputArea, Vector2 thumbArea, Sprite trackTexture, Sprite thumbTexture, SpriteFont font, float value)
    {
        _inputArea = inputArea;
        _thumbArea = new Rectangle((int)(_inputArea.X + _inputArea.Width * value), (int)(_inputArea.Y - thumbArea.Y / 2), (int)thumbArea.X, (int)thumbArea.Y);
        _value = value;

        _enabled = true;
        _trackTexture = trackTexture;
        _thumbTexture = thumbTexture;

        _valueFill = new Label(font, _value.ToString("P0"), new Vector2(_inputArea.Right + 20, _inputArea.Y - 5));

        _valueFill.VerticalAlign = VerticalAlign.Middle;
        _valueFill.HorizontalAlign = HorizontalAlign.Left;

        _backgroundColor = Color.White;
        _backgroundHoverColor = Color.DarkGoldenrod;
        _backgroundPressedColor = Color.DimGray;
        _labelColor = Color.White;
        _labelHoverColor = Color.Gray;
        _labelPressedColor = Color.DarkGray;
        _valueFill.LayerDepth = 0.9f;

        _layerDepth = 0.8f;

        _activeBackgroundColor = _backgroundColor;
        _activeLabelColor = _labelColor;
    }
    public Rectangle InputArea => _inputArea;
    public Rectangle ThumbArea => _thumbArea;

    public bool Enabled
    {
        get => _enabled;
        set => _enabled = value;
    }

    public bool IsDown => _isDown;

    public bool WasPressed => _wasPressed;

    public bool WasReleased => _wasReleased;

    public ref Sprite TrackTexture => ref _trackTexture;

    public ref Sprite ThumbTexture => ref _thumbTexture;
    public ref Label ValueFill => ref _valueFill;
    public float LayerDepth
    {
        get => _layerDepth;
        set => _layerDepth = value;
    }
    public Color LabelColor
    {
        get => _labelColor;
        set
        {
            _labelColor = value;
            _valueFill.Color = _labelColor;
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
            //_backgroundImage.Color = _backgroundColor;
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

    public float Value
    {
        get => _value;
        set
        {
            _value = MathHelper.Clamp(value, 0f, 1f);
            // Update thumb position based on value
            _thumbArea.X = _inputArea.X + (int)((_inputArea.Width - _thumbArea.Width) * _value);
        }
    }

    public Vector2 Position
    {
        get => _inputArea.Center.ToVector2();
        set
        {
            _inputArea.X = (int)value.X;
            _inputArea.Y = (int)value.Y;
        }
    }

    public IScene Scene { get; set; }

    public void AddedToScene(IScene theScene)
    {
        // Add child items to scene.
        theScene.Add(_trackTexture);
        theScene.Add(_thumbTexture);

        theScene.Add(ValueFill);
    }

    public void RemovedFromScene(IScene theScene)
    {
        // Remove child items.
        theScene.Remove(_trackTexture);
        theScene.Remove(_thumbTexture);

        theScene.Remove(ValueFill);
    }

    public void UpdateWithInverseView(Matrix inverseView)
    {
        //System.Diagnostics.Debug.WriteLine("Slider updating");
        if (!_enabled)
            return;
        //System.Diagnostics.Debug.WriteLine("Slider updating");
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
                // release pressed button -> trigger action
                if (HopInput.GetMouseState().LeftButton != ButtonState.Pressed)
                {
                    _wasReleased = true;
                    _activeBackgroundColor = _backgroundColor;
                    _valueFill.Color = _labelColor;
                }
                // holding pressed button
                else
                {
                    _isDown = true;
                    _wasPressed = true;
                    _activeBackgroundColor = _backgroundPressedColor;
                    _valueFill.Color = _labelPressedColor;
                    _thumbArea.X = (int)(mousePositionInScene.X - _thumbArea.Width / 2);
                    _value = (float)Math.Round((float)(_thumbArea.X - _inputArea.X) / (_inputArea.Width - _thumbArea.Width), 2);
                    _value = MathHelper.Clamp(_value, 0f, 1f);
                }
            }
            else
            {
                // click on button
                if (HopInput.GetMouseState().LeftButton == ButtonState.Pressed)
                {
                    _isDown = true;
                    _wasPressed = true;
                    _activeBackgroundColor = _backgroundPressedColor;
                    _valueFill.Color = _labelPressedColor;

                    //System.Diagnostics.Debug.WriteLine("Slider clicked");
                }
                // hover over button
                else
                {
                    _activeBackgroundColor = _backgroundHoverColor;
                    _valueFill.Color = _labelHoverColor;
                }
            }
        }
        // mouse not over button
        else
        {
            _activeBackgroundColor = _backgroundColor;
            _valueFill.Color = _labelColor;
        }
        
    }
}

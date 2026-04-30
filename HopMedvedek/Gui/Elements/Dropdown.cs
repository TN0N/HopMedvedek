using Artificial.Artificial.Mirage;
using Express.Graphics;
using Express.Scene;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace HopMedvedek.Gui.Elements;

public class Dropdown
{
    protected IScene _scene;
    protected Rectangle _inputArea;
    protected Vector2 _optionsSize;
    protected int _optionsSpacing;

    protected Button _inputButton;
    protected Dictionary<object, string> _dropdownItems;
    protected List<Button> _dropdownItemButtons;
    protected object _selectedKey;

    protected Sprite _backgroundImage;
    protected SpriteFont _font;
    protected Rectangle _dropdownArea;
    protected bool _isActive = false;

    public Dropdown(Rectangle inputArea, Sprite backgroundImage, SpriteFont font, object selectedKey, Dictionary<object, string> dropdownItems, IScene scene, Vector2? optionsSize=null, int optionsSpacing = 3)
    {
        _scene = scene;
        _inputArea = inputArea;
        _backgroundImage = backgroundImage;
        _font = font;
        _selectedKey = selectedKey;
        _dropdownItems = dropdownItems;

        _dropdownArea = inputArea;

        _optionsSize = optionsSize ?? new Vector2(_inputArea.Width, _inputArea.Height);
        _optionsSpacing = optionsSpacing;

        _inputButton = new Button(_inputArea, _backgroundImage, _font, _dropdownItems[_selectedKey]);
        _inputButton.Label.Scale = new Vector2(0.8f, 0.8f);
        _dropdownItemButtons = new List<Button>();

        _scene.Add(_inputButton);
    }
   
    protected void ExpandDropdown()
    {
        int position_Y = _inputArea.Bottom + _optionsSpacing;
        foreach (object key in _dropdownItems.Keys)
        {
            Button optionButton = new Button(new Rectangle(_inputArea.X, position_Y, (int)_optionsSize.X, (int)_optionsSize.Y), _backgroundImage, _font, _dropdownItems[key]);
            optionButton.Label.Scale = new Vector2(0.8f, 0.8f);
            _scene.Add(optionButton);
            _dropdownItemButtons.Add(optionButton);
            position_Y += (int)(_optionsSpacing + _optionsSize.Y);
        }
        _dropdownArea = new Rectangle(_inputArea.X, _inputArea.Y, (int)_optionsSize.X, position_Y);
    }
    protected void CollapseDropdown()
    {
        foreach (Button optionButton in _dropdownItemButtons)
        {
            _scene.Remove(optionButton);
        }
        _dropdownItemButtons.Clear();
    }
    public SpriteFont Font
    {
        get => _font;
        set => _font = value;
    }
    public object SelectedKey
    { 
        get => _selectedKey;
        set => _selectedKey = value;
    }
    public bool IsActive
    {
        get => _isActive;
        set => _isActive = value;
    }
    public List<Button> DropdownItemButtons
    { 
        get => _dropdownItemButtons;
        set => _dropdownItemButtons = value;
    }
    public void UpdateWithInverseView(Matrix inverseView)
    {
        

        var mousePositionOnScreen = Mouse.GetState().Position.ToVector2();
        var mousePositionInScene = Vector2.Transform(mousePositionOnScreen, inverseView);

        if (!_dropdownArea.Contains(mousePositionInScene))
        {
            CollapseDropdown();
            _isActive = false;
            return;
        }

        _inputButton.UpdateWithInverseView(inverseView);

        if (_inputButton.WasPressed)
        {
            ExpandDropdown();
            _isActive = true;
        }
        //if (_inputButton.)
        foreach (Button button in _dropdownItemButtons)
            button.UpdateWithInverseView(inverseView);
        int i = 0;
        foreach (object key in _dropdownItems.Keys)
        {
            if (_dropdownItemButtons.Count < 1)
                break;
            if (_dropdownItemButtons[i].IsDown)
            { 
                _selectedKey = key;
                _inputButton.Label.Text = _dropdownItems[_selectedKey];
                
            }
            i++;
        }
    }
}

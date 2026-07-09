using Express.Graphics;
using Express.Scene;
using HopMedvedek.Data;
using HopMedvedek.Graphics;
using HopMedvedek.Gui.Elements;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Artificial.Artificial.Mirage;
using HopMedvedek.Data.Strings;
using System.Collections.Generic;
using System;

namespace HopMedvedek.GameStates.Menus;

public class Menu : GameState
{
    protected SimpleScene _scene;
    protected Renderer _renderer;
    protected SpriteFont _luckiestGuy;
    protected Sprite _buttonBackground;
    protected Button _back;
    protected int _buttonWidth;
    protected int _buttonHeight;
    protected bool _dropdownActive = false;

    public Menu(Game game) : base(game)
    {
        _buttonWidth = 280;
        _buttonHeight = 80;
        _scene = new SimpleScene(Game);
        _renderer = new Renderer(Game, _scene);

        _scene.CameraMatrix = Matrix.CreateScale((float)Game.Window.ClientBounds.Width / HopMedvedekConstants.screenWidth, (float)Game.Window.ClientBounds.Height / HopMedvedekConstants.screenHeight, 1f);

        _luckiestGuy = Game.Content.Load<SpriteFont>(HopMedvedekConstants.HOP_MEDVEDEK_LUCKIESTGUY_FONT);
        _buttonBackground = new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_MAIN_MENU_BUTTON_TEXTURE, new Rectangle(0,0, 358, 154), new Vector2(279, 77));

        _scene.SceneTextureData = new Dictionary<string, Texture2D>
        {
            [HopMedvedekConstants.HOP_MEDVEDEK_MAIN_MENU_BUTTON_TEXTURE] = Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_MAIN_MENU_BUTTON_TEXTURE)
        };

        _back = new Button(new Rectangle(10, 10, _buttonHeight, _buttonHeight), _buttonBackground, _luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_COMMON_MENU_BACK][Options.Options.Current.Language]);
        _back.Label.Scale = new Vector2(0.7f, 0.7f);
        _back.Label.Position.X = _back.Position.X;
        _back.Label.VerticalAlign = VerticalAlign.Middle;
        _back.Label.HorizontalAlign = HorizontalAlign.Center;
    }
    public override void Activate()
    {
        Game.Components.Add(_scene);
        Game.Components.Add(_renderer);
    }

    public override void Deactivate()
    {
        Game.Components.Remove(_scene);
        Game.Components.Remove(_renderer);
    }

    public override void Update(GameTime gameTime)
    {
        Matrix inverseView = Matrix.Invert(_scene.CameraMatrix);
        foreach (object item in _scene)
        {
            if (item is Dropdown dropdown)
            {
                dropdown.UpdateWithInverseView(inverseView);
                if (dropdown.IsActive)
                    return;
            }

        }
        foreach (object item in _scene)
        {
            if (item is Button button)
            {
                button.UpdateWithInverseView(inverseView);
            }
            else if (item is Slider slider)
            {
                slider.UpdateWithInverseView(inverseView);
            }

        }
        if (_back.WasReleased)
        {
            _hopMedvedek.PopState();
        }

    }
}

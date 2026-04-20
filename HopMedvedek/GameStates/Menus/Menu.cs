using Express.Graphics;
using Express.Scene;
using HopMedvedek.Data;
using HopMedvedek.Graphics;
using HopMedvedek.Gui.Elements;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Artificial.Artificial.Mirage;
using HopMedvedek.Data.Strings;

namespace HopMedvedek.GameStates.Menus;

public class Menu : GameState
{
    protected SimpleScene _scene;
    protected Renderer _renderer;
    protected SpriteFont _luckiestGuy;
    protected Sprite _buttonBackground;
    protected Button _back;


    public Menu(Game game) : base(game)
    {
        _scene = new SimpleScene(Game);
        _renderer = new Renderer(Game, _scene);

        _luckiestGuy = Game.Content.Load<SpriteFont>(HopMedvedekConstants.HOP_MEDVEDEK_LUCKIESTGUY_FONT);
        _buttonBackground = new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_MAIN_MENU_BUTTON_TEXTURE, new Rectangle(0,0, 358, 154), new Vector2(279, 77));

        _back = new Button(new Rectangle(0, 0, 368, 154), _buttonBackground, _luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_COMMON_MENU_BACK][Options.Options.Current.Language]);
        _back.Label.Position.X = 160;
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
            if (item is Button button)
            {
                button.UpdateWithInverseView(inverseView);
            }

        }
        if (_back.WasReleased)
        {
            _hopMedvedek.PopState();
        }

    }
}

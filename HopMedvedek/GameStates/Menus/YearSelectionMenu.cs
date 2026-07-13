using HopMedvedek.Data;
using HopMedvedek.Data.Strings;
using HopMedvedek.Gui.Elements;
using HopMedvedek.Options;
using Microsoft.Xna.Framework;
namespace HopMedvedek.GameStates.Menus;

public class YearSelectionMenu : Menu
{
    protected Button _year01, _year02, _year03, _year04;
    protected Image _background;

    public YearSelectionMenu(Game game) : base(game)
    {
        base.Initialize();


        //_scene.SceneTextureData.Add(HopMedvedekConstants.HOP_MEDVEDEK_MAIN_MENU_BACKGROUND, Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_MAIN_MENU_BACKGROUND));
        _year01 = new Button(new Rectangle(HopMedvedekConstants.screenWidth / 2 - _buttonWidth / 2, 200, _buttonWidth, _buttonHeight), _buttonBackground, _luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_SELECTION_MENU_YEAR_01][Options.Options.Current.Language]);
        _year02 = new Button(new Rectangle(HopMedvedekConstants.screenWidth / 2 - _buttonWidth / 2, 300, _buttonWidth, _buttonHeight), _buttonBackground, _luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_SELECTION_MENU_YEAR_02][Options.Options.Current.Language]);
        _year03 = new Button(new Rectangle(HopMedvedekConstants.screenWidth / 2 - _buttonWidth / 2, 400, _buttonWidth, _buttonHeight), _buttonBackground, _luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_SELECTION_MENU_YEAR_03][Options.Options.Current.Language]);
        _year04 = new Button(new Rectangle(HopMedvedekConstants.screenWidth / 2 - _buttonWidth / 2, 500, _buttonWidth, _buttonHeight), _buttonBackground, _luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_YEAR_SELECTION_MENU_YEAR_04][Options.Options.Current.Language]);
        /*
        Rectangle backgroundImageSize = new Rectangle(0, 0, 864, 1821);
        float scaleFactor = backgroundImageSize.Height / game.Window.ClientBounds.Height;

        _background = new Image(
            new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_MAIN_MENU_BACKGROUND, backgroundImageSize, new Vector2(backgroundImageSize.Width / 2, backgroundImageSize.Height / 2)),
            new Rectangle(game.Window.ClientBounds.Width / 2, game.Window.ClientBounds.Height / 2, (int)(backgroundImageSize.Width / scaleFactor), (int)(backgroundImageSize.Height / scaleFactor))
            );
        _background.LayerDepth = 0.1f;*/

        //_scene.Add(_background);
        _scene.Add(_year01);
        _scene.Add(_year02);
        _scene.Add(_year03);
        _scene.Add(_year04);
        _scene.Add(_back);
    }
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        GameState newState = null;

        if (_year01.WasReleased)
        {
            newState = new Year01SubjectSelectionMenu(Game);
        }
        else if (_year02.WasReleased)
        {
            newState = new Year02SubjectSelectionMenu(Game);
        }
        else if (_year03.WasReleased)
        {
            newState = new Year02SubjectSelectionMenu(Game);
        }
        else if (_year04.WasReleased)
        {
            newState = new Year02SubjectSelectionMenu(Game);
        }
        if (newState is not null)
        {
            _hopMedvedek.PushState(newState);
        }
    }
}

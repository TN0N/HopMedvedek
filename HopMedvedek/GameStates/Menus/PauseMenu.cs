using HopMedvedek.Audio;
using HopMedvedek.Data;
using HopMedvedek.Data.Strings;
using HopMedvedek.Gui.Elements;
using Microsoft.Xna.Framework;
using System.Linq;
namespace HopMedvedek.GameStates.Menus;

public class PauseMenu : Menu
{
    protected Button _restart, _returnToMainmenu, _options, _continue;
    protected Image _background;

    public PauseMenu(Game game) : base(game)
    {
        base.Initialize();
        _continue = new Button(new Rectangle(HopMedvedekConstants.screenWidth / 2 - _buttonWidth / 2, 500, _buttonWidth, _buttonHeight), _buttonBackground, _luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_PAUSE_MENU_CONTINUE][Options.Options.Current.Language]);
        _options = new Button(new Rectangle(HopMedvedekConstants.screenWidth / 2 - _buttonWidth / 2, 600, _buttonWidth, _buttonHeight), _buttonBackground, _luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_PAUSE_MENU_OPTIONS][Options.Options.Current.Language]);
        _restart = new Button(new Rectangle(HopMedvedekConstants.screenWidth / 2 - _buttonWidth / 2, 700, _buttonWidth, _buttonHeight), _buttonBackground, _luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_PAUSE_MENU_RESTART][Options.Options.Current.Language]);
        _returnToMainmenu = new Button(new Rectangle(HopMedvedekConstants.screenWidth / 2 - _buttonWidth / 2, 800, _buttonWidth, _buttonHeight), _buttonBackground, _luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_DEATH_MENU_RETURN_TO_MAIN_MENU][Options.Options.Current.Language]);

        _scene.Add(_continue);
        _scene.Add(_options);
        _scene.Add(_restart);
        _scene.Add(_returnToMainmenu);
    }
    public override void Reload()
    {
        _continue.Label.Text = Strings.Localizations[StringKey.HOP_MEDVEDEK_PAUSE_MENU_CONTINUE][Options.Options.Current.Language];
        _options.Label.Text = Strings.Localizations[StringKey.HOP_MEDVEDEK_PAUSE_MENU_OPTIONS][Options.Options.Current.Language];
        _restart.Label.Text = Strings.Localizations[StringKey.HOP_MEDVEDEK_PAUSE_MENU_RESTART][Options.Options.Current.Language];
        _returnToMainmenu.Label.Text = Strings.Localizations[StringKey.HOP_MEDVEDEK_DEATH_MENU_RETURN_TO_MAIN_MENU][Options.Options.Current.Language];
    }
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        GameState newState = null;
        if (_continue.WasReleased)
        {
            _hopMedvedek.PopState();
            return;
        }
        else if (_restart.WasReleased)
        {
 
            SoundEngine.Instance.StopSounds();

            GamePlay.GamePlay currentGameplay = Game.Components.OfType<GamePlay.GamePlay>().FirstOrDefault();

            GamePlay.GamePlay gameplay = new GamePlay.GamePlay(Game, currentGameplay.LevelClass);
            _hopMedvedek.PushState(gameplay);

        }
        else if (_options.WasReleased)
        { 
            newState = new OptionsMenu(Game);
        }
        else if (_returnToMainmenu.WasReleased)
        {
            SoundEngine.Instance.StopSounds();
            newState = new MainMenu(Game);
        }

        if (newState is not null)
        {
            _hopMedvedek.PushState(newState);
        }
    }
}

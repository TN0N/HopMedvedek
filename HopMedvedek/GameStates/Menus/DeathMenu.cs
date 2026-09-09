using HopMedvedek.Data;
using HopMedvedek.Data.Strings;
using HopMedvedek.Gui.Elements;
using Microsoft.Xna.Framework;
using System;
using Artificial.Artificial.Mirage;
using Express.Scores;
namespace HopMedvedek.GameStates.Menus;

public class DeathMenu : Menu
{
    protected Button _restart, _returnToMainmenu;
    protected Image _background;
    protected Label _deathTextLabel, _scoreLabel, _highScoreLabel;
    protected Type _levelClass;

    public DeathMenu(Game game, Type LevelClass) : base(game)
    {
        base.Initialize();
        _levelClass = LevelClass;

        _deathTextLabel = new Label(_luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_DEATH_MENU_DEATH_TEXT][Options.Options.Current.Language], new Vector2(HopMedvedekConstants.screenWidth / 2, 100));
        _highScoreLabel = new Label(_luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_DEATH_MENU_HIGH_SCORE][Options.Options.Current.Language] + Data.PlayerData.Current.HighScore, new Vector2(HopMedvedekConstants.screenWidth / 2, 200));
        _scoreLabel = new Label(_luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_DEATH_MENU_SCORE][Options.Options.Current.Language] + Scores.score, new Vector2(HopMedvedekConstants.screenWidth / 2, 300));

        _deathTextLabel.HorizontalAlign = HorizontalAlign.Center;
        _highScoreLabel.HorizontalAlign = HorizontalAlign.Center;
        _scoreLabel.HorizontalAlign = HorizontalAlign.Center;


        _restart = new Button(new Rectangle(HopMedvedekConstants.screenWidth / 2 - _buttonWidth / 2, 700, _buttonWidth, _buttonHeight), _buttonBackground, _luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_DEATH_MENU_RESTART][Options.Options.Current.Language]);
        _returnToMainmenu = new Button(new Rectangle(HopMedvedekConstants.screenWidth / 2 - _buttonWidth / 2, 800, _buttonWidth, _buttonHeight), _buttonBackground, _luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_DEATH_MENU_RETURN_TO_MAIN_MENU][Options.Options.Current.Language]);

        _scene.Add(_deathTextLabel);
        _scene.Add(_highScoreLabel);
        _scene.Add(_scoreLabel);
        
        _scene.Add(_restart);
        _scene.Add(_returnToMainmenu);
    }
    public override void Reload()
    {
        _deathTextLabel.Text = Strings.Localizations[StringKey.HOP_MEDVEDEK_DEATH_MENU_DEATH_TEXT][Options.Options.Current.Language];
        _highScoreLabel.Text = Strings.Localizations[StringKey.HOP_MEDVEDEK_DEATH_MENU_HIGH_SCORE][Options.Options.Current.Language] + Data.PlayerData.Current.HighScore;
        _scoreLabel.Text = Strings.Localizations[StringKey.HOP_MEDVEDEK_DEATH_MENU_SCORE][Options.Options.Current.Language] + Scores.score;
        _restart.Label.Text = Strings.Localizations[StringKey.HOP_MEDVEDEK_DEATH_MENU_RESTART][Options.Options.Current.Language];
        _returnToMainmenu.Label.Text = Strings.Localizations[StringKey.HOP_MEDVEDEK_DEATH_MENU_RETURN_TO_MAIN_MENU][Options.Options.Current.Language];
    }
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        GameState newState = null;

        if (_restart.WasReleased)
        {
            GamePlay.GamePlay gameplay = new GamePlay.GamePlay(Game, _levelClass);
            _hopMedvedek.PushState(gameplay);
            
        }

        else if (_returnToMainmenu.WasReleased)
        {
            newState = new MainMenu(Game);
        }

        if (newState is not null)
        {
            _hopMedvedek.PushState(newState);
        }
    }
}

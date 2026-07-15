using HopMedvedek.Data;
using HopMedvedek.Data.Strings;
using HopMedvedek.Gui.Elements;
using HopMedvedek.Level;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Express.Graphics;
using Artificial.Artificial.Mirage;
using Express.Scores;
namespace HopMedvedek.GameStates.Menus;

public class PauseMenu : Menu
{
    protected Button _restart, _returnToMainmenu, _options, _continue;
    protected Image _background;

    public PauseMenu(Game game) : base(game)
    {
        base.Initialize();


        //_scene.SceneTextureData.Add(HopMedvedekConstants.HOP_MEDVEDEK_MAIN_MENU_BACKGROUND, Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_MAIN_MENU_BACKGROUND));
        _continue = new Button(new Rectangle(HopMedvedekConstants.screenWidth / 2 - _buttonWidth / 2, 500, _buttonWidth, _buttonHeight), _buttonBackground, _luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_PAUSE_MENU_CONTINUE][Options.Options.Current.Language]);
        _options = new Button(new Rectangle(HopMedvedekConstants.screenWidth / 2 - _buttonWidth / 2, 600, _buttonWidth, _buttonHeight), _buttonBackground, _luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_PAUSE_MENU_OPTIONS][Options.Options.Current.Language]);
        _restart = new Button(new Rectangle(HopMedvedekConstants.screenWidth / 2 - _buttonWidth / 2, 700, _buttonWidth, _buttonHeight), _buttonBackground, _luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_PAUSE_MENU_RESTART][Options.Options.Current.Language]);
        _returnToMainmenu = new Button(new Rectangle(HopMedvedekConstants.screenWidth / 2 - _buttonWidth / 2, 800, _buttonWidth, _buttonHeight), _buttonBackground, _luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_DEATH_MENU_RETURN_TO_MAIN_MENU][Options.Options.Current.Language]);
        /*
        Rectangle backgroundImageSize = new Rectangle(0, 0, 864, 1821);
        float scaleFactor = backgroundImageSize.Height / game.Window.ClientBounds.Height;

        _background = new Image(
            new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_MAIN_MENU_BACKGROUND, backgroundImageSize, new Vector2(backgroundImageSize.Width / 2, backgroundImageSize.Height / 2)),
            new Rectangle(game.Window.ClientBounds.Width / 2, game.Window.ClientBounds.Height / 2, (int)(backgroundImageSize.Width / scaleFactor), (int)(backgroundImageSize.Height / scaleFactor))
            );
        _background.LayerDepth = 0.1f;*/

        //_scene.Add(_background);
        _scene.Add(_continue);
        _scene.Add(_options);
        _scene.Add(_restart);
        _scene.Add(_returnToMainmenu);
    }
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        GameState newState = null;
        if (_continue.WasReleased)
        {
            _hopMedvedek.PopState();
        }
        else if (_restart.WasReleased)
        {
            /*
            Type[] levelClasses = new Type[(int)LevelType.LastType] {
               typeof(Level.Levels.LanguageLevel),
               typeof(Level.Levels.Year01MathLevel)
            };
            
            GamePlay.GamePlay gameplay = new GamePlay.GamePlay(Game, levelClasses[0]);
            _hopMedvedek.PushState(gameplay);*/
        }
        else if (_options.WasReleased)
        { 
            newState = new OptionsMenu(Game);
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

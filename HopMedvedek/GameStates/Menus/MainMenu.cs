using HopMedvedek.Data;
using HopMedvedek.Data.Strings;
using HopMedvedek.Gui.Elements;
using HopMedvedek.Level;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Express.Graphics;
namespace HopMedvedek.GameStates.Menus;

public class MainMenu : Menu
{
    protected Button _play, _options;
    protected Image _background;

    public MainMenu(Game game) : base(game)
    {
        base.Initialize();


        _scene.SceneTextureData.Add(HopMedvedekConstants.HOP_MEDVEDEK_MAIN_MENU_BACKGROUND, Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_MAIN_MENU_BACKGROUND));


        _play = new Button(new Rectangle(game.Window.ClientBounds.Width/2 - _buttonWidth / 2, 700, _buttonWidth, _buttonHeight), _buttonBackground, _luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_MAIN_MENU_PLAY][Options.Options.Current.Language]);
        _options = new Button(new Rectangle(game.Window.ClientBounds.Width / 2 - _buttonWidth / 2, 800, _buttonWidth, _buttonHeight), _buttonBackground, _luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_MAIN_MENU_OPTIONS][Options.Options.Current.Language]);

        Rectangle backgroundImageSize = new Rectangle(0,0, 864, 1821);
        float scaleFactor = backgroundImageSize.Height / game.Window.ClientBounds.Height;

        _background = new Image(
            new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_MAIN_MENU_BACKGROUND, backgroundImageSize, new Vector2(backgroundImageSize.Width/2, backgroundImageSize.Height/2)), 
            new Rectangle(game.Window.ClientBounds.Width/2, game.Window.ClientBounds.Height/2, (int)(backgroundImageSize.Width / scaleFactor), (int)(backgroundImageSize.Height / scaleFactor))
            );
        _background.LayerDepth = 0.1f;

        _scene.Add(_background);
        _scene.Add(_play);
        _scene.Add(_options);
    }
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        GameState newState = null;

        if (_play.WasReleased)
        {
            Type[] levelClasses = new Type[(int)LevelType.LastType] {
               typeof(Level.Levels.LanguageLevel),
               typeof(Level.Levels.MathLevel)
            };

            GamePlay.GamePlay gameplay = new GamePlay.GamePlay(Game, levelClasses[0]);
            _hopMedvedek.PushState(gameplay);
        }
        
        else if (_options.WasReleased)
        {
            newState = new OptionsMenu(Game);
        }

        if (newState is not null)
        {
            _hopMedvedek.PushState(newState);
        }
    }
}

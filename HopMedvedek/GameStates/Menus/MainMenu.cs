using HopMedvedek.Data;
using HopMedvedek.Data.Strings;
using HopMedvedek.GameStates.GamePlay;
using HopMedvedek.Gui.Elements;
using HopMedvedek.Level;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
namespace HopMedvedek.GameStates.Menus;

public class MainMenu : Menu
{
    protected Button _play, _options;
    public MainMenu(Game game) : base(game)
    {
        base.Initialize();


        _scene.SceneTextureData = new Dictionary<string, Texture2D>
        {
            [HopMedvedekConstants.HOP_MEDVEDEK_MAIN_MENU_BUTTON_TEXTURE] = Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_MAIN_MENU_BUTTON_TEXTURE),
        };

        _play = new Button(new Rectangle(0, 0, 368, 154), _buttonBackground, _luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_MAIN_MENU_PLAY][Options.Options.Current.Language]);
        _options = new Button(new Rectangle(0, 100, 368, 154), _buttonBackground, _luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_MAIN_MENU_OPTIONS][Options.Options.Current.Language]);

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
        /*
        else if (_options.WasReleased)
        {
            newState = new Options(Game);
        }*/

        if (newState is not null)
        {
            _hopMedvedek.PushState(newState);
        }
    }
}

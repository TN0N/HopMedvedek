using HopMedvedek.Data;
using HopMedvedek.Data.Strings;
using HopMedvedek.Gui.Elements;
using HopMedvedek.Level;
using HopMedvedek.Level.Levels;
using HopMedvedek.Options;
using Microsoft.Xna.Framework;
using System;
namespace HopMedvedek.GameStates.Menus;

public class Year01SubjectSelectionMenu : Menu
{
    protected Button _language, _maths;
    protected Image _background;

    public Year01SubjectSelectionMenu(Game game) : base(game)
    {
        base.Initialize();


        //_scene.SceneTextureData.Add(HopMedvedekConstants.HOP_MEDVEDEK_MAIN_MENU_BACKGROUND, Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_MAIN_MENU_BACKGROUND));
        _language = new Button(new Rectangle(HopMedvedekConstants.screenWidth / 2 - _buttonWidth / 2, 200, _buttonWidth, _buttonHeight), _buttonBackground, _luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_SUBJECT_LANGUAGE][Options.Options.Current.Language]);
        _maths = new Button(new Rectangle(HopMedvedekConstants.screenWidth / 2 - _buttonWidth / 2, 300, _buttonWidth, _buttonHeight), _buttonBackground, _luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_SUBJECT_MATHS][Options.Options.Current.Language]);
        

        _scene.Add(_language);
        _scene.Add(_maths);
        _scene.Add(_back);
    }
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        if (_language.WasReleased)
        {
            GamePlay.GamePlay gameplay = new GamePlay.GamePlay(Game, typeof(Year01LanguageLevel));
            _hopMedvedek.PushState(gameplay);
        }
        else if (_maths.WasReleased)
        {
            GamePlay.GamePlay gameplay = new GamePlay.GamePlay(Game, typeof(Year01MathLevel));
            _hopMedvedek.PushState(gameplay);
        }
    }
}

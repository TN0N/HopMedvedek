using HopMedvedek.Data.Strings;
using HopMedvedek.Data;
using HopMedvedek.Gui.Elements;
using HopMedvedek.Level.Levels;
using Microsoft.Xna.Framework;
using Artificial.Artificial.Mirage;
using System.Collections.Generic;
using HopMedvedek.Questions;
using System.Runtime.InteropServices.JavaScript;
using System;

namespace HopMedvedek.GameStates.Menus;

public class SubjectSelectionMenu : Menu
{
    protected List<Label> _labels;
    protected Image _background;
    // QuestionSheet, SubjectName
    protected Dictionary<SubjectType, SubjectMenuButton> _buttons;
    protected Dictionary<SubjectType, string> _subject;
    protected Dictionary<SubjectType, Type> _levelType;

    public SubjectSelectionMenu(Game game) : base(game)
    {
        _buttons = new();
        _labels = new();
        base.Initialize();

        //_scene.SceneTextureData.Add(HopMedvedekConstants.HOP_MEDVEDEK_MAIN_MENU_BACKGROUND, Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_MAIN_MENU_BACKGROUND));
        /*
        _language = new Button(new Rectangle(HopMedvedekConstants.screenWidth / 2 - _buttonWidth / 2, 200, _buttonWidth, _buttonHeight), _buttonBackground, _luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_SUBJECT_LANGUAGE][Options.Options.Current.Language]);

        float languageGrade = Data.PlayerData.Current.Year01LanguageLevelCorrectAnswers / (Data.PlayerData.Current.Year01LanguageLevelCorrectAnswers + Data.PlayerData.Current.Year01LanguageLevelWrongAnswers);
        _languageGradeLabel = new Label(_luckiestGuy, "" + languageGrade, new Vector2(_language.Position.X + 70, _language.Position.Y));

        _maths = new Button(new Rectangle(HopMedvedekConstants.screenWidth / 2 - _buttonWidth / 2, 300, _buttonWidth, _buttonHeight), _buttonBackground, _luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_SUBJECT_MATHS][Options.Options.Current.Language]);
        float masthsGrade = Data.PlayerData.Current.Year01MathsLevelCorrectAnswers / (Data.PlayerData.Current.Year01MathsLevelCorrectAnswers + Data.PlayerData.Current.Year01MathsLevelWrongAnswers);
        _languageGradeLabel = new Label(_luckiestGuy, "" + masthsGrade, new Vector2(_maths.Position.X + 70, _maths.Position.Y));
        */
    }
    public void GenerateButtons()
    {
        int i = 200;
        foreach (SubjectType subjectName in _subject.Keys)
        {
            

            float correctAnswers = Data.PlayerData.GetGrades(subjectName)[0];
            float wrongAnswers = Data.PlayerData.GetGrades(subjectName)[1];

            System.Diagnostics.Debug.WriteLine(correctAnswers);
            System.Diagnostics.Debug.WriteLine(wrongAnswers);
            float grade = 0;


            if (wrongAnswers + correctAnswers > 0)
                grade = (correctAnswers / (correctAnswers + wrongAnswers));
            SubjectMenuButton button = new SubjectMenuButton(new Rectangle(HopMedvedekConstants.screenWidth / 2 - 180, i, _buttonWidth, _buttonHeight), _buttonBackground, _luckiestGuy, _subject[subjectName], grade);
            i += 100;
            _buttons.Add(subjectName, button);
            _scene.Add(button);

            //Label label = new Label(_luckiestGuy, "" + (correctAnswers / (correctAnswers + wrongAnswers)).ToString("P0"), new Vector2(button.Position.X + 100, button.Position.Y - 15));
            //label.LayerDepth = 0.9f;
            //_labels.Add(label);
            //_scene.Add(label);
        }
        _scene.Add(_back);
    }
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        foreach (SubjectType subjectName in _subject.Keys)
        {
            if (_buttons[subjectName].WasReleased)
            {
                GamePlay.GamePlay gameplay = new GamePlay.GamePlay(Game, _levelType[subjectName]);
                _hopMedvedek.PushState(gameplay);
            }
        }
    }
}


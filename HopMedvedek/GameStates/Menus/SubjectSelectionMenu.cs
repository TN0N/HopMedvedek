using HopMedvedek.Data.Strings;
using HopMedvedek.Data;
using HopMedvedek.Gui.Elements;
using Microsoft.Xna.Framework;
using Artificial.Artificial.Mirage;
using System.Collections.Generic;
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

        }
        _scene.Add(_back);
    }
    public override void Reload()
    {
        foreach (SubjectType subjectName in _subject.Keys)
        {
            _buttons[subjectName].Label.Text = _subject[subjectName];
        }
        _back.Label.Text = Strings.Localizations[StringKey.HOP_MEDVEDEK_COMMON_MENU_BACK][Options.Options.Current.Language];
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


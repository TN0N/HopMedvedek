using Artificial.Artificial.Mirage;
using HopMedvedek.Data;
using HopMedvedek.Data.Strings;
using HopMedvedek.Gui.Elements;
using HopMedvedek.Level;
using HopMedvedek.Level.Levels;
using HopMedvedek.Options;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
namespace HopMedvedek.GameStates.Menus;

public class Year01SubjectSelectionMenu : SubjectSelectionMenu
{
    public Year01SubjectSelectionMenu(Game game) : base(game)
    {
        _subject = new Dictionary<SubjectType, string>
        {
            { SubjectType.Year01Language, Strings.Localizations[StringKey.HOP_MEDVEDEK_SUBJECT_LANGUAGE][Options.Options.Current.Language] },
            { SubjectType.Year01Maths, Strings.Localizations[StringKey.HOP_MEDVEDEK_SUBJECT_MATHS][Options.Options.Current.Language] }
        };
        _levelType = new Dictionary<SubjectType, Type>
        {
            { SubjectType.Year01Language, typeof(Year01LanguageLevel) },
            { SubjectType.Year01Maths, typeof(Year01MathLevel) }
        };
        //base.Initialize();
        GenerateButtons();
    }
}

using HopMedvedek.Data;
using HopMedvedek.Questions;
using Microsoft.Xna.Framework;

namespace HopMedvedek.Level.Levels;

public class Year01LanguageLevel : LevelBase
{
    public Year01LanguageLevel(Game game) : base(game)
    {
        _questionSheet = new Year01_Language_Question_Sheet();
    }
}

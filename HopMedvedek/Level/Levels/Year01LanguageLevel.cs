using HopMedvedek.Data;
using HopMedvedek.Questions;
using Microsoft.Xna.Framework;

namespace HopMedvedek.Level.Levels;

public class Year01LanguageLevel : LevelBase
{
    public Year01LanguageLevel(Game game) : base(game)
    {
        int RightX = HopMedvedekConstants.screenWidth;
        int BottomY = HopMedvedekConstants.screenHeight;

        int midX = HopMedvedekConstants.screenWidth / 2;
        int midY = HopMedvedekConstants.screenHeight / 2;

        _questionSheet = new Year01_Language_Question_Sheet();
        
        _ground.Position = new Vector2(midX, BottomY - _ground.Height / 2);
        _tree.Position = new Vector2(_ground.Position.X, _ground.Position.Y - _ground.Height/1.75f);
        _bear.Position = _tree.Position;

    }
}

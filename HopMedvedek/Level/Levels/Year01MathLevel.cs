using HopMedvedek.Data;
using HopMedvedek.Questions;
using Microsoft.Xna.Framework;

namespace HopMedvedek.Level.Levels;

public class Year01MathLevel : LevelBase
{
    public Year01MathLevel(Game game) : base(game)
    {

        _questionSheet = new Year01_Maths_Question_Sheet();
    }
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        ((Year01_Maths_Question_Sheet)_questionSheet).GenerateQuestions();
    }
}

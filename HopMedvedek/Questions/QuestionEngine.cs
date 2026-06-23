using HopMedvedek.Gui.Hud;
using HopMedvedek.Level;
using HopMedvedek.Questions;
using HopMedvedek.Scene.Objects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
namespace HopMedvedek.Graphics;

public class QuestionEngine : GameComponent
{
    protected LevelBase _level;
    protected GameHud _gameHud;
    private TimeSpan _lastGenerationRuntime = TimeSpan.Zero;
    protected string _correctAnswer, _wrongAnswer;
    protected List<Question> _levelQuesitons;


    public QuestionEngine(Game game, LevelBase level, GameHud gameHud) : base(game)
    {
        _level = level;
        _gameHud = gameHud;

        _levelQuesitons = _level.QuestionSheet.Questions.OrderBy(x => Random.Shared.Next()).ToList();

    }
    public override void Update(GameTime gameTime)
    {
        if (_levelQuesitons.Count < 2)
        {
            _levelQuesitons = _level.QuestionSheet.Questions.OrderBy(x => Random.Shared.Next()).ToList();
        }
        if (_level.Tree.CorrectAnswer == null &&
            _level.Tree.WrongAnswer == null &&
            _level.Bear.Position.Y > 1500 &&
            gameTime.TotalGameTime - _lastGenerationRuntime >= TimeSpan.FromSeconds(3))
        {
            _lastGenerationRuntime = gameTime.TotalGameTime;

            _correctAnswer = _levelQuesitons.First().QuestionAnswer;
            _levelQuesitons.RemoveAt(0);

            _wrongAnswer = _levelQuesitons.OrderBy(x => Random.Shared.Next()).ToList().First().QuestionAnswer;

            _level.Tree.PrepareQuestion(_correctAnswer, _wrongAnswer)
        }
    }
    public override void Initialize()
    {
        base.Initialize();
    }
}

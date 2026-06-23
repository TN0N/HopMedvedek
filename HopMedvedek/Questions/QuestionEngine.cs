using Artificial.Artificial.Mirage;
using HopMedvedek.Data;
using HopMedvedek.Gui.Hud;
using HopMedvedek.Level;
using HopMedvedek.Questions;
using HopMedvedek.Scene.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
    protected Label _correctAnswerLabel, _wrongAnswerLabel;
    protected Leaves _correctLeaf, _wrongLeaf;
    protected List<Question> _levelQuesitons;
    protected SpriteFont _font;
    

    public QuestionEngine(Game game, LevelBase level, GameHud gameHud) : base(game)
    {
        _level = level;
        _gameHud = gameHud;

        _levelQuesitons = _level.QuestionSheet.Questions.OrderBy(x => Random.Shared.Next()).ToList();
        _font = Game.Content.Load<SpriteFont>(HopMedvedekConstants.HOP_MEDVEDEK_LUCKIESTGUY_FONT);

        
    }
    public override void Update(GameTime gameTime)
    {
        if (_levelQuesitons.Count < 2)
        {
            _levelQuesitons = _level.QuestionSheet.Questions.OrderBy(x => Random.Shared.Next()).ToList();
        }
        if (_correctLeaf == null && _wrongLeaf == null
            && _level.Bear.Position.Y < -100 &&
            gameTime.TotalGameTime - _lastGenerationRuntime >= TimeSpan.FromSeconds(3))
        {
            System.Diagnostics.Debug.WriteLine("Generating question");
            _lastGenerationRuntime = gameTime.TotalGameTime;


            Question question = _levelQuesitons.First();

            _correctAnswer = question.QuestionAnswer;
            _levelQuesitons.RemoveAt(0);

            _wrongAnswer = _levelQuesitons.OrderBy(x => Random.Shared.Next()).ToList().First().QuestionAnswer;

            int leavesCount = _level.Tree.Branches.Count;
            _correctLeaf = _level.Tree.Branches[leavesCount - 1].Leaves;
            _wrongLeaf = _level.Tree.Branches[leavesCount - 2].Leaves;

            _correctAnswerLabel = new Label(_font, _correctAnswer, new Vector2(_correctLeaf.Position.X, _correctLeaf.Position.Y));
            _wrongAnswerLabel = new Label(_font, _wrongAnswer, new Vector2(_wrongLeaf.Position.X, _wrongLeaf.Position.Y));
            _correctAnswerLabel.LayerDepth = 0.9f;
            _wrongAnswerLabel.LayerDepth = 0.9f;

            _correctAnswerLabel.HorizontalAlign = HorizontalAlign.Center;
            _correctAnswerLabel.VerticalAlign = VerticalAlign.Bottom;
            _wrongAnswerLabel.HorizontalAlign = HorizontalAlign.Center;
            _wrongAnswerLabel.VerticalAlign = VerticalAlign.Bottom;

            _level.Scene.Add(_correctAnswerLabel);
            _level.Scene.Add(_wrongAnswerLabel);

            _gameHud.ShowQuestionImage(_level.QuestionSheet.QuestionSheetTextures, question.QuestionImageBounds);
        }
        else if (_correctLeaf != null && _wrongLeaf != null)
        {
            if (_correctLeaf.PlayerLanded)
            {
                System.Diagnostics.Debug.WriteLine("Correct!");
                _correctLeaf = null;
                _wrongLeaf = null;

                _level.Scene.Remove(_correctAnswerLabel);
                _level.Scene.Remove(_wrongAnswerLabel);
                _gameHud.HideQuestionImage();
                return;
            }

            if (_wrongLeaf.PlayerLanded)
            {
                System.Diagnostics.Debug.WriteLine("Incorrect!");
                _correctLeaf = null;
                _wrongLeaf = null;

                _level.Scene.Remove(_correctAnswerLabel);
                _level.Scene.Remove(_wrongAnswerLabel);
                _gameHud.HideQuestionImage();
                return;
            }
                
        }
    }
    public override void Initialize()
    {
        _gameHud.Scene.SceneTextureData.Add(_level.QuestionSheet.QuestionSheetTextures, Game.Content.Load<Texture2D>(_level.QuestionSheet.QuestionSheetTextures));
        base.Initialize();
    }
}

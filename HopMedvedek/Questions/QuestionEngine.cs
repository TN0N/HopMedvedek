using Artificial.Artificial.Mirage;
using Artificial.Artificial.Utils;
using Express.Graphics;
using Express.Scores;
using HopMedvedek.Audio;
using HopMedvedek.Data;
using HopMedvedek.Data.Strings;
using HopMedvedek.Gui.Elements;
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

public enum RewardType
{
    Heart,
    Coin,
    Pinecone,
    UltraJump,
    Invincibility,
    Jetpack,
    None
}
public class QuestionEngine : GameComponent
{
    protected LevelBase _level;
    protected GameHud _gameHud;
    private TimeSpan _lastGenerationRuntime = TimeSpan.Zero;
    protected string _correctAnswerString, _wrongAnswerString;
    protected StringKey _correctAnswer, _wrongAnswer, _questionText;
    protected Label _correctAnswerLabel, _wrongAnswerLabel;
    protected Branch _correctBranch, _wrongBranch;
    protected List<Question> _levelQuesitons;
    protected SpriteFont _font;

    protected Dictionary<RewardType, Sprite> _rewardImages;

    
    public QuestionEngine(Game game, LevelBase level, GameHud gameHud) : base(game)
    {
        _level = level;
        _gameHud = gameHud;

        _levelQuesitons = _level.QuestionSheet.Questions.OrderBy(x => Random.Shared.Next()).ToList();
        _font = Game.Content.Load<SpriteFont>(HopMedvedekConstants.HOP_MEDVEDEK_LUCKIESTGUY_FONT);

        _rewardImages = new Dictionary<RewardType, Sprite>()
        {
            [RewardType.Heart] = new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_MENU_ELEMENTS, new Rectangle(358,134,15,16), new Vector2(7, 8)),
            [RewardType.Coin] = new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_MENU_ELEMENTS, new Rectangle(358,118,15,16), new Vector2(7,8)),
            [RewardType.Pinecone] = new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_MENU_ELEMENTS, new Rectangle(88,238,30,32), new Vector2(15,16)),
            [RewardType.UltraJump] = new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_MENU_ELEMENTS, new Rectangle(447,99,19,19), new Vector2(9, 9)), // ultrajump
            [RewardType.Invincibility] = new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_MENU_ELEMENTS, new Rectangle(466,99,19,19), new Vector2(9, 9)), // invincibility
            [RewardType.Jetpack] = new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_MENU_ELEMENTS, new Rectangle(485,99,19,19), new Vector2(9, 9)) // jetpack
        };
    }
    private void GivePoints(bool correct)
    {
        switch (_level.QuestionSheet)
        {
            case Year01_Language_Question_Sheet:
                if (correct)
                    Scores.year01LanguageLevelCorrectAnswers++;
                else
                    Scores.year01LanguageLevelWrongAnswers++;
                break;
            case Year01_Maths_Question_Sheet:
                if (correct)
                    Scores.year01MathsLevelCorrectAnswers++;
                else
                    Scores.year01MathsLevelWrongAnswers++;
                break;
        }
    }
    private void GenerateQuestions(GameTime gameTime)
    {
        

        if (_correctBranch != null || _wrongBranch != null || _level.Bear.Position.Y >= -100 || gameTime.TotalGameTime - _lastGenerationRuntime < TimeSpan.FromSeconds(3))
            return;


        if (SRandom.Int(1) <= 0.5f)
        {
            _correctBranch = _level.Tree.Branches[_level.Tree.Branches.Count - 1];
            _wrongBranch = _level.Tree.Branches[_level.Tree.Branches.Count - 2];
        }
        else
        {
            _correctBranch = _level.Tree.Branches[_level.Tree.Branches.Count - 2];
            _wrongBranch = _level.Tree.Branches[_level.Tree.Branches.Count - 1];
        }


        _lastGenerationRuntime = gameTime.TotalGameTime;
        // Get the first question from the list and then remove it from the list
        Question question = _levelQuesitons.First();
        if (question.QuestionTextString != null)
        {
            _correctAnswerString = question.QuestionAnswerString;
            _levelQuesitons.RemoveAt(0);
            _wrongAnswerString = _levelQuesitons.OrderBy(x => Random.Shared.Next()).ToList().First().QuestionAnswerString;
            _correctAnswerLabel = new Label(_font, _correctAnswerString, new Vector2(_correctBranch.Leaves.Position.X, _correctBranch.Leaves.Position.Y));
            _wrongAnswerLabel = new Label(_font, _wrongAnswerString, new Vector2(_wrongBranch.Leaves.Position.X, _wrongBranch.Leaves.Position.Y));
        }
        else
        {
            _correctAnswer = question.QuestionAnswer;
            _levelQuesitons.RemoveAt(0);
            // Shuffle the other questions in the list and select the first to get a wrong answer
            _wrongAnswer = _levelQuesitons.OrderBy(x => Random.Shared.Next()).ToList().First().QuestionAnswer;
            _correctAnswerLabel = new Label(_font, Strings.Localizations[_correctAnswer][Options.Options.Current.Language], new Vector2(_correctBranch.Leaves.Position.X, _correctBranch.Leaves.Position.Y));
            _wrongAnswerLabel = new Label(_font, Strings.Localizations[_wrongAnswer][Options.Options.Current.Language], new Vector2(_wrongBranch.Leaves.Position.X, _wrongBranch.Leaves.Position.Y));
        }
       

        // Randomly assign the correct and wrong answers to the leaves
        

        // Add labels to the leaves
        
        _correctAnswerLabel.LayerDepth = 0.9f;
        _wrongAnswerLabel.LayerDepth = 0.9f;

        _correctAnswerLabel.HorizontalAlign = HorizontalAlign.Center;
        _correctAnswerLabel.VerticalAlign = VerticalAlign.Bottom;
        _wrongAnswerLabel.HorizontalAlign = HorizontalAlign.Center;
        _wrongAnswerLabel.VerticalAlign = VerticalAlign.Bottom;

        _level.Scene.Add(_correctAnswerLabel);
        _level.Scene.Add(_wrongAnswerLabel);


        SoundEngine.Play(SoundEffectType.OwlQuestion, null, null, Options.Options.Current.GameVolume);
        // Show the image on the gameHud
        if (question.QuestionTextString != null)
            _gameHud.ShowQuestionImage(_level.QuestionSheet.QuestionSheetTextures, question.QuestionImageBounds, question.QuestionTextString);
        else
            _gameHud.ShowQuestionImage(_level.QuestionSheet.QuestionSheetTextures, question.QuestionImageBounds, question.QuestionText);
    }
    private void GiveReward(GameTime gameTime)
    {
        /*
         Rewards:
        + 10% 1-2 Hearts, 
        + 26% 3-10 Coins, 
        + 23% 1-3 Pinecones
        + 15% Ultra Jump,
        + 15% Invincibility for 10 seconds,
        + 11% Jetpack
         */
        int r = SRandom.Int(100);

        if (r < 10) // 2-4 Hearts;
        {
            int hearts = SRandom.Int(2) + 2;
            _level.Bear.PlayerHP += hearts;

            _gameHud.ShowReward(_rewardImages[RewardType.Heart], hearts);
        }
        else if (r < 36) // 3-10 coins
        {
            int coins = SRandom.Int(7) + 3;
            _level.Bear.PlayerCoins += coins;

            _gameHud.ShowReward(_rewardImages[RewardType.Coin], coins);
        }
        else if (r < 59) // 3-5 pinecones
        {
            int pinecones = SRandom.Int(2) + 3;
            _level.Bear.PlayerPinecones += pinecones;

            _gameHud.ShowReward(_rewardImages[RewardType.Pinecone], pinecones);

        }
        else if (r < 74) // Ultra jump
        {
            _level.Bear.ActiveReward = RewardType.UltraJump;
            _gameHud.ShowReward(_rewardImages[RewardType.UltraJump], null);
            _gameHud.ShowActiveReward(_rewardImages[RewardType.UltraJump], HopMedvedekConstants.HOP_MEDVEDEK_POWER_UP_DURATION, gameTime);
        }
        else if (r < 89) // Invincibility
        {
            _level.Bear.ActiveReward = RewardType.Invincibility;
            _gameHud.ShowReward(_rewardImages[RewardType.Invincibility], null);
            _gameHud.ShowActiveReward(_rewardImages[RewardType.Invincibility], HopMedvedekConstants.HOP_MEDVEDEK_POWER_UP_DURATION, gameTime);
        }
        else if (r <= 100) // Jetpack
        {
            _level.Bear.ActiveReward = RewardType.Jetpack;
            _gameHud.ShowReward(_rewardImages[RewardType.Jetpack], null);
            _gameHud.ShowActiveReward(_rewardImages[RewardType.Jetpack], HopMedvedekConstants.HOP_MEDVEDEK_POWER_UP_DURATION, gameTime);
        }

    }
    private void CheckAnswer(GameTime gameTime)
    {
        if ((_correctBranch == null || _wrongBranch == null) || (!_correctBranch.Leaves.PlayerLanded && !_wrongBranch.Leaves.PlayerLanded))
            return;
        if (_correctBranch.Leaves.PlayerLanded)
        {
            SoundEngine.Play(SoundEffectType.CorrectAnswer, null, null, Options.Options.Current.GameVolume);
            GiveReward(gameTime);
            _gameHud.HideQuestionImage(true);
            GivePoints(true);
        }

        if (_wrongBranch.Leaves.PlayerLanded)
        {
            SoundEngine.Play(SoundEffectType.WrongAnswer, null, null, Options.Options.Current.GameVolume);
            _gameHud.HideQuestionImage(false);
            GivePoints(false);
        }
        
        _correctBranch = null;
        _wrongBranch = null;

        _level.Scene.Remove(_correctAnswerLabel);
        _level.Scene.Remove(_wrongAnswerLabel);
        
    }
    public override void Update(GameTime gameTime)
    {
        if (_levelQuesitons.Count < 2)
            _levelQuesitons = _level.QuestionSheet.Questions.OrderBy(x => Random.Shared.Next()).ToList();

        if (!_level.Tree.Branches.Contains(_correctBranch))
        {
            _correctBranch = null;
            _level.Scene.Remove(_correctAnswerLabel);
        }
        if (!_level.Tree.Branches.Contains(_wrongBranch))
        {
            _wrongBranch = null;
            _level.Scene.Remove(_wrongAnswerLabel);
        }

        if (_wrongBranch == null && _correctBranch == null)
            _gameHud.HideQuestionImage(null);


        //System.Diagnostics.Debug.WriteLine("Generating question");
        GenerateQuestions(gameTime);
        CheckAnswer(gameTime);
    }

    public StringKey CorrectAnswer
    {
        get => _correctAnswer;
    }
    public StringKey WrongAnswer
    {
        get => _wrongAnswer;
    }
    public string CorrectAnswerString
    {
        get => _correctAnswerString;
    }
    public string WrongAnswerString
    {
        get => _wrongAnswerString;
    }

    public Label CorrectAnswerLabel
    { 
        get => _correctAnswerLabel;
        set => _correctAnswerLabel = value;
    }
    public Label WrongAnswerLabel
    {
        get => _wrongAnswerLabel;
        set => _wrongAnswerLabel = value;
    }

    public GameHud GameHud
    {
        get => _gameHud;
        set => _gameHud = value;
    }
    public override void Initialize()
    {
        _gameHud.Scene.SceneTextureData.Add(_level.QuestionSheet.QuestionSheetTextures, Game.Content.Load<Texture2D>(_level.QuestionSheet.QuestionSheetTextures));
        base.Initialize();
    }
}

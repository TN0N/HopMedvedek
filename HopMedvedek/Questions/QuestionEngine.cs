using Artificial.Artificial.Mirage;
using Artificial.Artificial.Utils;
using Express.Graphics;
using HopMedvedek.Audio;
using HopMedvedek.Data;
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
    protected string _correctAnswer, _wrongAnswer;
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
            [RewardType.Heart] = new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_HEART_TEXTURE, new Rectangle(0,0,15,16), new Vector2(7, 8)),
            [RewardType.Coin] = new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_COIN_TEXTURE, new Rectangle(0,0,15,16), new Vector2(7,8)),
            [RewardType.Pinecone] = new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_PINECONE_ROTATE_TEXTURE, new Rectangle(0,0,30,32), new Vector2(15,16)),
            [RewardType.UltraJump] = new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_REWARDS_TEXTURE, new Rectangle(0,0,19,19), new Vector2(9, 9)), // ultrajump
            [RewardType.Invincibility] = new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_REWARDS_TEXTURE, new Rectangle(19,0,19,19), new Vector2(9, 9)), // invincibility
            [RewardType.Jetpack] = new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_REWARDS_TEXTURE, new Rectangle(38,0,19,19), new Vector2(9, 9)) // jetpack
        };
    }
    private void GenerateQuestions(GameTime gameTime)
    {
        

        if (_correctBranch != null || _wrongBranch != null || _level.Bear.Position.Y >= -100 || gameTime.TotalGameTime - _lastGenerationRuntime < TimeSpan.FromSeconds(3))
            return;
        _lastGenerationRuntime = gameTime.TotalGameTime;
        // Get the first question from the list and then remove it from the list
        Question question = _levelQuesitons.First(); 
        _correctAnswer = question.QuestionAnswer;
        _levelQuesitons.RemoveAt(0);

        // Shuffle the other questions in the list and select the first to get a wrong answer
        _wrongAnswer = _levelQuesitons.OrderBy(x => Random.Shared.Next()).ToList().First().QuestionAnswer;

        // Randomly assign the correct and wrong answers to the leaves
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

        // Add labels to the leaves
        _correctAnswerLabel = new Label(_font, _correctAnswer, new Vector2(_correctBranch.Leaves.Position.X, _correctBranch.Leaves.Position.Y));
        _wrongAnswerLabel = new Label(_font, _wrongAnswer, new Vector2(_wrongBranch.Leaves.Position.X, _wrongBranch.Leaves.Position.Y));
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

        if (r < 10) // 1-2 Hearts;
        {
            int hearts = SRandom.Int(1) + 1;
            System.Diagnostics.Debug.WriteLine("Reward: " + hearts + " hearts");
            _level.Bear.PlayerHP += hearts;

            _gameHud.ShowReward(_rewardImages[RewardType.Heart], hearts);
        }
        else if (r < 36) // 3-10 coins
        {
            int coins = SRandom.Int(7) + 3;
            System.Diagnostics.Debug.WriteLine("Reward: " + coins + " coins");
            _level.Bear.PlayerCoins += coins;

            _gameHud.ShowReward(_rewardImages[RewardType.Coin], coins);
        }
        else if (r < 59) // 1-3 pinecones
        {
            int pinecones = SRandom.Int(2) + 1;
            System.Diagnostics.Debug.WriteLine("Reward: " + pinecones + " pinecones");
            _level.Bear.PlayerPinecones += pinecones;

            _gameHud.ShowReward(_rewardImages[RewardType.Pinecone], pinecones);

        }
        else if (r < 74) // Ultra jump
        {
            System.Diagnostics.Debug.WriteLine("Reward: ultrajump");
            _level.Bear.ActiveReward = RewardType.UltraJump;
            _gameHud.ShowReward(_rewardImages[RewardType.UltraJump], null);
            _gameHud.ShowActiveReward(_rewardImages[RewardType.UltraJump], HopMedvedekConstants.HOP_MEDVEDEK_POWER_UP_DURATION, gameTime);
        }
        else if (r < 89) // Invincibility
        {
            System.Diagnostics.Debug.WriteLine("Reward: invinsibility");
            _level.Bear.ActiveReward = RewardType.Invincibility;
            _gameHud.ShowReward(_rewardImages[RewardType.Invincibility], null);
            _gameHud.ShowActiveReward(_rewardImages[RewardType.Invincibility], HopMedvedekConstants.HOP_MEDVEDEK_POWER_UP_DURATION, gameTime);
        }
        else if (r <= 100) // Jetpack
        {
            System.Diagnostics.Debug.WriteLine("Reward: jetpack");
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
            System.Diagnostics.Debug.WriteLine("Correct!");
            GiveReward(gameTime);
            _gameHud.HideQuestionImage(true);
        }

        if (_wrongBranch.Leaves.PlayerLanded)
        {
            SoundEngine.Play(SoundEffectType.WrongAnswer, null, null, Options.Options.Current.GameVolume);
            System.Diagnostics.Debug.WriteLine("Incorrect!");
            _gameHud.HideQuestionImage(false);
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
    public override void Initialize()
    {
        _gameHud.Scene.SceneTextureData.Add(_level.QuestionSheet.QuestionSheetTextures, Game.Content.Load<Texture2D>(_level.QuestionSheet.QuestionSheetTextures));
        base.Initialize();
    }
}

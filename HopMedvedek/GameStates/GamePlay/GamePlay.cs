using Artificial.Artificial.Utils;
using Express.Graphics;
using Express.Scores;
using HopMedvedek.Audio;
using HopMedvedek.Data;
using HopMedvedek.Data.Strings;
using HopMedvedek.Entities;
using HopMedvedek.GameStates.Menus;
using HopMedvedek.Graphics;
using HopMedvedek.Gui.Hud;
using HopMedvedek.Level;
using HopMedvedek.Physics;
using Microsoft.Xna.Framework;
using System;

namespace HopMedvedek.GameStates.GamePlay;


public class GamePlay : GameState
{
    private LevelBase _level;
    private Player _player;

    private GameHud _hud;
    private Renderer _gameRenderer;
    private Renderer _hudRenderer;
    private PhysicsEngine _physics;
    private DebugRenderer _debugRenderer;
    private QuestionEngine _questionEngine;
    private Type _levelClass;

    private FpsComponent _fpsComponent;
    public GamePlay(Game game, Type levelClass) : base(game)
    {
        _levelClass = levelClass;
        System.Diagnostics.Debug.WriteLine("Creating new gameplay");
        _startInit(levelClass);
        _player = new Player(game, _level.Bear);
        _finishInit();
    }
    private void _startInit(Type levelClass)
    {
        System.Diagnostics.Debug.WriteLine("Creating new level");
        _level = Activator.CreateInstance(levelClass, Game) as LevelBase;
        
    }
    private void _finishInit()
    {
        _hud = new GameHud(Game, _level);
        _physics = new PhysicsEngine(Game, _level, _hud);
        
        _level.Scene.CameraMatrix = Matrix.CreateScale((float)Game.Window.ClientBounds.Width / HopMedvedekConstants.screenWidth, (float)Game.Window.ClientBounds.Height / HopMedvedekConstants.screenHeight, 1f);

        _gameRenderer = new Renderer(Game, _level.Scene);
        _fpsComponent = new FpsComponent(Game);
        
        _questionEngine = new QuestionEngine(Game, _level, _hud);
        _debugRenderer = new DebugRenderer(Game, _level.Scene);
        _hudRenderer = new Renderer(Game, _hud.Scene);
        _hudRenderer.ClearScreen = false;
        _gameRenderer.DrawOrder = 1;
        _hudRenderer.DrawOrder = 2;

        _player.UpdateOrder =       0;
        _physics.UpdateOrder =      1;
        _questionEngine.UpdateOrder = 2;
        _level.UpdateOrder =        3;
        _level.Scene.UpdateOrder =  4;
        UpdateOrder =               5;

        
    }
    public override void Activate()
    {
        Game.Components.Add(_level);
        
        Game.Components.Add(_hud);
        _hud.Activate();
        //Game.Components.Add(_debugRenderer);
        Game.Components.Add(_hudRenderer);
        Game.Components.Add(_gameRenderer);
        Game.Components.Add(_physics);
        Game.Components.Add(_questionEngine);
        Game.Components.Add(_player);
        //Game.Components.Add(_fpsComponent);

        // Add all gameComponents created by level.Scene
        /*foreach (var item in _level.Scene)
            if (item is GameComponent gameComponent)
                Game.Components.Add(gameComponent);*/
    }
    public override void Deactivate()
    {
        Game.Components.Remove(_level);
        _hud.Deactivate();
        Game.Components.Remove(_hud);
        //Game.Components.Remove(_debugRenderer);
        Game.Components.Remove(_hudRenderer);
        Game.Components.Remove(_gameRenderer);
        Game.Components.Remove(_physics);
        Game.Components.Remove(_questionEngine);
        Game.Components.Remove(_player);
        //Game.Components.Remove(_fpsComponent);

        // Deactivate all gameComponents created by level.Scene
        /*foreach (var item in _level.Scene)
            if (item is GameComponent gameComponent)
                Game.Components.Remove(gameComponent);*/
    }
    public override void Reload()
    {
        if (_questionEngine.CorrectAnswerLabel != null && _questionEngine.CorrectAnswerString == null)
            _questionEngine.CorrectAnswerLabel.Text = Strings.Localizations[_questionEngine.CorrectAnswer][Options.Options.Current.Language];
        if (_questionEngine.WrongAnswerLabel != null && _questionEngine.WrongAnswerString == null)
            _questionEngine.WrongAnswerLabel.Text = Strings.Localizations[_questionEngine.WrongAnswer][Options.Options.Current.Language];
        if (_questionEngine.CorrectAnswerString == null)
            _hud.Reload();

    }
    public Type LevelClass
    {
        get => _levelClass; 
    }
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        if (_level.Bear.PlayerHP < 1)
        {
            
            Data.PlayerData.Current.HighScore = Math.Max(Data.PlayerData.Current.HighScore, Scores.score);
            Data.PlayerData.Current.Year01LanguageLevelCorrectAnswers += Scores.year01LanguageLevelCorrectAnswers;
            Data.PlayerData.Current.Year01LanguageLevelWrongAnswers += Scores.year01LanguageLevelWrongAnswers;
            Data.PlayerData.Current.Year01MathsLevelCorrectAnswers += Scores.year01MathsLevelCorrectAnswers;
            Data.PlayerData.Current.Year01MathsLevelWrongAnswers += Scores.year01MathsLevelWrongAnswers;
            Data.PlayerData.Current.Coins += _level.Bear.PlayerCoins;
            Data.PlayerData.SaveData();
            SoundEngine.Play(SoundEffectType.BearDie, null, null, Options.Options.Current.GameVolume);
            _hopMedvedek.PushState(new DeathMenu(Game, _levelClass));
        }
    }
}

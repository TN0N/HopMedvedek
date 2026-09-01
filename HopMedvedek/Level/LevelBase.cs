using Artificial.Artificial.Mirage;
using Express.Graphics;
using Express.Scene;
using Express.Scene.Objects;
using Express.Scores;
using HopMedvedek.Audio;
using HopMedvedek.Data;
using HopMedvedek.GameStates.Menus;
using HopMedvedek.Graphics;
using HopMedvedek.Questions;
using HopMedvedek.Scene.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace HopMedvedek.Level;
/// <summary>
/// Defines the base class the defines levels and all its components. 
/// </summary>
public class LevelBase : GameComponent
{
    //protected HopMedvedek _hopMedvedek;
    protected SimpleScene _scene;
    protected Bear _bear;
    protected Tree _tree;
    protected Ground _ground;
    // protected List<Crow> _crows;
    protected Dictionary<string, Texture2D> _textureData;
    protected QuestionSheet _questionSheet;

    protected Vector2 _bearSpawn;
    protected Vector2 _treeBaseSpawn;
    protected Vector2 _groundSpawn;

    

    protected LevelBase(Game game): base(game)
    {
        _scene = new SimpleScene(game);
        _tree = new Tree(game, this);

        _bear = new Bear(game, this);
        _ground = new Ground(game);

        _scene.Add(_bear);
        _scene.Add(_tree);
        _scene.Add(_ground);

        int BottomY = HopMedvedekConstants.screenHeight;
        int midX = HopMedvedekConstants.screenWidth / 2;
        _ground.Position = new Vector2(midX, BottomY - _ground.Height / 2);
        _tree.Position = new Vector2(_ground.Position.X, _ground.Position.Y - _ground.Height / 2);
        _bear.Position = _tree.Position;

        _scene.SceneTextureData = new Dictionary<string, Texture2D>
        {
            [HopMedvedekConstants.HOP_MEDVEDEK_DEFAULT_TEXTURE] = Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_DEFAULT_TEXTURE),
            [HopMedvedekConstants.HOP_MEDVEDEK_BEAR_TEXTURE] = Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_BEAR_TEXTURE),
            [HopMedvedekConstants.HOP_MEDVEDEK_BEAR_RED_TEXTURE] = Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_BEAR_RED_TEXTURE),
            [HopMedvedekConstants.HOP_MEDVEDEK_BEAR_GREEN_TEXTURE] = Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_BEAR_GREEN_TEXTURE),
            [HopMedvedekConstants.HOP_MEDVEDEK_BEAR_BLUE_TEXTURE] = Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_BEAR_BLUE_TEXTURE),
            [HopMedvedekConstants.HOP_MEDVEDEK_BEAR_RAINBOW_TEXTURE] = Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_BEAR_RAINBOW_TEXTURE),
            [HopMedvedekConstants.HOP_MEDVEDEK_GRASS_TEXTURE] = Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_GRASS_TEXTURE),
            [HopMedvedekConstants.HOP_MEDVEDEK_MENU_ELEMENTS] = Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_MENU_ELEMENTS),
            [HopMedvedekConstants.HOP_MEDVEDEK_SCENE_ELEMENTS] = Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_SCENE_ELEMENTS)
        };
    }
    public override void Initialize()
    {
        base.Initialize();
        Scores.score = 0;
        Scores.year01LanguageLevelCorrectAnswers = 0;
        Scores.year01LanguageLevelWrongAnswers = 0;
        Scores.year01MathsLevelCorrectAnswers = 0;
        Scores.year01MathsLevelWrongAnswers = 0;
        //_bear.Position = _bearSpawn;
        //_ground.Position = _groundSpawn;
        //_tree.Position = _treeBaseSpawn;

        if (!Game.Components.Contains(_scene))
            Game.Components.Add(_scene);
        
    }
    public override void Update(GameTime gameTime)
    {
        foreach (var item in _scene)
        { 
            var updateable = item as ICustomUpdate;
            updateable?.Update(gameTime);
        }
        //Scores.score = (int)(-_bear.Position.Y + 703);
        Scores.score = (int)MathF.Max(Scores.score, (int)-_bear.Position.Y + 700);
        Matrix matrix = Matrix.CreateScale((float)Game.Window.ClientBounds.Width / HopMedvedekConstants.screenWidth, (float)Game.Window.ClientBounds.Height / HopMedvedekConstants.screenHeight, 1f);

        _scene.CameraMatrix = Matrix.CreateTranslation(0, -(MathF.Round(_bear.Position.Y) - 720), 0) * matrix;

        //_scene.CameraMatrix.M42 = -(_bear.Position.Y - 720);

        if (_bear.Position.X + _bear.Width/2 < 0)
            _bear.Position = new Vector2(HopMedvedekConstants.screenWidth + _bear.Width/2, _bear.Position.Y);
        if (_bear.Position.X - _bear.Width / 2 > HopMedvedekConstants.screenWidth)
            _bear.Position = new Vector2(-_bear.Width / 2, _bear.Position.Y);

        if (Math.Abs((int)-_bear.Position.Y + 700 - Scores.score) >= 500)
        {
            _bear.PlayerHP--;
            SoundEngine.Play(SoundEffectType.BearHit, null, null, Options.Options.Current.GameVolume);
            if (_bear.PlayerHP > 0)
            {
                _bear.State = BearState.BearDazed;
                _bear.Velocity.Y = -700;
            }
        }
    }
    public Dictionary<string, Texture2D> TextureData
    {
        get => _textureData;
        set => _textureData = value;
    }

    public SimpleScene Scene { 
        get => _scene;
        set => _scene = value;
    }
    public Bear Bear
    {
        get => _bear;
        set => _bear = value;
    }

    public Tree Tree
    {
        get => _tree;
        set => _tree = value;
    }

    public Ground Ground
    {
        get => _ground;
        set => _ground = value;
    }

    public QuestionSheet QuestionSheet
    { 
        get => _questionSheet;
        set => _questionSheet = value;
    }
    
}

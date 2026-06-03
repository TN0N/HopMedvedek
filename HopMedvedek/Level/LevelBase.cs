using Express.Graphics;
using Express.Scene;
using Express.Scene.Objects;
using Express.Scores;
using HopMedvedek.Data;
using HopMedvedek.Graphics;
using HopMedvedek.Questions;
using HopMedvedek.Scene.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace HopMedvedek.Level;
/// <summary>
/// Defines the base class the defines levels and all its components. 
/// </summary>
public class LevelBase : GameComponent
{
    protected SimpleScene _scene;
    protected Bear _bear;
    protected Tree _tree;
    protected Ground _ground;
    // protected List<Crow> _crows;

    protected Dictionary<string, Texture2D> _textureData;

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



        _scene.SceneTextureData = new Dictionary<string, Texture2D>
        {
            [HopMedvedekConstants.HOP_MEDVEDEK_DEFAULT_TEXTURE] = Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_DEFAULT_TEXTURE),
            [HopMedvedekConstants.HOP_MEDVEDEK_BEAR_TEXTURE] = Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_BEAR_TEXTURE),
            [HopMedvedekConstants.HOP_MEDVEDEK_GRASS_TEXTURE] = Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_GRASS_TEXTURE),
            [HopMedvedekConstants.HOP_MEDVEDEK_NATURE_TEXTURE] = Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_NATURE_TEXTURE),
            [HopMedvedekConstants.HOP_MEDVEDEK_PINECONE_TEXTURE] = Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_PINECONE_TEXTURE),
            [HopMedvedekConstants.HOP_MEDVEDEK_CROW_TEXTURE] = Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_CROW_TEXTURE),
        };
    }
    public override void Initialize()
    {
        base.Initialize();
        Scores.score = 0;

        //_bear.Position = _bearSpawn;
        //_ground.Position = _groundSpawn;
        //_tree.Position = _treeBaseSpawn;

        Game.Components.Add(_scene);
        
    }
    public override void Update(GameTime gameTime)
    {
        foreach (var item in _scene)
        { 
            var updateable = item as ICustomUpdate;
            updateable?.Update(gameTime);
        }
        Scores.score = (int)(-_bear.Position.Y + 1000);
        _scene.CameraMatrix = Matrix.CreateTranslation(0, -(_bear.Position.Y - 720), 0);
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
}

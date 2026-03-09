using Express.Scene;
using Express.Scene.Objects;
using HopMedvedek.Graphics;
using HopMedvedek.Scene.Objects;
using Microsoft.Xna.Framework;

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
    // protected QuestionGenerator _questionGenerator;
    // protected List<Crow> _crows;

    protected Vector2 _bearSpawn;
    protected Vector2 _treeBaseSpawn;

    protected LevelBase(Game game): base(game)
    {
        _scene = new SimpleScene(game);
        _tree = new Tree(game);

        _bear = new Bear();
        _ground = new Ground();

        _scene.Add(_bear);
        _scene.Add(_tree);
        _scene.Add(_ground);
    }
    public override void Initialize()
    {
        base.Initialize();
        Game.Components.Add(_scene);
    }
    public override void Update(GameTime gameTime)
    {
        foreach (var item in _scene)
        { 
            var updateable = item as ICustomUpdate;
            updateable?.Update(gameTime);
        }
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

using Express.Scene;
using Express.Scene.Objects;
using HopMedvedek.Level;
using Microsoft.Xna.Framework;
using System;
namespace HopMedvedek.Scene.Objects;

public class Branch : GameComponent
{
    protected Vector2 _position;
    protected Twig _twig;
    //protected LeafBound _upperLeafBound;
    protected Leaves _leaves;
    //protected LeafBound _lowerLeafBound;
    //protected Coin _coin;
    //protected Answer _answer;
    protected IScene _scene;
    public Branch(Game game, IScene scene, Vector2 position, int width) : base(game)
    {
        _scene = scene;
        _position = position;
        _twig = new Twig(Math.Abs(width));
        
        _twig.Position = new Vector2(_position.X - width/2, _position.Y);

        _leaves = new Leaves(game);
        _leaves.Position = new Vector2(_position.X - width, _position.Y);
        _leaves.PivotPoint = _position;
        //_leaves.CustomOrigin = new Vector2(width, _leaves.Height/2);
        

        _scene.Add(_twig);
        _scene.Add(_leaves);
        //_twig = new Twig(game);
        //_upperLeafBound = new LeafBound(game);
        //_leaf = new Leaf(game);
        //_lowerLeafBound = new LeafBound(game);
        
        //_answer = new Answer(game);
        //_level = level;

        /*_level.Scene.Add(_twig);
        _level.Scene.Add(_upperLeafBound);
        _level.Scene.Add(_leaf);
        _level.Scene.Add(_lowerLeafBound);*/
        
    }
    public override void Update(GameTime time)
    { 
        _leaves.Update(time);
    }
    private void GenerateAnswer()
    {
        /* TODO generate answer */
        //_answer = new Answer(game);
        //_level.Scene.Add(_answer);
    }
    private void GenerateCoin()
    {
        //_coin = new Coin(game);
        //_level.Scene.Add(_coin);
    }
}

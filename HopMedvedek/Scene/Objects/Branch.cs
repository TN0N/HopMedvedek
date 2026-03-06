using HopMedvedek.Level;
using Microsoft.Xna.Framework;
namespace HopMedvedek.Scene.Objects;

public class Branch : GameComponent
{
    protected Vector2 _position;
    //protected Twig _twig;
    //protected LeafBound _upperLeafBound;
    //protected Leaf _leaf;
    //protected LeafBound _lowerLeafBound;
    //protected Coin _coin;
    //protected Answer _answer;
    protected LevelBase _level;
    public Branch(Game game, LevelBase level, Vector2 position) : base(game)
    {
        _position = position;
        //_twig = new Twig(game);
        //_upperLeafBound = new LeafBound(game);
        //_leaf = new Leaf(game);
        //_lowerLeafBound = new LeafBound(game);
        
        //_answer = new Answer(game);
        _level = level;

        /*_level.Scene.Add(_twig);
        _level.Scene.Add(_upperLeafBound);
        _level.Scene.Add(_leaf);
        _level.Scene.Add(_lowerLeafBound);*/
        
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

using Express.Scene;
using HopMedvedek.Level;
using HopMedvedek.Scene.Objects;
using Microsoft.Xna.Framework;
using System.Collections;

namespace HopMedvedek.AI;

public abstract class Behaviour : GameComponent
{
    protected Entity _gameObject;
    protected LevelBase _level;

    protected Behaviour(Game game, Entity gameObject, LevelBase level): base(game)
    { 
        _gameObject = gameObject;
        _level = level;
    }

}

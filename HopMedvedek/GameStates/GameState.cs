using Microsoft.Xna.Framework;

namespace HopMedvedek.GameStates;

public class GameState : GameComponent
{
    protected HopMedvedek _hopMedvedek;

    protected GameState(Game game) : base(game)
    {
        _hopMedvedek = (HopMedvedek)Game;
    }
    public virtual void Activate()
    {
    }
    public virtual void Deactivate()
    {
    }
    public virtual void Reload()
    { 
    }
}

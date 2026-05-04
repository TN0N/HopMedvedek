using HopMedvedek.Level;
using HopMedvedek.Scene.Objects;
using Microsoft.Xna.Framework;

namespace HopMedvedek.AI;
public enum CrowBehaviourState
{
    Flying,
    Attacking,
    Returning,
    Dying
}
public class CrowBehaviour : Behaviour
{
    CrowBehaviourState _currentState = CrowBehaviourState.Flying;
    Vector2 _targetPosition = Vector2.Zero;
    int _prediveHeight = 0;

    int _agroDistance = 150;

    public CrowBehaviour(Game game, Entity entity, LevelBase level) : base(game, entity, level)
    {
        _targetPosition = new Vector2(0, _gameObject.Position.Y);
    }
    public override void Update(GameTime gameTime)
    {
        switch (_currentState)
        {
            case CrowBehaviourState.Flying:
                // If the crow sees the player, target the player (remember the original Y coordinate)
                if (SeesPlayer())
                {
                    _prediveHeight = (int)_gameObject.Position.Y;
                    _targetPosition = _level.Bear.Position;
                    _currentState = CrowBehaviourState.Attacking;

                    break;
                }
                else if (ReachedTarget())
                    BounceFromEdge();
                break;
            case CrowBehaviourState.Attacking:
                if (ReachedTarget())
                {
                    _targetPosition = new Vector2(_gameObject.Position.X, _prediveHeight);
                    _currentState = CrowBehaviourState.Returning;
                }
                break;
            case CrowBehaviourState.Returning:
                if (ReachedTarget())
                {
                    //_gameObject.Position.Y = _prediveHeight;
                    //System.Diagnostics.Debug.WriteLine(_gameObject.Position);
                    _currentState = CrowBehaviourState.Flying;
                }
                break;
            case CrowBehaviourState.Dying:
                break;
        }
        SetVelocity();
        base.Update(gameTime);
    }
    protected void SetVelocity()
    {
        _gameObject.Velocity = Vector2.Normalize(_targetPosition - _gameObject.Position) * 120;
    }
    public bool SeesPlayer()
    {
        return
            _level.Bear.State != BearState.BearDazed &&
            _level.Bear.Position.Y > _gameObject.Position.Y &&
            Vector2.Distance(_level.Bear.Position, _gameObject.Position) <= _agroDistance;
    }
    public bool ReachedTarget()
    {
        return Vector2.Distance(_gameObject.Position, _targetPosition) < 1;
    }
    protected void BounceFromEdge()
    {
        _targetPosition.X = (_gameObject.Position.X < Game.Window.ClientBounds.Width / 2) ? Game.Window.ClientBounds.Width : 0;
    }
}

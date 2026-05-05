using HopMedvedek.Data;
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


    public CrowBehaviour(Game game, Entity entity, LevelBase level) : base(game, entity, level)
    {
        _targetPosition = new Vector2(0, _gameObject.Position.Y);
        SetVelocity();
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
                    SetVelocity();
                    break;
                }
                else if (ReachedTarget())
                    BounceFromEdge();
                    SetVelocity();
                break;
            case CrowBehaviourState.Attacking:
                if (ReachedTarget())
                {
                    _targetPosition = new Vector2(_gameObject.Position.X, _prediveHeight);
                    _currentState = CrowBehaviourState.Returning;
                    SetVelocity();
                }
                break;
            case CrowBehaviourState.Returning:
                if (ReachedTarget())
                {
                    //_gameObject.Position.Y = _prediveHeight;
                    //System.Diagnostics.Debug.WriteLine(_gameObject.Position);
                    _currentState = CrowBehaviourState.Flying;
                    SetVelocity();
                }
                break;
            case CrowBehaviourState.Dying:
                break;
        }
        
        base.Update(gameTime);
    }
    protected void SetVelocity()
    {
        int speed = HopMedvedekConstants.HOP_MEDVEDEK_CROW_FLYING_SPEED;
        switch (_currentState)
        {
            case CrowBehaviourState.Flying:
                speed = HopMedvedekConstants.HOP_MEDVEDEK_CROW_FLYING_SPEED;
                break;
            default:
                speed = HopMedvedekConstants.HOP_MEDVEDEK_CROW_DIVING_SPEED;
                break;

        }
        _gameObject.Velocity = Vector2.Normalize(_targetPosition - _gameObject.Position) * speed;
    }
    public bool SeesPlayer()
    {
        return
            _level.Bear.State != BearState.BearDazed &&
            _level.Bear.Position.Y > _gameObject.Position.Y &&
            Vector2.Distance(_level.Bear.Position, _gameObject.Position) <= HopMedvedekConstants.HOP_MEDVEDEK_CROW_AGRO_DISTANCE;
    }
    public bool ReachedTarget()
    {
        if (_gameObject.Velocity.Y > 0 && _targetPosition.Y <= _gameObject.Position.Y)
            return true;
        if (_gameObject.Velocity.Y < 0 && _targetPosition.Y >= _gameObject.Position.Y)
            return true;
        if (_gameObject.Velocity.X > 0 && _targetPosition.X <= _gameObject.Position.X)
            return true;
        if (_gameObject.Velocity.X < 0 && _targetPosition.X >= _gameObject.Position.X)
            return true;
        return false;
    }
    protected void BounceFromEdge()
    {
        _targetPosition.X = (_gameObject.Position.X < Game.Window.ClientBounds.Width / 2) ? Game.Window.ClientBounds.Width : 0;
    }
}

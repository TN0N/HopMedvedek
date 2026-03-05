namespace Express.Scene.Objects.Movement;

/// <summary>
/// Defines the interface representing a movable body - that being something with position, velocity, acceleration and decay
/// </summary>
public interface IMovable : IPosition, IVelocity, IAcceleration, IDecay
{
}
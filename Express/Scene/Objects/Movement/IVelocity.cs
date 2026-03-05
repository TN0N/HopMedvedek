using Microsoft.Xna.Framework;

namespace Express.Scene.Objects.Movement;
/// <summary>
/// Defines the interface representing a body's velocity.
/// </summary>
public interface IVelocity
{
    /// <summary>
    /// The <see cref="Vector2"/> representing a body's velocity.
    /// </summary>
    ref Vector2 Velocity { get; }
}
using Microsoft.Xna.Framework;

namespace Express.Scene.Objects.Movement;
/// <summary>
/// Defines the interface representing acceleration.
/// </summary>
public interface IAcceleration
{
    /// <summary>
    /// The <see cref="Vector2"/> representing acceleration.
    /// </summary>
    ref Vector2 Acceleration { get; }
}
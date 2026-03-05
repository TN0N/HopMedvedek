using Microsoft.Xna.Framework;

namespace Express.Scene.Objects.Movement;
/// <summary>
/// Defines the interface representing a body's position.
/// </summary>
public interface IPosition
{
    /// <summary>
    /// The <see cref="Vector2"/> representing a body's position.
    /// </summary>
    ref Vector2 Position { get; }
}
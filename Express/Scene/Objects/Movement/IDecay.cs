using Microsoft.Xna.Framework;

namespace Express.Scene.Objects.Movement;
/// <summary>
/// Defines the interface representing velocity decay.
/// </summary>
public interface IDecay
{
    /// <summary>
    /// The <see cref="Vector2"/> representing velocity decay.
    /// </summary>
    ref Vector2 Decay { get; }
}
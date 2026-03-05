using Microsoft.Xna.Framework;

namespace Express.Scene.Objects;
/// <summary>
/// Defines the interface for adding custom update functionality to objects.
/// </summary>
public interface ICustomUpdate
{
    /// <summary>
    /// The Update function that must be defined.
    /// </summary>
    /// <param name="gameTime">The current game time.</param>
    public void Update(GameTime gameTime);
}
namespace Express.Scene.Objects.Colliders;
/// <summary>
/// Defines the interface for a custom collider - custom behaviour after a collision
/// </summary>
public interface ICustomCollider : ICollider
{
    /// <summary>
    /// Determines if an object's collision is valid. Fires during a collision
    /// </summary>
    /// <param name="item">The item the collision happened on.</param>
    /// <param name="defaultValue">The default assumption if a collision is valid.</param>
    /// <returns>A <see langword="bool"/> determining if a collision is valid.</returns>
    public virtual bool CollidingWith(object item, bool defaultValue = true)
    {
        return defaultValue; // override
    }

    /// <summary>
    /// Defines the behaviour of an object after it has collided.
    /// </summary>
    /// <param name="item">The item the collision happened on.</param>
    public virtual void CollidedWith(object item)
    {
        //override
    }
}
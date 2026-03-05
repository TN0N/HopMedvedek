namespace Express.Scene.Objects;
/// <summary>
/// Defines the interface for things that have a lifetime (a duration of aciton).
/// </summary>
public interface ILifetime
{
    /// <summary>
    /// The lifetime of the object. The lifetime is updated every frame and can be used to determine how long the object has been alive and when it should be removed from the scene.
    /// </summary>
    Lifetime Lifetime { get; set; }
}
namespace Express.Scene.Objects.Physical_Properties;
/// <summary>
/// Defines the interface representing a body's gravitational acceleration.
/// </summary>
public interface IGravity
{
    /// <summary>
    /// The <see langword="float"/> representing a body's gravitational acceleration.
    /// </summary>
    float GravitationalAcceleration { get; set; }
}
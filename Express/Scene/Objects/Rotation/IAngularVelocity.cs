namespace Express.Scene.Objects.Rotation;
/// <summary>
/// The public interface representing a body's angular velocity.
/// </summary>
public interface IAngularVelocity
{
    /// <summary>
    /// The <see cref="float"/> representing a body's angular velocity.
    /// </summary>
    float AngularVelocity {get; set;}
}
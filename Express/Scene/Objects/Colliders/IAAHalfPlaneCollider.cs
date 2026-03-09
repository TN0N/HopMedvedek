using Express.Math;

namespace Express.Scene.Objects.Colliders;
/// <summary>
/// Defines the interface for a HalfPlaneCollider.
/// </summary>
public interface IAAHalfPlaneCollider : ICollider
{
    /// <summary>
    /// The HalfPlane representing the collider.
    /// </summary>
    ref AAHalfPlane AAHalfPlane { get; }
    
}
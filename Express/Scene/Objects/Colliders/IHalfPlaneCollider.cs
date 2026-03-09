using Express.Math;

namespace Express.Scene.Objects.Colliders;
/// <summary>
/// Defines the interface for a halfPlane collider
/// </summary>
public interface IHalfPlaneCollider : ICollider
{
    /// <summary>
    /// The halfPlane representting the collider.
    /// </summary>
    ref HalfPlane HalfPlane { get; }
}
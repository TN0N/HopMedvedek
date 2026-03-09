using Express.Math;

namespace Express.Scene.Objects.Colliders;
/// <summary>
/// An interface representing a convex collider.
/// </summary>
public interface IConvexCollider: ICollider
{
    /// <summary>
    /// The bounds of the convex collider.
    /// </summary>
    ConvexPolygon Bounds { get; set; }
}
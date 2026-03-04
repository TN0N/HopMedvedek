using Express.Math;
using Express.Scene.Objects.Colliders;
using Microsoft.Xna.Framework;

namespace Express.Physics.Collision.AxisAligned;
/// <summary>
/// Determines the collision behaviour between an axis-aligned rectangle collider and a axis-aligned half plane collider.
/// </summary>
public class AARectangleAAHalfPlaneCollision : CollisionAlgorithm<IAARectangleCollider, IAAHalfPlaneCollider>
{
    /// <summary>
    /// Creates a new empty <see cref="AARectangleAAHalfPlaneCollision"/>.
    /// </summary>
    private AARectangleAAHalfPlaneCollision() {}

    /// <summary>
    /// Static instance of <see cref="AARectangleAAHalfPlaneCollision"/>.
    /// </summary>
    protected static AARectangleAAHalfPlaneCollision _instance;
    
    /// <summary>
    /// Creates an instance of <see cref="AARectangleAAHalfPlaneCollision"/>.
    /// </summary>
    /// <returns>The new created instance of <see cref="AARectangleAAHalfPlaneCollision"/>.</returns>
    public static AARectangleAAHalfPlaneCollision Instance()
    {
        if (_instance is null)
            _instance = new AARectangleAAHalfPlaneCollision();

        return _instance;
    }
    /// <summary>
    /// Checks and determines if a collision between an AARectangle collider and AAHalfPlane collider should be resolved.
    /// </summary>
    /// <param name="aaRectangle">The AARectangle collider.</param>
    /// <param name="aaHalfPlane">The AAHalfPlane collider.</param>
    public override void CollisionBetween(IAARectangleCollider aaRectangle, IAAHalfPlaneCollider aaHalfPlane)
    {
        if (DetectCollision(aaRectangle, aaHalfPlane) && ShouldResolveCollision(aaRectangle, aaHalfPlane))
        {
            ResolveCollision(aaRectangle, aaHalfPlane);
            ReportCollision(aaRectangle, aaHalfPlane);
        }
    }
    /// <summary>
    /// Determines if a collision between an AARectangle collider and AAHalfPlane collider has occurred.
    /// </summary>
    /// <param name="aaRectangle">The AARectangle collider.</param>
    /// <param name="aaHalfPlane">The AAHalfPlane collider.</param>
    /// <returns>A <see langword="bool"/> indicating if a collision has happened.</returns>
    protected override bool DetectCollision(IAARectangleCollider aaRectangle, IAAHalfPlaneCollider aaHalfPlane)
    {
        switch (aaHalfPlane.AAHalfPlane.Direction)
        {
            case AxisDirection.PositiveX : return aaRectangle.Position.X - aaRectangle.Width / 2 < aaHalfPlane.AAHalfPlane.Distance;
            case AxisDirection.NegativeX : return aaRectangle.Position.X + aaRectangle.Width / 2 > -aaHalfPlane.AAHalfPlane.Distance;
            case AxisDirection.PositiveY : return aaRectangle.Position.Y - aaRectangle.Height / 2 < aaHalfPlane.AAHalfPlane.Distance;
            case AxisDirection.NegativeY : return aaRectangle.Position.Y + aaRectangle.Height / 2 > -aaHalfPlane.AAHalfPlane.Distance;
        }
        return false;
    }
    /// <summary>
    /// Determines how a collision between an AARectangle collider and AAHalfPlane collider is resolved.
    /// </summary>
    /// <param name="aaRectangle">The AARectangle collider.</param>
    /// <param name="aaHalfPlane">The AAHalfPlane collider.</param>
    protected override void ResolveCollision(IAARectangleCollider aaRectangle, IAAHalfPlaneCollider aaHalfPlane)
    {
        // First we relax the collision, so the two objects don't collide any more.
        Vector2 relaxDistance;
        switch (aaHalfPlane.AAHalfPlane.Direction)
        {
            case AxisDirection.PositiveX : relaxDistance = new Vector2(aaRectangle.Position.X - aaRectangle.Width / 2 - aaHalfPlane.AAHalfPlane.Distance, 0); break;
            case AxisDirection.NegativeX : relaxDistance = new Vector2(aaRectangle.Position.X + aaRectangle.Width / 2 + aaHalfPlane.AAHalfPlane.Distance, 0); break;
            case AxisDirection.PositiveY : relaxDistance = new Vector2(0, aaRectangle.Position.Y - aaRectangle.Height / 2 - aaHalfPlane.AAHalfPlane.Distance); break;
            case AxisDirection.NegativeY : relaxDistance = new Vector2(0, aaRectangle.Position.Y + aaRectangle.Height / 2 + aaHalfPlane.AAHalfPlane.Distance); break;
            default: relaxDistance = Vector2.Zero; break;
        }

        RelaxCollision(aaRectangle, aaHalfPlane, relaxDistance);
        // ENERGY EXCHANGE STEP
        // In a collision, energy is exchanged only along the collision normal.
        // For particles this is simply the line between both centers.
        Vector2 collisionNormal = Vector2.Normalize(relaxDistance);
        ExchangeEnergy(aaRectangle, aaHalfPlane, collisionNormal);
    }
}
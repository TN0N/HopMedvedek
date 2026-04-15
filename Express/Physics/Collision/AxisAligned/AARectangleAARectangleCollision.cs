using Express.Scene.Objects.Colliders;
using Microsoft.Xna.Framework;

namespace Express.Physics.Collision.AxisAligned;
/// <summary>
/// Determines the collision behaviour between two axis-aligned Rectangle colliders.
/// </summary>
public class AARectangleAARectangleCollision : CollisionAlgorithm<IAARectangleCollider, IAARectangleCollider>
{
    /// <summary>
    /// Creates a new empty <see cref="AARectangleAARectangleCollision"/>.
    /// </summary>
    private AARectangleAARectangleCollision() {}
    /// <summary>
    /// A static instance of <see cref="AARectangleAARectangleCollision"/>.
    /// </summary>
    protected static AARectangleAARectangleCollision _instance;
    /// <summary>
    /// Creates and returns a new instance of <see cref="AARectangleAARectangleCollision"/>.
    /// </summary>
    /// <returns>The newly created instance of <see cref="AARectangleAARectangleCollision"/>.</returns>
    public static AARectangleAARectangleCollision Instance()
    {
        if (_instance is null)
            _instance = new AARectangleAARectangleCollision();
        return _instance;
    }
    /// <summary>
    /// Checks and decides if a collision between two AARectangle colliders should be resolved.
    /// </summary>
    /// <param name="aaRectangle1">The first rectangle collider.</param>
    /// <param name="aaRectangle2">The second rectangle collider.</param>
    public override void CollisionBetween(IAARectangleCollider aaRectangle1, IAARectangleCollider aaRectangle2)
    {
        if (DetectCollision(aaRectangle1, aaRectangle2) && ShouldResolveCollision(aaRectangle1, aaRectangle2))
        {
            ResolveCollision(aaRectangle1, aaRectangle2);
            ReportCollision(aaRectangle1, aaRectangle2);
        }
    }
    /// <summary>
    /// Detects if a collision between two AARectangle colliders has occurred.
    /// </summary>
    /// <param name="aaRectangle1">The first rectangle collider.</param>
    /// <param name="aaRectangle2">The second rectangle collider.</param>
    /// <returns>A <see cref="bool"/> indicating if a collision has occurred.</returns>
    protected override bool DetectCollision(IAARectangleCollider aaRectangle1, IAARectangleCollider aaRectangle2)
    {
        float tolerance = 5f;
        float horizontalDistance = System.Math.Abs(aaRectangle1.Position.X - aaRectangle2.Position.X);
        float verticalDistance = System.Math.Abs(aaRectangle1.Position.Y - aaRectangle2.Position.Y);
        return horizontalDistance < aaRectangle1.Width / 2 + aaRectangle2.Width / 2 && verticalDistance < aaRectangle1.Height / 2 + aaRectangle2.Height / 2 + tolerance;
    }
    /// <summary>
    /// Determines how a collision between two AARectangle colliders is resolved.
    /// </summary>
    /// <param name="aaRectangle1">The first rectangle collider.</param>
    /// <param name="aaRectangle2">The second rectangle collider.</param>
    protected override void ResolveCollision(IAARectangleCollider aaRectangle1, IAARectangleCollider aaRectangle2)
    {
        float horizontalDifference = aaRectangle1.Position.X - aaRectangle2.Position.X;
        float horizontalCollidedDistance = System.Math.Abs(horizontalDifference);
        float horizontalMinimumDistance = aaRectangle1.Width / 2 + aaRectangle2.Width / 2;
        float horizontalRelaxDistance = horizontalMinimumDistance - horizontalCollidedDistance;
        float verticalDifference = aaRectangle1.Position.Y - aaRectangle2.Position.Y;
        float verticalCollidedDistance = System.Math.Abs(verticalDifference);
        float verticalMinimumDistance = aaRectangle1.Height / 2 + aaRectangle2.Height / 2;
        float verticalRelaxDistance = verticalMinimumDistance - verticalCollidedDistance;
        Vector2 collisionNormal;
        float relaxDistance;

        if (horizontalRelaxDistance < verticalRelaxDistance)
        {
            relaxDistance = horizontalRelaxDistance;
            collisionNormal = new Vector2(horizontalDifference < 0 ? 1 : -1, 0);
        }
        else
        {
            relaxDistance = verticalRelaxDistance;
            collisionNormal = new Vector2(0, verticalDifference < 0 ? 1 : -1);
        }

        Vector2 relaxDistanceVector = collisionNormal * relaxDistance;
        RelaxCollision(aaRectangle1, aaRectangle2, relaxDistanceVector);
        ExchangeEnergy(aaRectangle1, aaRectangle2, collisionNormal);
    }
}
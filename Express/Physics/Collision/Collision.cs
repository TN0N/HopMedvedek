using Express.Physics.Collision.Arbitrary;
using Express.Physics.Collision.AxisAligned;
using Express.Scene.Objects.Colliders;

namespace Express.Physics.Collision;
/// <summary>
/// Component that checks for a collision between two objects.
/// </summary>
public static class Collision
{
    /// <summary>
    /// Checks for collision between two objects recursively.
    /// </summary>
    /// <param name="item1">The first object.</param>
    /// <param name="item2">The second object.</param>
    public static void CollisionBetween(object item1, object item2)
    {
        CollisionBetween(item1, item2, true);
    }
    /// <summary>
    /// Private method. Checks the type of collider of the items. Then resolves the collision accordingly.
    /// </summary>
    /// <param name="item1">The first object.</param>
    /// <param name="item2">The second object.</param>
    /// <param name="recurse">Defines whether to run recursively.</param>
    private static void CollisionBetween(object item1, object item2, bool recurse)
    {
        // Particle-Particle collision
        if (item1 is IParticleCollider p1 && item2 is IParticleCollider p2)
            ParticleParticleCollision.Instance().CollisionBetween(p1, p2);
        // Particle-AAHalfPlane collision
        else if (item1 is IParticleCollider p && item2 is IAAHalfPlaneCollider hpAA)
            ParticleAAHalfPlaneCollision.Instance().CollisionBetween(p, hpAA);
        // Particle-HalfPlane collision
        else if (item1 is IParticleCollider p3 && item2 is IHalfPlaneCollider hp)
            ParticleHalfPlaneCollision.Instance().CollisionBetween(p3, hp);
        // Particle-AARectangle collision
        else if (item1 is IParticleCollider p4 && item2 is IAARectangleCollider rAA)
            ParticleAARectangleCollision.Instance().CollisionBetween(p4, rAA);
        // Rectangle-AAHalfPlane collision
        else if (item1 is IAARectangleCollider r1 && item2 is IAAHalfPlaneCollider hpAA2)
            AARectangleAAHalfPlaneCollision.Instance().CollisionBetween(r1, hpAA2);
        // AARectangle-AARectangle collision
        else if (item1 is IAARectangleCollider r2 && item2 is IAARectangleCollider r3)
            AARectangleAARectangleCollision.Instance().CollisionBetween(r2, r3);
        // Particle-Convex collision
        else if (item1 is IParticleCollider p5 && item2 is IConvexCollider c)
            ParticleConvexCollision.Instance().CollisionBetween(p5, c);
        // Check swapped
        else if (recurse)
            CollisionBetween(item2, item1, false);
    }
}
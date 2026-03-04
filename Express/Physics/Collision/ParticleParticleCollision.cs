using Express.Scene.Objects.Colliders;
using Microsoft.Xna.Framework;

namespace Express.Physics.Collision;
/// <summary>
/// Defines what happens in a collision between two partical colliders.
/// </summary>
public class ParticleParticleCollision : CollisionAlgorithm<IParticleCollider, IParticleCollider>
{
    /// <summary>
    /// Creates an empty <see cref="ParticleParticleCollision"/>
    /// </summary>
    private ParticleParticleCollision()
    {
    }
    /// <summary>
    /// The instance of the <see cref="ParticleParticleCollision"/>.
    /// </summary>
    private static ParticleParticleCollision _instance;

    /// <summary>
    /// Creates and return a new instance of a <see cref="ParticleParticleCollision"/>.
    /// </summary>
    /// <returns>The instance of the created <see cref="ParticleParticleCollision"/>.</returns>
    public static ParticleParticleCollision Instance()
    {
        if (_instance is null)
            _instance = new ParticleParticleCollision();

        return _instance;
    }
    /// <summary>
    /// Checks for a collision between two particle colliders and then if it thinks the collision should be resolved, it resolves and reports the collision.
    /// </summary>
    /// <param name="particle1"></param>
    /// <param name="particle2"></param>
    public override void CollisionBetween(IParticleCollider particle1, IParticleCollider particle2)
    {
        if (DetectCollision(particle1, particle2) && ShouldResolveCollision(particle1, particle2))
        {
            ResolveCollision(particle1, particle2);
            ReportCollision(particle1, particle2);
        }
    }
    /// <summary>
    /// Detects if a collision between two particles has occurred.
    /// </summary>
    /// <param name="particle1">The first item.</param>
    /// <param name="particle2">The second item.</param>
    /// <returns><see langword="bool"/> that determines if it has been deemed a collision occured.</returns>
    protected override bool DetectCollision(IParticleCollider particle1, IParticleCollider particle2)
    {
        float distanceBetweenParticles = (particle1.Position - particle2.Position).Length();
        return distanceBetweenParticles < particle1.Radius + particle2.Radius;
    }
    /// <summary>
    /// Resolves the collision between two particle colliders.
    /// </summary>
    /// <param name="particle1">The first particle.</param>
    /// <param name="particle2">The second particle.</param>
    protected override void ResolveCollision(IParticleCollider particle1, IParticleCollider particle2)
    {
        // RELAXATION STEP

        // First we relax the collision, so the two objects don't collide any more.
        // We need to calculate by how much to move them apart. We will move them in the shortest direction
        // possible which is simply the difference between both centers.

        Vector2 positionDifference = particle2.Position - particle1.Position;

        float collidedDistance = positionDifference.Length();
        float minimumDistance = particle1.Radius + particle2.Radius;
        float relaxDistance = minimumDistance - collidedDistance;

        Vector2 collisionNormal = collidedDistance != 0f ? Vector2.Normalize(positionDifference) : Vector2.UnitX;
        Vector2 relaxDistanceVector = collisionNormal * relaxDistance;

        RelaxCollision(particle1, particle2, relaxDistanceVector);

        // ENERGY EXCHANGE STEP

        // In a collision, energy is exchanged only along the collision normal.
        // For particles this is simply the line between both centers.
        ExchangeEnergy(particle1, particle2, collisionNormal);
    }
}
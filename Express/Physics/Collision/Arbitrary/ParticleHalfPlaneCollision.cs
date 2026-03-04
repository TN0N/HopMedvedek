using Express.Scene.Objects.Colliders;
using Microsoft.Xna.Framework;

namespace Express.Physics.Collision.Arbitrary;
/// <summary>
/// Determines the collision behaviour between a particleCollider and a HalfPlane collider.
/// </summary>
public class ParticleHalfPlaneCollision : CollisionAlgorithm<IParticleCollider, IHalfPlaneCollider>
{
    /// <summary>
    /// Creates a new empty <see cref="ParticleHalfPlaneCollision"/>.
    /// </summary>
    private ParticleHalfPlaneCollision() {}
    /// <summary>
    /// A static instance of the <see cref="ParticleHalfPlaneCollision"/>
    /// </summary>
    protected static ParticleHalfPlaneCollision _instance;
    /// <summary>
    /// Creates and return an instance of <see cref="ParticleHalfPlaneCollision"/>.
    /// </summary>
    /// <returns>The created instance of <see cref="ParticleHalfPlaneCollision"/>.</returns>
    public static ParticleHalfPlaneCollision Instance()
    {
        if (_instance is null)
        {
            _instance = new ParticleHalfPlaneCollision();
        }
        return _instance;
    }
    /// <summary>
    /// Checks and decides if a collision between a particle collider and half plane collider should be resolved.
    /// </summary>
    /// <param name="particle">The particle collider.</param>
    /// <param name="halfPlane">The half plane collider.</param>
    public override void CollisionBetween(IParticleCollider particle, IHalfPlaneCollider halfPlane)
    {
        if (DetectCollision(particle, halfPlane) && ShouldResolveCollision(particle, halfPlane))
        {
            ResolveCollision(particle, halfPlane);
            ReportCollision(particle, halfPlane);
        }
    }
    /// <summary>
    /// Detects if a collision between a particle collider and half plane collider has happened.
    /// </summary>
    /// <param name="particle">The particle collider.</param>
    /// <param name="halfPlane">The half plane collider.</param>
    /// <returns>A <see langword="bool"/> that indicates if a collision has occurred.</returns>
    protected override bool DetectCollision(IParticleCollider particle, IHalfPlaneCollider halfPlane)
    {
        float nearPoint = Vector2.Dot(particle.Position, halfPlane.HalfPlane.Normal) - particle.Radius;
        return nearPoint < halfPlane.HalfPlane.Distance;
    }
    /// <summary>
    /// Determines has a collision between a particle collider and half plane collider should be resolved.
    /// </summary>
    /// <param name="particle">The particle collider.</param>
    /// <param name="halfPlane">The half plane collider.</param>
    protected override void ResolveCollision(IParticleCollider particle, IHalfPlaneCollider halfPlane)
    {
        float nearPoint = Vector2.Dot(particle.Position, halfPlane.HalfPlane.Normal) - particle.Radius;
        float relaxDistance = nearPoint - halfPlane.HalfPlane.Distance;
        
        Vector2 relaxDistanceVector = halfPlane.HalfPlane.Normal * relaxDistance;
        RelaxCollision(particle, halfPlane, relaxDistanceVector);
        
        Vector2 collisionNormal = Vector2.Normalize(relaxDistanceVector);
        Vector2 pointOfImpact = (particle.Position + (collisionNormal * (relaxDistance + particle.Radius)));
        ExchangeEnergy(particle, halfPlane, collisionNormal, pointOfImpact);
    }

}
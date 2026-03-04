using Express.Math;
using Express.Scene.Objects.Colliders;
using Microsoft.Xna.Framework;

namespace Express.Physics.Collision.AxisAligned;
/// <summary>
/// Determines the collision behaviour between a particle collider and axis-aligned half plane collider.
/// </summary>
public class ParticleAAHalfPlaneCollision : CollisionAlgorithm<IParticleCollider, IAAHalfPlaneCollider>
{
    /// <summary>
    /// Creates a new empty <see cref="ParticleAAHalfPlaneCollision"/>.
    /// </summary>
    private ParticleAAHalfPlaneCollision() {}
    /// <summary>
    /// A static instance of <see cref="ParticleAAHalfPlaneCollision"/>.
    /// </summary>
    protected static ParticleAAHalfPlaneCollision _instance;
    /// <summary>
    /// Creates and return a new instance of <see cref="ParticleAAHalfPlaneCollision"/>.
    /// </summary>
    /// <returns>A newly created instance of <see cref="ParticleAAHalfPlaneCollision"/>.</returns>
    public static ParticleAAHalfPlaneCollision Instance()
    {
        if (_instance is null)
            _instance = new ParticleAAHalfPlaneCollision();

        return _instance;
    }
    /// <summary>
    /// Checks and determines if a collision between a particle and AAHalfPlane collider has occurred.
    /// </summary>
    /// <param name="particle">The particle collider.</param>
    /// <param name="aaHalfPlane">The AAHalfPlane collider.</param>
    public override void CollisionBetween(IParticleCollider particle, IAAHalfPlaneCollider aaHalfPlane)
    {
        if (DetectCollision(particle, aaHalfPlane) && ShouldResolveCollision(particle, aaHalfPlane))
        {
            ResolveCollision(particle, aaHalfPlane);
            ReportCollision(particle, aaHalfPlane);
        }
    }
    /// <summary>
    /// Determines if a collision between a particle collider and AAHalfPlane collider has occurred.
    /// </summary>
    /// <param name="particle">The particle collider.</param>
    /// <param name="aaHalfPlane">The AAHalfPlane collider.</param>
    /// <returns>A <see langword="bool"/> indicating if a collision occurred.</returns>
    protected override bool DetectCollision(IParticleCollider particle, IAAHalfPlaneCollider aaHalfPlane)
    {
        switch (aaHalfPlane.AAHalfPlane.Direction)
        {
            case AxisDirection.PositiveX: return particle.Position.X - particle.Radius < aaHalfPlane.AAHalfPlane.Distance;
            case AxisDirection.NegativeX: return particle.Position.X + particle.Radius > -aaHalfPlane.AAHalfPlane.Distance;
            case AxisDirection.PositiveY: return particle.Position.Y - particle.Radius < aaHalfPlane.AAHalfPlane.Distance;
            case AxisDirection.NegativeY: return particle.Position.Y + particle.Radius > -aaHalfPlane.AAHalfPlane.Distance;
        }
        return false;
    }
    /// <summary>
    /// Determines how a collision between a particle collider and AAHalfPlane collider is resolved.
    /// </summary>
    /// <param name="particle">The particle collider.</param>
    /// <param name="aaHalfPlane">The AAHalfPlane collider.</param>
    protected override void ResolveCollision(IParticleCollider particle, IAAHalfPlaneCollider aaHalfPlane)
    {
        // RELAXATION STEP
        // First we relax the collision, so the two objects don't collide any more.
        Vector2 relaxDistance = Vector2.Zero;
        Vector2 pointOfImpact = Vector2.Zero;
        switch (aaHalfPlane.AAHalfPlane.Direction)
        {
            case AxisDirection.PositiveX: relaxDistance = new Vector2(particle.Position.X - particle.Radius - aaHalfPlane.AAHalfPlane.Distance, 0);
                pointOfImpact = new Vector2(aaHalfPlane.AAHalfPlane.Distance, particle.Position.Y);
                break;
            case AxisDirection.NegativeX: relaxDistance = new Vector2(particle.Position.X + particle.Radius + aaHalfPlane.AAHalfPlane.Distance, 0);
                pointOfImpact = new Vector2(-aaHalfPlane.AAHalfPlane.Distance, particle.Position.Y);
                break;
            case AxisDirection.PositiveY: relaxDistance = new Vector2(0, particle.Position.Y - particle.Radius - aaHalfPlane.AAHalfPlane.Distance);
                pointOfImpact = new Vector2(particle.Position.X, aaHalfPlane.AAHalfPlane.Distance);
                break;
            case AxisDirection.NegativeY: relaxDistance = new Vector2(0, particle.Position.Y + particle.Radius + aaHalfPlane.AAHalfPlane.Distance);
                pointOfImpact = new Vector2(particle.Position.X, -aaHalfPlane.AAHalfPlane.Distance);
                break;
        }

        RelaxCollision(particle, aaHalfPlane, relaxDistance);
        // ENERGY EXCHANGE STEP
        // In a collision, energy is exchanged only along the collision normal.
        // For particles this is simply the line between both centers.
        Vector2 collisionNormal = Vector2.Normalize(relaxDistance);
        ExchangeEnergy(particle, aaHalfPlane, collisionNormal, pointOfImpact);
    }
}
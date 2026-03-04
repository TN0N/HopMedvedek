using Express.Scene.Objects.Colliders;
using Microsoft.Xna.Framework;

namespace Express.Physics.Collision.AxisAligned;
/// <summary>
/// Determines the collision behaviour between a particle collider and an axis-aligned rectangle collider.
/// </summary>
public class ParticleAARectangleCollision : CollisionAlgorithm<IParticleCollider, IAARectangleCollider>
{
    /// <summary>
    /// Creates a new empty <see cref="ParticleAARectangleCollision"/>.
    /// </summary>
    private ParticleAARectangleCollision() {}

    /// <summary>
    /// A static instance of <see cref="ParticleAARectangleCollision"/>.
    /// </summary>
    protected static ParticleAARectangleCollision _instance;

    /// <summary>
    /// Creates and returns a new instance of <see cref="ParticleAARectangleCollision"/>.
    /// </summary>
    /// <returns>A newly created instance of <see cref="ParticleAARectangleCollision"/>.</returns>
    public static ParticleAARectangleCollision Instance()
    {
        if (_instance is null)
            _instance = new ParticleAARectangleCollision();
        return _instance;
    }

    /// <summary>
    /// Checks and determines if a collision between a particle collider and an AARectangle should be resolved.
    /// </summary>
    /// <param name="particle">The particle collider.</param>
    /// <param name="aaRectangle">The AARectangle collider.</param>
    public override void CollisionBetween(IParticleCollider particle, IAARectangleCollider aaRectangle)
    {
        if (DetectCollision(particle, aaRectangle) && ShouldResolveCollision(particle, aaRectangle))
        {
            ResolveCollision(particle, aaRectangle);
            ReportCollision(particle, aaRectangle);
        }
    }

    /// <summary>
    /// Determines if a collision between a particle collider and an AARectangle collider has occurred.
    /// </summary>
    /// <param name="particle">The particle collider.</param>
    /// <param name="aaRectangle">The AARectangle collider.</param>
    /// <returns>A <see langword="bool"/> indicating if a collision has occurred.</returns>
    protected override bool DetectCollision(IParticleCollider particle, IAARectangleCollider aaRectangle)
    {
        Vector2 relaxDistance = CalculateRelaxDistance(particle, aaRectangle);
        return relaxDistance.LengthSquared() > 0;
    }

    /// <summary>
    /// Determines how a collision between a particle collider and an AARectangle collider should be resolved.
    /// </summary>
    /// <param name="particle">The particle collider.</param>
    /// <param name="aaRectangle">The AARectangle collider.</param>
    protected override void ResolveCollision(IParticleCollider particle, IAARectangleCollider aaRectangle)
    {
        Vector2 relaxDistance = CalculateRelaxDistance(particle, aaRectangle);
        RelaxCollision(particle, aaRectangle, relaxDistance);

        Vector2 collisionNormal = Vector2.Normalize(relaxDistance);
        ExchangeEnergy(particle, aaRectangle, collisionNormal);
    }

    /// <summary>
    /// Calculates the relaxed distance between a particle collider and an AARectanlge collider after a collision has occurred.
    /// </summary>
    /// <param name="particle">The particle collider.</param>
    /// <param name="aaRectangle">The AARectangle collider.</param>
    /// <returns>A <see cref="Vector2"/> representing the relaxation distance.</returns>
    private Vector2 CalculateRelaxDistance(IParticleCollider particle, IAARectangleCollider aaRectangle)
    {
        Vector2 relaxDistance = Vector2.Zero;
        Vector2 nearestVertex = aaRectangle.Position;
        float halfWidth = aaRectangle.Width / 2;
        float halfHeight = aaRectangle.Height / 2;
        float leftDifference = (aaRectangle.Position.X - halfWidth) - (particle.Position.X + particle.Radius);

        if (leftDifference > 0) 
            return relaxDistance;

        float rightDifference = (particle.Position.X - particle.Radius) - (aaRectangle.Position.X + halfWidth);
        if (rightDifference > 0) 
            return relaxDistance;

        float topDifference = (aaRectangle.Position.Y - halfHeight) - (particle.Position.Y + particle.Radius);
        if (topDifference > 0) 
            return relaxDistance;

        float bottomDifference = (particle.Position.Y - particle.Radius) - (aaRectangle.Position.Y + halfHeight);
        if (bottomDifference > 0) 
            return relaxDistance;

        bool horizontallyInside = false;
        bool verticallyInside = false;

        if (particle.Position.X < aaRectangle.Position.X - halfWidth)
            nearestVertex.X -= halfWidth;
        else if (particle.Position.X > aaRectangle.Position.X + halfWidth)
            nearestVertex.X += halfWidth;
        else
            horizontallyInside = true;

        if (particle.Position.Y < aaRectangle.Position.Y - halfHeight)
            nearestVertex.Y -= halfHeight;
        else if (particle.Position.Y > aaRectangle.Position.Y + halfHeight)
            nearestVertex.Y += halfHeight;
        else
            verticallyInside = true;

        if (!horizontallyInside && !verticallyInside)
        {
            Vector2 particleVertex = nearestVertex - particle.Position;
            float vertexDistance = particleVertex.Length();
            if (vertexDistance > particle.Radius)
                return relaxDistance;
            else
                return Vector2.Normalize( particleVertex ) * (particle.Radius - vertexDistance);

        }

        if (leftDifference > rightDifference)
            relaxDistance.X = -leftDifference;
        else
            relaxDistance.X = rightDifference;

        if (topDifference > bottomDifference)
            relaxDistance.Y = -topDifference;
        else
            relaxDistance.Y = bottomDifference;
        
        if (System.Math.Abs(relaxDistance.X) < System.Math.Abs(relaxDistance.Y))
            relaxDistance.Y = 0;
        else
            relaxDistance.X = 0;

        return relaxDistance;
    }
}
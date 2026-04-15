using System.Collections.Generic;
using Express.Math;
using Express.Scene.Objects.Colliders;
using Express.Scene.Objects.Movement;
using Express.Scene.Objects.Rotation;
using Microsoft.Xna.Framework;

namespace Express.Physics.Collision.Arbitrary;
/// <summary>
/// Defines the collision behvaiour between a Particle collider and Convex collider.
/// </summary>
public class ParticleConvexCollision : CollisionAlgorithm<IParticleCollider, IConvexCollider>
{
    /// <summary>
    /// Creates a new <see cref="ParticleConvexCollision"/>.
    /// </summary>
    private ParticleConvexCollision()
    {
    }
    /// <summary>
    /// The instance of the collision.
    /// </summary>
    protected static ParticleConvexCollision _instance;
    /// <summary>
    /// Creates an instance of a <see cref="ParticleConvexCollision"/>.
    /// </summary>
    /// <returns>The created instance of <see cref="ParticleConvexCollision"/>.</returns>
    public static ParticleConvexCollision Instance()
    {
        if (_instance is null)
        {
            _instance = new ParticleConvexCollision();
        }

        return _instance;
    }
    /// <summary>
    /// Detects and determines if a collision should be resolved.
    /// </summary>
    /// <param name="particle">The particle collider.</param>
    /// <param name="convex">The convex collider.</param>
    public override void CollisionBetween(IParticleCollider particle, IConvexCollider convex)
    {
        if (DetectCollision(particle, convex) && ShouldResolveCollision(particle, convex))
        {
            ResolveCollision(particle, convex);
            ReportCollision(particle, convex);
        }
    }
    /// <summary>
    /// Determines if a collision has occured.
    /// </summary>
    /// <param name="particle">The particle collider.</param>
    /// <param name="convex">The convex collider.</param>
    /// <returns>A <see langword="bool"/> that determines if a collision has taken place.</returns>
    protected override bool DetectCollision(IParticleCollider particle, IConvexCollider convex)
    {
        Vector2 pointOfImpact = new(); // Create new empty point of impact
        Vector2 relaxDistance = CalculateRelaxDistance(particle, convex, ref pointOfImpact); // Calculate the relax distance
        return relaxDistance.LengthSquared() > 0; // Return true if the relax distance is greater than 0. 
    }
    /// <summary>
    /// Determines how a collision between a particle collider and convex colliders is resolved.
    /// </summary>
    /// <param name="particle">The particle collider.</param>
    /// <param name="convex">The convex collider.</param>
    protected override void ResolveCollision(IParticleCollider particle, IConvexCollider convex)
    {
        Vector2 pointOfImpact = new(); // Create ne empty point of impact
        Vector2 relaxDistance = CalculateRelaxDistance(particle, convex, ref pointOfImpact); // Calculate the relax distance
        RelaxCollision(particle, convex, relaxDistance); // Relax the collsion.
        Vector2 collisionNormal = Vector2.Normalize(relaxDistance); // Normalize the collision normal
        ExchangeEnergy(particle, convex, collisionNormal, pointOfImpact); // Exchange energy between the two objects.
    }
    /// <summary>
    /// Determines how to calculate the relax distance.
    /// </summary>
    /// <param name="particle">The particle collider.</param>
    /// <param name="convex">The convex collider.</param>
    /// <param name="pointOfImpact">The point of impact.</param>
    /// <returns>A <see cref="Vector2"/> representing the point of impact.</returns>
    private Vector2 CalculateRelaxDistance(IParticleCollider particle, IConvexCollider convex,
        ref Vector2 pointOfImpact)
    {
        //System.Diagnostics.Debug.WriteLine("poi: " + pointOfImpact);
        // First move particle in coordinate space of the convex collider.
        Vector2 offset = convex is IPosition ? ((IPosition)convex).Position : Vector2.Zero;
        float angle = convex is IRotation ? ((IRotation)convex).RotationAngle : 0;
        Matrix transform = Matrix.CreateRotationZ(angle) * (Matrix.CreateTranslation(offset.X, offset.Y, 0));
        Vector2 relativeParticlePosition = Vector2.Transform(particle.Position, Matrix.Invert(transform));

        List<Vector2> vertices = convex.Bounds.Vertices;
        List<HalfPlane> halfPlanes = convex.Bounds.HalfPlanes;
        bool voronoiNearEdge = false;
        float smallestDifference = 0;
        int smallestDifferenceIndex = 0;
        float smallestDistance = 0;
        int smallestDistanceIndex = 0;
        // Calculate overlap with all sides.
        int timesCenterUnderEdge = 0;
        for (int i = 0; i < vertices.Count; i++)
        {
            // Relax distance from the plane
            HalfPlane halfPlane = halfPlanes[i];
            float nearPoint = Vector2.Dot(relativeParticlePosition, halfPlane.Normal) - particle.Radius;
            float relaxDifference = nearPoint - halfPlane.Distance;
            if (relaxDifference > 0) return Vector2.Zero;

            if (i == 0 || relaxDifference > smallestDifference)
            {
                smallestDifference = relaxDifference;
                smallestDifferenceIndex = i;
            }

            // Distance to vertex
            float distance = (vertices[i] - relativeParticlePosition).Length();
            if (i == 0 || distance < smallestDistance)
            {
                smallestDistance = distance;
                smallestDistanceIndex = i;
            }

            // Are we in the voronoi region of this edge?
            float centerDifference = Vector2.Dot(relativeParticlePosition, halfPlane.Normal) - halfPlane.Distance;
            if (centerDifference > 0)
            {
                // Center is above edge so see if we're between start and end.
                Vector2 edge = convex.Bounds.Edges[i];
                Vector2 edgeNormal = Vector2.Normalize(edge);
                float start = Vector2.Dot(vertices[i], edgeNormal);
                float end = Vector2.Dot(edge + vertices[i], edgeNormal);
                float center = Vector2.Dot(relativeParticlePosition, edgeNormal);
                if (start < center && center < end)
                {
                    voronoiNearEdge = true;
                    if (smallestDifferenceIndex == i)
                        pointOfImpact = vertices[i] + (edge * ((center - start) / (end - start)));
                }
            }
            else
            {
                timesCenterUnderEdge++;
            }
        }

        Vector2 relaxDistance;
        // Particle is under all sides.	
        if (voronoiNearEdge || timesCenterUnderEdge == vertices.Count)
        {
            // The edge is closer than the nearest vertex, so just relax in the direction of edge normal
            HalfPlane nearestPlane = halfPlanes[smallestDifferenceIndex];
            relaxDistance = nearestPlane.Normal * smallestDifference;
        }
        else
        {
            // We are in the voronoi region next to nearest vertex.
            Vector2 voronoiVertex = vertices[smallestDistanceIndex];
            Vector2 voronoiNormal = Vector2.Normalize(relativeParticlePosition - voronoiVertex);
            float nearPoint = Vector2.Dot(relativeParticlePosition, voronoiNormal) - particle.Radius;
            float distance = Vector2.Dot(voronoiVertex, voronoiNormal);
            float relaxDifference = nearPoint - distance;
            if (relaxDifference > 0) return Vector2.Zero;

            // Relax in the direction of voronoi vertex
            relaxDistance = voronoiNormal * relaxDifference;
            pointOfImpact = voronoiVertex;
        }

        // Transform result vector back into absolute space.
        pointOfImpact = Vector2.Transform(pointOfImpact, transform);
        return Vector2.TransformNormal(relaxDistance, transform);
    }
}
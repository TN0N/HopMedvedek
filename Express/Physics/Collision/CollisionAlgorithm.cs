using System;
using Express.Scene.Objects.Colliders;
using Express.Scene.Objects.Movement;
using Express.Scene.Objects.Physical_Properties;
using Express.Scene.Objects.Rotation;
using Microsoft.Xna.Framework;

namespace Express.Physics.Collision;
/// <summary>
/// Defines the collision algorithm used for detecting and resolving collisions.
/// </summary>
/// <typeparam name="T1">The first collider.</typeparam>
/// <typeparam name="T2">The second collider.</typeparam>
public class CollisionAlgorithm<T1,T2>
{
    /// <summary>
    /// Created a new empty collision Algorithm
    /// </summary>
    protected CollisionAlgorithm()
    {
    }
    /// <summary>
    /// <see langword="virtual"/> method to be overriden. Checks for collision between two colliders.
    /// </summary>
    /// <param name="item1">The first collider.</param>
    /// <param name="item2">The second collider.</param>
    public virtual void CollisionBetween(T1 item1, T2 item2)
    {
    }
    /// <summary>
    /// <see langword="virtual"/> method to be overriden. Detects collision between two colliders.
    /// </summary>
    /// <param name="item1">The first collider.</param>
    /// <param name="item2">The second collider.</param>
    /// <returns><see langword="false"/></returns>
    protected virtual bool DetectCollision(T1 item1, T2 item2)
    {
        return false;
    }
    /// <summary>
    /// <see langword = "virtual" /> method to be overriden. Defines how a collision should be resolved.
    /// </summary>
    /// <param name="item1">The first collider.</param>
    /// <param name="item2">The second collider.</param>
    protected virtual void ResolveCollision(T1 item1, T2 item2)
    {
    }
    /// <summary>
    /// Defines whether a collision should be resolved.
    /// </summary>
    /// <param name="item1">The first collider.</param>
    /// <param name="item2">The second collider.</param>
    /// <returns><see langword="bool"/> that determines whether the collision should be resolved or not.</returns>
    protected bool ShouldResolveCollision(object item1, object item2)
    {
        ICustomCollider customCollider1 = item1 as ICustomCollider;
        ICustomCollider customCollider2 = item2 as ICustomCollider;
        bool result = true;

        // If both colliders are customColliders then result is set to the customColliders.CollidingWith output.
        if (customCollider1 is not null)
            result &= customCollider1.CollidingWith(item2, true);

        if (customCollider2 is not null)
            result &= customCollider2.CollidingWith(item1, result);

        return result;
    }
    /// <summary>
    /// Calculates the relaxation that happens after two items with mass collide.
    /// </summary>
    /// <param name="item1">The first collider.</param>
    /// <param name="item2">The second collider.</param>
    /// <param name="relaxDistance">The relax distance.</param>
    protected void RelaxCollision(object item1, object item2, Vector2 relaxDistance)
    {
        float relaxPercentage1 = 0.5f; // The default relax percentage
        float relaxPercentage2 = 0.5f; // The defualt relax percentage
        IMass itemWithMass1 = item1 as IMass;
        IMass itemWithMass2 = item2 as IMass;
        IPosition itemWithPosition1 = item1 as IPosition;
        IPosition itemWithPosition2 = item2 as IPosition;

        // Check if both items have mass
        if (itemWithMass1 is not null && itemWithMass2 is not null)
        {
            float mass1 = itemWithMass1.Mass;
            float mass2 = itemWithMass2.Mass;
            // Object with greater mass relaxes less.
            relaxPercentage1 = mass2 / (mass1 + mass2);
            relaxPercentage2 = mass1 / (mass1 + mass2);
        }
        // Only object 1 has mass
        else if (itemWithMass1 is not null)
        {
            relaxPercentage1 = 1;
            relaxPercentage2 = 0;
        }
        // Only object 2 has mass
        else if (itemWithMass2 is not null)
        {
            relaxPercentage1 = 0;
            relaxPercentage2 = 1;
        }
        // Neither has mass

        else
        {
            // only item 1 has position
            if (itemWithPosition1 is not null && itemWithPosition2 is null)
            {
                relaxPercentage1 = 1;
                relaxPercentage2 = 0;
            }
            // only item 2 has position
            else if (itemWithPosition1 is null && itemWithPosition2 is not null)
            {
                relaxPercentage1 = 0;
                relaxPercentage2 = 1;
            }
        }
        
        // item 1 relaxes
        if (itemWithPosition1 is not null)
            itemWithPosition1.Position -= relaxDistance * relaxPercentage1;
        // item 2 relaxes
        if (itemWithPosition2 is not null)
            itemWithPosition2.Position += relaxDistance * relaxPercentage2;
    }
    /// <summary>
    /// Reports a collision to both colliders involved.
    /// </summary>
    /// <param name="item1">The first object in the collision.</param>
    /// <param name="item2">The second object in the collision.</param>
    protected void ReportCollision(object item1, object item2)
    {
        ICustomCollider customCollider1 = item1 as ICustomCollider;
        ICustomCollider customCollider2 = item2 as ICustomCollider;
        
        customCollider1?.CollidedWith(item2);
        customCollider2?.CollidedWith(item1);
    }
    /// <summary>
    /// Calculates the exchange of energy that happens in a collision.
    /// </summary>
    /// <param name="item1">The first item in the collision.</param>
    /// <param name="item2">The second item in the collision.</param>
    /// <param name="collisionNormal">The collision normal.</param>
    protected void ExchangeEnergy(object item1, object item2, Vector2 collisionNormal)
    {
        
        IVelocity itemWithVelocity1 = item1 as IVelocity;
        IVelocity itemWithVelocity2 = item2 as IVelocity;
        
        // Get the speed of both objects.
        float speed1 = itemWithVelocity1 is not null ? Vector2.Dot(itemWithVelocity1.Velocity, collisionNormal) : 0;
        float speed2 = itemWithVelocity2 is not null ? Vector2.Dot(itemWithVelocity2.Velocity, collisionNormal) : 0;

        float speedDifference = speed1 - speed2;
        if (speedDifference < 0)
            return;

        // Calculate the Coefficient Of Resolution for each object if it has it.
        float cor1 = item1 is ICoefficientOfRestitution restitution1 ? restitution1.CoefficientOfRestitution : 1;
        float cor2 = item2 is ICoefficientOfRestitution restitution2 ? restitution2.CoefficientOfRestitution : 1;
        float cor = cor1 * cor2;
        float mass1Inverse = item1 is IMass ? 1.0f / ((IMass)item1).Mass : 0;
        float mass2Inverse = item2 is IMass ? 1.0f / ((IMass)item2).Mass : 0;

        float impact = -(cor+1) * speedDifference / (mass1Inverse + mass2Inverse);

        // Apply changes to the objects velocity.
        if (mass1Inverse > 0 && itemWithVelocity1 is not null)
            itemWithVelocity1.Velocity += collisionNormal * (impact * mass1Inverse);
        
        if (mass2Inverse > 0 && itemWithVelocity2 is not null)
            itemWithVelocity2.Velocity -= collisionNormal * (impact * mass2Inverse);
    }
    /// <summary>
    /// Calculates the exchange of energy that happens in a collision. Takes rotation into consideration.
    /// </summary>
    /// <param name="item1">The first item in the collision.</param>
    /// <param name="item2">The second item in the collision.</param>
    /// <param name="collisionNormal">The collision normal.</param>
    /// <param name="pointOfImpact">The point of impact</param>
    protected void ExchangeEnergy(object item1, object item2, Vector2 collisionNormal, Vector2 pointOfImpact)
    {
        /*
        System.Diagnostics.Debug.WriteLine(item1);
        System.Diagnostics.Debug.WriteLine(item2);
        System.Diagnostics.Debug.WriteLine(collisionNormal);
        System.Diagnostics.Debug.WriteLine(pointOfImpact);*/


        IPosition item1WithPosition = item1 as IPosition;
        IMovable movableItem1 = item1 as IMovable;
        IRotatable rotatableItem1 = item1 as IRotatable;
        IPosition item2WithPosition = item2 as IPosition;
        IMovable movableItem2 = item2 as IMovable;
        IRotatable rotatableItem2 = item2 as IRotatable;
        Vector2 velocity1 = movableItem1?.Velocity ?? Vector2.Zero;
        Vector2 velocity2 = movableItem2?.Velocity ?? Vector2.Zero;
        Vector2 lever1 = new();
        Vector2 lever2 = new();
        Vector2 tangentialDirection1 = new();
        Vector2 tangentialDirection2 = new();
        
        // Check if items have position and are rotatable.
        if (item1WithPosition is not null && rotatableItem1 is not null)
        {
            lever1 = pointOfImpact - item1WithPosition.Position;
            tangentialDirection1 = Vector2.Normalize(new Vector2(-lever1.Y, lever1.X));
            
            Vector2 rotationalVelocity = tangentialDirection1 * (lever1.Length() * rotatableItem1.AngularVelocity);
            
            velocity1 += rotationalVelocity;
        }
        if (item2WithPosition is not null && rotatableItem2 is not null)
        {
            lever2 = pointOfImpact - item2WithPosition.Position;
            tangentialDirection2 = Vector2.Normalize(new Vector2(-lever2.Y, lever2.X));
            Vector2 rotationalVelocity = tangentialDirection2 * (lever2.Length() * rotatableItem2.AngularVelocity);
            
            velocity2 += rotationalVelocity;
        }

        // Get the speed difference between the objects.
        float speed1 = Vector2.Dot(velocity1, collisionNormal);
        float speed2 = Vector2.Dot(velocity2, collisionNormal);
        float speedDifference = speed1 - speed2;
        //System.Diagnostics.Debug.WriteLine(collisionNormal);
        if (speedDifference < 0)
            return;

        // Calculate the Coefficient of resolution.
        float cor1 = item1 is ICoefficientOfRestitution? ((ICoefficientOfRestitution)item1).CoefficientOfRestitution : 1;
        float cor2 = item2 is ICoefficientOfRestitution? ((ICoefficientOfRestitution)item2).CoefficientOfRestitution : 1;
        float cor = cor1 * cor2;
        float mass1Inverse = item1 is IMass ? 1.0f / ((IMass)item1).Mass : 0;
        float mass2Inverse = item2 is IMass ? 1.0f / ((IMass)item2).Mass : 0;
        IAngularMass item1WithAngularMass = item1 as IAngularMass;
        IAngularMass item2WithAngularMass = item2 as IAngularMass;
        
        // Calculate the inverse angular mass for each object.
        float angularMass1Inverse = item1WithAngularMass is not null?
            MathF.Pow(Vector2.Dot(tangentialDirection1, collisionNormal) * lever1.Length(), 2) / item1WithAngularMass.AngularMass : 0;
        float angularMass2Inverse = item2WithAngularMass is not null? 
            MathF.Pow(Vector2.Dot(tangentialDirection2, collisionNormal) * lever2.Length(), 2) / item2WithAngularMass.AngularMass : 0;

        // Calculate the impact of each object.
        float impact = -(cor + 1) * speedDifference / (mass1Inverse + mass2Inverse + angularMass1Inverse + angularMass2Inverse);
        //System.Diagnostics.Debug.WriteLine(impact);
        // Apply changes to velocity and rotation.
        
        if (mass1Inverse > 0 && movableItem1 is not null)
            movableItem1.Velocity += (collisionNormal * (impact * mass1Inverse));

        if (mass2Inverse > 0 && movableItem2 is not null)
            movableItem2.Velocity -= (collisionNormal * (impact * mass2Inverse));

        if (item1WithAngularMass is not null)
        {
            float tangentialForce = Vector2.Dot(tangentialDirection1, collisionNormal) * impact;

            //System.Diagnostics.Debug.WriteLine(tangentialForce);
            float change = tangentialForce * lever1.Length() / item1WithAngularMass.AngularMass;
            //System.Diagnostics.Debug.WriteLine(item1);
            rotatableItem1.AngularVelocity += change;
        }

        if (item2WithAngularMass is not null)
        {
            //System.Diagnostics.Debug.WriteLine("aaaa");
            float tangentialForce = Vector2.Dot(tangentialDirection2, collisionNormal) * -impact;

            float change = tangentialForce * lever2.Length() / item2WithAngularMass.AngularMass;
            rotatableItem2.AngularVelocity += change;
        }
    }

}
using Express.Scene.Objects.Movement;
using Express.Scene.Objects.Physical_Properties;
using Express.Scene.Objects.Rotation;
using Microsoft.Xna.Framework;
using System;

namespace Express.Physics;
/// <summary>
/// Component that checks objects for acceleraion, velocity or rotation and then applies movement.
/// </summary>
public static class MovementPhysics
{
    /// <summary>
    /// Checks the given <paramref name="item"/> <see langword="object"/> for acceleraion and velocity and then applies movement.
    /// </summary>
    /// <param name="item">The <see langword="object"/> being checked.</param>
    /// <param name="elapsed">The elapsed time.</param>
    public static void SimulateMovement(object item, TimeSpan elapsed)
    {

        float scaledDt = (float)elapsed.TotalSeconds * (MathF.Sqrt((float)Scores.Scores.score) / 1000 + 1);
        //System.Diagnostics.Debug.WriteLine(speedMult);
        if (item is IMovable movable)
        {
            
            movable.Velocity += movable.Acceleration * scaledDt;
            movable.Position += movable.Velocity * scaledDt;
            movable.Velocity *= movable.Decay;
        }

        if (item is IRotatable rotatable && item is IPosition position)
        {
            //System.Diagnostics.Debug.WriteLine("rotating");


            // Direction from pivot to object
            Vector2 dir = position.Position - rotatable.PivotPoint;

            // Rotate that direction
            float angle = rotatable.AngularVelocity * (float)elapsed.TotalSeconds;

            float cos = (float)MathF.Cos(angle);
            float sin = (float)MathF.Sin(angle);

            Vector2 rotatedDir = new Vector2(
                dir.X * cos - dir.Y * sin,
                dir.X * sin + dir.Y * cos
            );

            // New position
            position.Position = rotatable.PivotPoint + rotatedDir;

            // Still update rotation angle if needed
            rotatable.RotationAngle += angle;


            //rotatable.RotationAngle += rotatable.AngularVelocity * (float)elapsed.TotalSeconds;
        }
        if (item is IGravity gravityItem && item is IVelocity velocityItem)
        {
            float gravity = gravityItem.GravitationalAcceleration * scaledDt;
            velocityItem.Velocity.Y += gravity;
        }
    }
    /*
    public static void SimulateMovement(IMovable item, TimeSpan elapsed)
    {
        
        item.Velocity += item.Acceleration * (float)elapsed.TotalSeconds;
        
        item.Position += item.Velocity * (float)elapsed.TotalSeconds;
        
        item.Velocity.X *= item.Decay;
    }*/
}
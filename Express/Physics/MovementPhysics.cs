using System;
using Express.Scene.Objects.Movement;
using Express.Scene.Objects.Rotation;

namespace Express.Physics;

public static class MovementPhysics
{
    public static void SimulateMovement(object item, TimeSpan elapsed)
    {
        if (item is IMovable movable)
        {
            
            movable.Velocity += movable.Acceleration * (float)elapsed.TotalSeconds;
            movable.Position += movable.Velocity * (float)elapsed.TotalSeconds;
            movable.Velocity.X *= movable.Decay;
        }

        if (item is IRotatable rotatable)
        {
            rotatable.RotationAngle += rotatable.AngularVelocity * (float)elapsed.TotalSeconds;
        }
    }
    
    public static void SimulateMovement(IMovable item, TimeSpan elapsed)
    {
        
        item.Velocity += item.Acceleration * (float)elapsed.TotalSeconds;
        
        item.Position += item.Velocity * (float)elapsed.TotalSeconds;
        
        item.Velocity.X *= item.Decay;
    }
}
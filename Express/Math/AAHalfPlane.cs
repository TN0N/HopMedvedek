using System;
using Microsoft.Xna.Framework;

namespace Express.Math;
/// <summary>
/// A axis-alinged region defined by direction and distance.
/// </summary>
public class AAHalfPlane : HalfPlane
{
    protected AxisDirection _direction; // The direction of the HalfPlane

    /// <summary>
    /// Creates a new <see cref="AAHalfPlane"/>.
    /// </summary>
    /// <param name="theDirection">The direction of the <see cref="AAHalfPlane"/>.</param>
    /// <param name="theDistance">The distance of the <see cref="AAHalfPlane"/>.</param>
    public AAHalfPlane(AxisDirection theDirection, float theDistance)
    {
        _distance = theDistance;
        _direction = theDirection;
        
        switch (theDirection)
        {
            case AxisDirection.PositiveX : _normal = Vector2.UnitX; break;
            case AxisDirection.NegativeX : _normal = -Vector2.UnitX; break;
            case AxisDirection.PositiveY : _normal = Vector2.UnitY; break;
            case AxisDirection.NegativeY : _normal = -Vector2.UnitY; break;
        }
    }
    /// <summary>
    /// Gets or sets the direction of the <see cref="AAHalfPlane"/>.
    /// </summary>
    public AxisDirection Direction
    {
        get => _direction;
        set
        {
            switch (value)
            { 
                case AxisDirection.PositiveX : _normal = Vector2.UnitX; break;
                case AxisDirection.NegativeX : _normal = -Vector2.UnitX; break;
                case AxisDirection.PositiveY : _normal = Vector2.UnitY; break;
                case AxisDirection.NegativeY : _normal = -Vector2.UnitY; break;
            }
        }
    }
    /// <summary>
    /// Sets the normal value for the <see cref="AAHalfPlane"/>.
    /// </summary>
    /// <param name="value">The value of the normal.</param>
    /// <exception cref="Exception">Unaligned half plane and normal.</exception>
    void SetNormal(Vector2 value)
    {
        if ((value.X == 0 && value.Y == 0) || (value.X != 0 && value.Y != 0))
        {
            throw new Exception("Axis aligned half plane requires an axis aligned normal");
        }

        Normal = value;
        if (value.X > 0)
            _direction = AxisDirection.PositiveX;
        else if (value.X < 0)
            _direction = AxisDirection.NegativeX;
        else if (value.Y > 0)
            _direction = AxisDirection.PositiveY;
        else if (value.Y < 0)
            _direction = AxisDirection.NegativeY;

    }    
}
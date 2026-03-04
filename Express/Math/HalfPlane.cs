using Microsoft.Xna.Framework;

namespace Express.Math;
/// <summary>
/// A region defined by a normal and distance.
/// </summary>
public class HalfPlane
{
    protected float _distance;
    protected Vector2 _normal;

    /// <summary>
    /// Creates a blank <see cref="HalfPlane"/>.
    /// </summary>
    protected HalfPlane()
    {
    }
    /// <summary>
    /// Creates a new <see cref="HalfPlane"/>.
    /// </summary>
    /// <param name="theNormal">The normal of the <see cref="HalfPlane"/>.</param>
    /// <param name="theDistance">The distance of the <see cref="HalfPlane"/>.</param>
    public HalfPlane(Vector2 theNormal, float theDistance)
    {
        Normal = theNormal;
        Distance = theDistance;
    }
    /// <summary>
    /// The distance that defines the <see cref="HalfPlane"/>.
    /// </summary>
    public float Distance
    {
        get => _distance;
        set => _distance = value;
    }
    /// <summary>
    /// The normal that defines the <see cref="HalfPlane"/>.
    /// </summary>
    public Vector2 Normal
    {
        get => _normal;
        set
        {
            _normal = value;
            // Normal mus be normalized
            if (_normal.LengthSquared() != 1.0f)
            {
                _normal.Normalize();
            }

        }
    }
}
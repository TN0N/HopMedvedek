using System;
using Microsoft.Xna.Framework;

namespace Artificial.Artificial.Utils;
/// <summary>
/// Defines a helper <see langword="class"/> for generating random numbers.
/// </summary>
public class SRandom
{
    public static readonly Random Random = new Random(DateTime.Now.Millisecond); // Creates a new Random object with the current time as the seed

    /// <summary>
    /// Generates a random <see langword="float"/> between <paramref name="min"/> and <paramref name="max"/>.
    /// </summary>
    /// <param name="min">The minimum value for the random number.</param>
    /// <param name="max">The maximum value for the random number.</param>
    /// <returns>A random <see langword="float"/> between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static float Float(float min, float max)
    {
        return (float)(Random.NextDouble() * (max - min) + min);
    }
    /// <summary>
    /// Generates a random <see langword="float"/> between <see langword="0"/> and <paramref name="max"/>.
    /// </summary>
    /// <param name="max">The maximum value for the random number.</param>
    /// <returns>A random <see langword="float"/> between <see langword="0"/> and <paramref name="max"/>.</returns>
    public static float Float(float max)
    {
        return (float)(Random.NextDouble() * max);
    }
    /// <summary>
    /// Generates a random <see langword="float"/> between <see langword="0"/> and <see langword="1"/>.
    /// </summary>
    /// <returns>A random <see langword="float"/> between <see langword="0"/> and <see langword="1"/>.</returns>
    public static float Float()
    {
        return (float)(Random.NextDouble());
    }
    /// <summary>
    /// Generates a <see cref="Microsoft.Xna.Framework.Vector2"/> with randomized X and Y.
    /// </summary>
    /// <param name="minX">The minimum value for X.</param>
    /// <param name="maxX">The maximum value for X.</param>
    /// <param name="minY">The minimum value for Y.</param>
    /// <param name="maxY">The maximum value for Y.</param>
    /// <returns><see cref="Microsoft.Xna.Framework.Vector2"/> with randomized X and Y.</returns>
    public static Vector2 Vector2(float minX, float maxX, float minY, float maxY)
    {
        return new Vector2(Float(minX, maxX), Float(minY, maxY));
    }
    /// <summary>
    /// Generates a <see cref="Microsoft.Xna.Framework.Vector2"/> with randomized X and Y.
    /// </summary>
    /// <param name="maxX">The maximum value for X.</param>
    /// <param name="maxY">The maximum value for Y.</param>
    /// <returns><see cref="Microsoft.Xna.Framework.Vector2"/> with randomized X and Y.</returns>
    public static Vector2 Vector2(float maxX, float maxY)
    {
        return new Vector2(Float(maxX), Float(maxY));
    }
    /// <summary>
    /// Generates a random <see langword="int"/> between <see langword="0"/> and <paramref name="max"/>.
    /// </summary>
    /// <param name="max">The maximum value allowed.</param>
    /// <returns>Random <see langword="int"/> between <see langword="0"/> and <paramref name="max"/>.</returns>
    public static int Int(int max)
    { 
        return Random.Next(max);
    }
    /// <summary>
    /// Generates a random <see langword="int"/> between <see langword="0"/> and <see langword="1"/>.
    /// </summary>
    /// <param name="max">The maximum value allowed.</param>
    /// <returns>Random <see langword="int"/> between <see langword="0"/> and <see langword="1"/>.</returns>
    public static int Int()
    {
        return Random.Next();
    }
}

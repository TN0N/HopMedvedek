using Microsoft.Xna.Framework;

namespace Express.Scene.Objects;
/// <summary>
/// Defines a class that represents the lifetime of an object. 
/// </summary>
public class Lifetime
{
    private double _start;
    private double _duration;
    private double _progress;

    /// <summary>
    /// The lifetimes progress
    /// </summary>
    public double Progress => _progress;

    /// <summary>
    /// Creates a new <see cref="Lifetime"/>.
    /// </summary>
    /// <param name="start">The start of the lifetime.</param>
    /// <param name="duration">The duration of the lifetime.</param>
    public Lifetime(double start, double duration)
    {
        _start = start;
        _duration = duration;
    }

    /// <summary>
    /// Adds progress to the lifetime.
    /// </summary>
    /// <param name="gameTime">The current gametime.</param>
    public void Update(GameTime gameTime)
    {
        if (IsAlive)
        {
            _progress += gameTime.ElapsedGameTime.TotalSeconds;
            if (!IsAlive)
            {
                _progress = _duration;
            }
        }
    }
    /// <summary>
    /// Checks if lifetime is in progress.
    /// </summary>
    public bool IsAlive => _progress < _duration;
    /// <summary>
    /// Checks the lifetimes percentage progress.
    /// </summary>
    public float Percentage => (float) (_progress / _duration);
}
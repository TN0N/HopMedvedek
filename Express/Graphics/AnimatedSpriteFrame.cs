namespace Express.Graphics;
/// <summary>
/// Defines the individual frame of an animation sprite.
/// </summary>
public class AnimatedSpriteFrame
{
    protected Sprite _sprite;
    protected double _start;

    /// <summary>
    /// Creates a new <see cref="AnimatedSpriteFrame"/> for the given <paramref name="sprite"/>.
    /// </summary>
    /// <param name="sprite">The animation sprite the animation frame belongs to.</param>
    /// <param name="start">The time at which the frame is to be displayed.</param>
    public AnimatedSpriteFrame(Sprite sprite, double start)
    {
        _sprite = sprite;
        _start = start;
    }
    /// <summary>
    /// Static function that creates an new animation sprite frame.
    /// </summary>
    /// <param name="sprite">The animation sprite the animation frame belongs to.</param>
    /// <param name="start">The time at which the frame is to be displayed.</param>
    /// <returns></returns>
    public static AnimatedSpriteFrame Frame(Sprite sprite, double start) { 
        return new AnimatedSpriteFrame(sprite, start);
    }
    /// <summary>
    /// The sprite the animation frame belongs to.
    /// </summary>
    public Sprite Sprite => _sprite;
    /// <summary>
    /// The time at which the frame is to be displayed.
    /// </summary>
    public double Start => _start;
}

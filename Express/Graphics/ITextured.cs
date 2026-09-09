using Microsoft.Xna.Framework;

namespace Express.Graphics;

public interface ITextured
{
    public float LayerDepth { get; }
    public abstract Sprite Sprite(GameTime gameTime);
    public Color Color { get; set; }
}

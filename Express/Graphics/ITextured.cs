using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Graphics;

public interface ITextured
{
    public float LayerDepth { get; }
    public abstract Sprite Sprite(GameTime gameTime);
}

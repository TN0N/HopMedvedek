using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Graphics;

public interface ITextureData
{
    public string Name { get; set; }
    public Sprite Sprite { get; set; }

    public Dictionary<Enum, AnimatedSprite> Animation { get; set; }

}

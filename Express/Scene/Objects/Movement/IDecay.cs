using Microsoft.Xna.Framework;

namespace Express.Scene.Objects.Movement;

public interface IDecay
{
    ref float Decay { get; }
}
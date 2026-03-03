using Microsoft.Xna.Framework;

namespace Express.Scene.Objects.Movement;

public interface IAcceleration
{
    ref Vector2 Acceleration { get; }
}
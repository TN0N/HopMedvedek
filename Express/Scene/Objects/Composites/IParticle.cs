using Express.Scene.Objects.Colliders;
using Express.Scene.Objects.Movement;
using Express.Scene.Objects.Physical_Properties;

namespace Express.Scene.Objects.Composites;

/// <summary>
/// Defines the interface for an body that is movable and has mass and has a ParticleCollider.
/// </summary>
public interface IParticle : IMovable, IMass, IParticleCollider
{
}
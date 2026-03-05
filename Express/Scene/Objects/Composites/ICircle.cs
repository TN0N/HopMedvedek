using Express.Scene.Objects.Physical_Properties;
using Express.Scene.Objects.Rotation;

namespace Express.Scene.Objects.Composites;
/// <summary>
/// Defines the interface for a body that is a rotatable cicle with a particle collider.
/// </summary>
public interface ICircle : IParticle, IRotatable, IAngularMass
{
}
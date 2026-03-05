using Express.Scene.Objects.Colliders;
using Express.Scene.Objects.Movement;
using Express.Scene.Objects.Physical_Properties;

namespace Express.Scene.Objects.Composites;
/// <summary>
/// Defines the interface representing a axis-aligned body that is movable and has mass and a AARectangle collider.
/// </summary>
public interface IAARectangle : IMovable, IMass, IAARectangleCollider
{
}
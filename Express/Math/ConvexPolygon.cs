using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Express.Math;
/// <summary>
/// Defines a convex polygon - a polygon where every interior angle is less than 180° and any line segment between two points inside the polygon statys within the polygon.
/// </summary>
public class ConvexPolygon
{
    protected List<Vector2> _vertices; // The list of verticies defining the polygon
    protected List<Vector2> _edges; // The list of edges defining the polygon
    protected List<HalfPlane> _halfPlanes; // The list of HalfPlanes defining the polygon

    /// <summary>
    /// Creates a new <see cref="ConvexPolygon"/>.
    /// </summary>
    /// <param name="vertices">The verticies defining the polygon.</param>
    public ConvexPolygon(List<Vector2> vertices)
    {
        _vertices = new List<Vector2>(vertices);
        // The number of edges and HalfPlanes is equal to the number of verticies to avoid dynamic resizing.
        _edges = new List<Vector2>(_vertices.Count);
        _halfPlanes = new List<HalfPlane>(_vertices.Count);

        // For each vertex define the edge and halfplane
        for (int i = 0; i < _vertices.Count; i++)
        {
            int j = (i + 1) % _vertices.Count; // Wraps around to 0 when the last element is reached.
            Vector2 edge = _vertices[j] - _vertices[i]; // Get the direction and length between the two verticies.
            _edges.Add(edge);
            Vector2 normal = Vector2.Normalize(new Vector2(edge.Y, -edge.X));
            float distance = Vector2.Dot(_vertices[i], normal);
            _halfPlanes.Add(new HalfPlane(normal, distance)); // The halfPlane is defined by the normal and distance.
        }
    }
    /// <summary>
    /// The verticies defining the polygon.
    /// </summary>
    public ref List<Vector2> Vertices => ref _vertices;
    /// <summary>
    /// The edges defining the polygon.
    /// </summary>
    public ref List<Vector2> Edges => ref _edges;
    /// <summary>
    /// The HalfPlanes defining the polygon.
    /// </summary>
    public ref List<HalfPlane> HalfPlanes => ref _halfPlanes;
}
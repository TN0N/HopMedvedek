namespace Express.Scene.Objects.Shapes;
/// <summary>
/// Defines the interface representing a rectangular body.
/// </summary>
public interface IRectangleSize
{
    /// <summary>
    /// The width of the body.
    /// </summary>
    float Width { set; get; }
    /// <summary>
    /// The height of the body.
    /// </summary>
    float Height { set; get; }
}
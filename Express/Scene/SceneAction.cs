namespace Express.Scene;

/// <summary>
/// Defines the actions availbe for managing a scene.
/// </summary>
public class SceneAction
{
    /// <summary>
    /// The scene operation available.
    /// </summary>
    public enum SceneOperation
    {
        Add,
        Remove
    }
    
    /// <summary>
    /// The scene operation.
    /// </summary>
    private SceneOperation _operation;

    /// <summary>
    /// The scene item.
    /// </summary>
    private object _item;

    /// <summary>
    /// The scene operation.
    /// </summary>
    public SceneOperation Operation => _operation;

    /// <summary>
    /// The scene item.
    /// </summary>
    public object Item => _item;

    /// <summary>
    /// Creates a new <see cref="SceneAction"/>.
    /// </summary>
    /// <param name="sceneOperation">The scene operation to be used.</param>
    /// <param name="item">The item the operation is executed for.</param>
    public SceneAction(SceneOperation sceneOperation, object item)
    {
        _operation = sceneOperation;
        _item = item;
    }

}
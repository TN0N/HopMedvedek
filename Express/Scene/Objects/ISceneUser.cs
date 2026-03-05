namespace Express.Scene.Objects;
/// <summary>
/// Defines the interface for things that are users of a scene. A scene user is an object that can be added to a scene and removed from a scene. It has a reference to the scene it is currently in and can perform actions when it is added to or removed from a scene.
/// </summary>
public interface ISceneUser
{
    /// <summary>
    /// The scene that the object is currently in. This is set when the object is added to a scene and cleared when the object is removed from a scene.
    /// </summary>
    IScene Scene { get; set; }

    /// <summary>
    /// The function that is called when the object is added to a scene.
    /// </summary>
    /// <param name="scene">The scene that the object was added to.</param>
    void AddedToScene(IScene scene);

    /// <summary>
    /// The function that is called when the object is removed from a scene.
    /// </summary>
    /// <param name="scene">The scene that the object was removed from.</param>
    void RemovedFromScene(IScene scene);
}
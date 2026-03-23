using System;
using System.Collections.Generic;
using Express.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Express.Scene;
/// <summary>
/// Interface for a scene.
/// </summary>
public interface IScene : IEnumerable<object>, IUpdateable
{
    /// <summary>
    /// Scene event arguments
    /// </summary>
    public class SceneEventArgs : EventArgs
    {
        public object Item { get; set; }
    }
    
    /// <summary>
    /// Adds items to the scene.
    /// </summary>
    /// <param name="item">The item to be added to the scene.</param>
    public void Add(object item);
    /// <summary>
    /// Removes an item from the scene.
    /// </summary>
    /// <param name="item">The item to be removed.</param>
    public void Remove(object item);
    /// <summary>
    /// Clears a scene of all its items.
    /// </summary>
    public void Clear();
    
    /// <summary>
    /// Event handler for adding items.
    /// </summary>
    public event EventHandler<SceneEventArgs> ItemAdded;

    /// <summary>
    /// Event handler for removing items.
    /// </summary>
    public event EventHandler<SceneEventArgs> ItemRemoved;

    public Matrix CameraMatrix
    { 
        get; set;
    }

    public Dictionary<string, Texture2D> SceneTextureData { get; set; }
}
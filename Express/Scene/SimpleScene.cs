using System;
using System.Collections;
using System.Collections.Generic;
using Express.Scene.Objects;
using Microsoft.Xna.Framework;

namespace Express.Scene;
/// <summary>
/// A <see cref="GameComponent"/> that defines a simple scene.
/// </summary>
public class SimpleScene : GameComponent, IScene
{
    protected List<object> _items; // List of objects in the scene.
    protected List<SceneAction> _actions = new List<SceneAction>(); // List of actions available for scene manipulation.
    protected Matrix _cameraMatrix = Matrix.Identity; // The camera matrix for the scene.

    public event EventHandler<IScene.SceneEventArgs> ItemAdded; // Event handler for adding items.
    public event EventHandler<IScene.SceneEventArgs> ItemRemoved; // Event handler for removing items.

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// The enumeration is delegated to the underlying <c>_items</c> collection.
    /// </summary>
    /// <returns>
    /// An <see cref="IEnumerator{Object}"/> that can be used to iterate through the items.
    /// </returns>
    IEnumerator<object> IEnumerable<object>.GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// The enumeration is delegated to the underlying <c>_items</c> collection.
    /// </summary>
    /// <returns>
    /// An <see cref="IEnumerator{Object}"/> that can be used to iterate through the items.
    /// </returns>
    public IEnumerator GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    /// <summary>
    /// Creates a new <see cref="SimpleScene"/>.
    /// </summary>
    /// <param name="game">The <see cref="Game"/>.</param>
    public SimpleScene(Game game) : base(game)
    {
        _items = new List<object>();
    }

    /// <summary>
    /// Applies all pending actions.
    /// </summary>
    /// <param name="gameTime">The current game time.</param>
    public override void Update(GameTime gameTime)
    {
        for (int i = 0; i < _actions.Count; i++)
        {
            SceneAction action = _actions[i];
            object item = action.Item;
            ISceneUser sceneUser = item as ISceneUser;
            if (action.Operation == SceneAction.SceneOperation.Add)
            {
                _items.Add(item);
                if (sceneUser is not null)
                {
                    sceneUser.Scene = this;
                    sceneUser.AddedToScene(this);
                }

                ItemAdded?.Invoke(this, new IScene.SceneEventArgs { Item = item });
            }
            else
            {
                _items.Remove(item);
                if (sceneUser is not null)
                {
                    sceneUser.Scene = null;
                    sceneUser.RemovedFromScene(this);
                }

                ItemRemoved?.Invoke(this, new IScene.SceneEventArgs { Item = item });
            }
        }

        _actions.Clear();

        base.Update(gameTime);
    }
    /// <summary>
    /// Adds an item to the scene.
    /// </summary>
    /// <param name="item">The item to be added to the scene.</param>
    public void Add(object item)
    {
        _actions.Add(new SceneAction(SceneAction.SceneOperation.Add, item));
    }
    /// <summary>
    /// Removes an item from the scene.
    /// </summary>
    /// <param name="item">The item to be removed.</param>
    public void Remove(object item)
    {
        _actions.Add(new SceneAction(SceneAction.SceneOperation.Remove, item));
    }

    /// <summary>
    /// Clears a scene of all its items.
    /// </summary>
    public void Clear()
    {
        foreach (var item in _items)
            Remove(item);
    }

    public Matrix CameraMatrix
    {
        get => _cameraMatrix;
        set => _cameraMatrix = value;
    }
}
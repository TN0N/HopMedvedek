using System;
using System.Collections;
using System.Collections.Generic;
using Express.Scene.Objects.Movement;
using Microsoft.Xna.Framework;

namespace Express.Scene;
/// <summary>
/// Defines a <see cref="SimpleScene"/> that organizes its items in a grid based on their position.
/// </summary>
public class GridScene : SimpleScene
{
    /// <summary>
    /// <see langword="Dictionary"/> that maps points to a list of items at that point. The point is calculated based on the position of the item in the scene.
    /// </summary>
    protected Dictionary<Point, ArrayList> _grid;

    /// <summary>
    /// Creates a new <see cref="GridScene"/>. The constructor initializes the grid and adds ItemAddedToParent to the ItemAdded EventHandler and the ItemRemovedFromParent to the ItemRemoved EventHandler.
    /// </summary>
    /// <param name="game">The <see cref="Game"/>.</param>
    public GridScene(Game game) : base(game)
    {
        _grid = new();
        ItemAdded += ItemAddedToParent;
        ItemRemoved += ItemRemovedFromParent;
    }
    /// <summary>
    /// Gets all items at a given grid coordinate.
    /// </summary>
    /// <param name="gridCoordinate">The grid coordinate to get the items at.</param>
    /// <returns>The items at the given grid coordinate.</returns>
    public ArrayList GetItemsAt(Point gridCoordinate)
    {
        ArrayList itemsAtCoordinate = _grid.TryGetValue(gridCoordinate, out var value) ? value : new();
        return new ArrayList(itemsAtCoordinate);
    }
    /// <summary>
    /// Gets all items around a given grid coordinate within a certain distance.
    /// </summary>
    /// <param name="gridCoordinate">The grid coordinate to get the items around.</param>
    /// <param name="distance">The distance to get the items around.</param>
    /// <returns>The items around the given coordinate and distance.</returns>
    public ArrayList GetItemsAround(Point gridCoordinate, int distance)
    {
        ArrayList itemsAround = new ArrayList();
        for (int i = gridCoordinate.X - distance; i <= gridCoordinate.X + distance; i++)
        {
            for (int j = gridCoordinate.Y - distance; j <= gridCoordinate.Y + distance; j++)
            {
                ArrayList itemsAtCoordinate = _grid.TryGetValue(new Point(i, j), out var value) ? value : new();
                itemsAround.AddRange(itemsAtCoordinate);
            }
        }

        return itemsAround;
    }
    /// <summary>
    /// Event handler for when an item is added to the scene. Calculates the grid coordinate of the item and adds it to the grid. If there are already items at that coordinate, it adds the item to the existing list of items at that coordinate. If there are no items at that coordinate, it creates a new list and adds it to the grid.
    /// </summary>
    /// <param name="scene">The scene that the item was added to.</param>
    /// <param name="e">The event arguments containing the item that was added.</param>
    private void ItemAddedToParent(object scene, IScene.SceneEventArgs e)
    {
        Point? gridCoordinate = CalculateGridCoordinate(e.Item); // Calculate the grid coordinate based on the position of the item

        // If the grid coordinate has a value, find the items at the coordinate.
        if (gridCoordinate.HasValue)
        {
            ArrayList itemsAtCoordinate = _grid.TryGetValue(gridCoordinate.Value, out var value) ? value : null;

            // If there are no items at the coordinate, create a new list and add it to the dictionary
            if (itemsAtCoordinate is null)
            {
                itemsAtCoordinate = new ArrayList();
                _grid[gridCoordinate.Value] = itemsAtCoordinate;
            }
            itemsAtCoordinate.Add(e.Item);
        }
    }
    /// <summary>
    /// Event handler for when an item is removed from the scene. Calculates the grid coordinate of the item and removes it from the grid. If there are no items at that coordinate, it does nothing.
    /// </summary>
    /// <param name="scene">The scene that the item was removed from.</param>
    /// <param name="e">The event arguments containing the item that was removed.</param>
    private void ItemRemovedFromParent(object scene, IScene.SceneEventArgs e)
    {
        Point? gridCoordinate = CalculateGridCoordinate(e.Item); // Calculates the grid coordinate based on the position of the item.
        if (gridCoordinate.HasValue)
        {
            ArrayList itemsAtCoordinate = _grid.TryGetValue(gridCoordinate.Value, out var value) ? value : new();
            itemsAtCoordinate.Remove(e.Item); // Remove item from grid coordinates arraylist.
        }
    }
    /// <summary>
    /// Calculates the grid coordinates for a given item.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>The grid coordinates for the item, or null if the item does not have a position.</returns>
    public Point? CalculateGridCoordinate(object item)
    {
        Vector2? position = null;

        if (item is Vector2 vectorItem)
            position = vectorItem;
        else if (item is IPosition itemWithPosition)
            position = itemWithPosition.Position;

        if (position.HasValue)
            return new Point((int)MathF.Floor(position.Value.X), (int)MathF.Floor(position.Value.Y));
        else
            return null;
    }
    /// <summary>
    /// Calculates the grid coordinate based on an item with a position.
    /// </summary>
    /// <param name="item">The item</param>
    /// <returns>The grid coordinates for the item, or null if the item does not have a position.</returns>
    public Point CalculateGridCoordinate(IPosition item)
    {
        return CalculateGridCoordinate(item.Position);
    }
    /// <summary>
    /// Calculates the grid coordinate based on an item with a Vector2.
    /// </summary>
    /// <param name="item">The item</param>
    /// <returns>The grid coordinates for the item, or null if the item does not have a position.</returns>
    public Point CalculateGridCoordinate(Vector2 item)
    {
        item.Floor();
        return item.ToPoint();
    }
}
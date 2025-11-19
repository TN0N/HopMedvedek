using Express.Physics;
using Express.Physics.Collision;
using Express.Scene.Objects.Movement;
using HopMedvedek.Scene;
using HopMedvedek.Scene.Objects;
using Microsoft.Xna.Framework;
using System;

namespace HopMedvedek.Physics;
/// <summary>
/// Defines The physics component of the game.
/// </summary>
public class PhysicsEngine : GameComponent
{
    /// <summary>
    /// This is the level whose objects physics will be simulated by <see cref="PhysicsEngine"/>.
    /// </summary>
    protected Level _level;

    /// <summary>
    /// The constructor for <see cref="PhysicsEngine"/> which sets a reference for the level and the game.
    /// </summary>
    /// <param name="game">The <see cref="Game"/></param>
    /// <param name="level">The <see cref="Level"/></param>
    public PhysicsEngine(Game game, Level level): base(game)
    { 
        _level = level;
    }
    /// <summary>
    /// This method will calculate the physics for objects.
    /// </summary>
    /// <param name="gameTime">The <see cref="GameTime"/>.</param>
    public override void Update(GameTime gameTime)
    {
        MovementPhysics.SimulateMovement(_level.Bear, gameTime.ElapsedGameTime);
        Vector2 gravity = new Vector2(0, 1000 * (float)gameTime.ElapsedGameTime.TotalSeconds);
        foreach (object item in _level.Scene)
        {
            if (item == _level.Grounds)
            {
                foreach (Ground ground in _level.Grounds)
                {
                    Collision.CollisionBetween(_level.Bear, ground);
                }
            }
                
            if (item is Bear bear && bear.Grounded == false)
            {
                bear.Velocity += gravity;
            }
        }
    }
}

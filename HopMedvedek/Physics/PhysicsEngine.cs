using Express.Physics;
using Express.Physics.Collision;
using Express.Scene.Objects.Colliders;
using Express.Scene.Objects.Movement;
using Express.Scene.Objects.Physical_Properties;
using HopMedvedek.Level;
using HopMedvedek.Scene.Objects;
using Microsoft.Xna.Framework;

namespace HopMedvedek.Physics;
/// <summary>
/// Defines The physics component of the game.
/// </summary>
public class PhysicsEngine : GameComponent
{
    /// <summary>
    /// This is the level whose objects physics will be simulated by <see cref="PhysicsEngine"/>.
    /// </summary>
    protected LevelBase _level;

    /// <summary>
    /// The constructor for <see cref="PhysicsEngine"/> which sets a reference for the level and the game.
    /// </summary>
    /// <param name="game">The <see cref="Game"/></param>
    /// <param name="level">The <see cref="Level"/></param>
    public PhysicsEngine(Game game, LevelBase level): base(game)
    { 
        _level = level;
    }
    /// <summary>
    /// This method will calculate the physics for objects.
    /// </summary>
    /// <param name="gameTime">The <see cref="GameTime"/>.</param>
    public override void Update(GameTime gameTime)
    {
        


        // Apply gravity
        foreach (object item in _level.Scene)
        {
            //float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            MovementPhysics.SimulateMovement(item, gameTime.ElapsedGameTime);
            if (item is IGravity gravityItem && item is IVelocity velocityItem)
            {
                float gravity = gravityItem.GravitationalAcceleration * (float)gameTime.ElapsedGameTime.TotalSeconds;
                velocityItem.Velocity.Y += gravity;
            }
        }

        // Check bear for collisions
        foreach (object item in _level.Scene)
            if (item is not Bear && item is ICollider)
                Collision.CollisionBetween(item, _level.Bear);

        // Check pinecone for collisions
        /*
        foreach (object item in _level.Scene)
            if (item is not Pinecone prinecone)
                Collision.CollisionBetween(pinecone, item);*/
    }
}

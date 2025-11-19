using Express.Physics;
using HopMedvedek.Scene;
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
        foreach (object item in _level.Scene)
        { 
            
        }
    }
}

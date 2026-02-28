using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Artificial.Artificial.Utils;
/// <summary>
/// Defines the component for displaying frames per second. Inherits from <see cref="DrawableGameComponent"/>.
/// </summary>
public class FpsComponent: DrawableGameComponent
{
    private SpriteBatch _spriteBatch; // The components SpriteBatch
    private SpriteFont _spriteFont; // The font used by the component

    private int _frameRate = 0; // The frame rate
    private int _frameCounter = 0; // The count of frames
    private TimeSpan _elapsedTime = TimeSpan.Zero; // The elapsed time
    private bool _writeToConsole = false; // Boolean to define whether or not to write to console

    /// <summary>
    /// Constructor for <see cref="FpsComponent"/> that assigns its <see cref="SpriteBatch"/> and <see cref="SpriteFont"/> to the given parameters.
    /// </summary>
    /// <param name="game">The <see cref="Game"/></param>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/></param>
    /// <param name="spriteFont">The <see cref="SpriteFont"/></param>
    public FpsComponent(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont): base(game)
    { 
        _spriteBatch = spriteBatch;
        _spriteFont = spriteFont;
    }
    /// <summary>
    /// Construtor for <see cref="FpsComponent"/> that sets its <see cref="SpriteBatch"/> and <see cref="SpriteFont"/> to <see langword="null"/>.
    /// </summary>
    /// <param name="game"></param>
    public FpsComponent(Game game) : base(game)
    {
        _spriteBatch = null;
        _spriteFont = null;
    }
    /// <summary>
    /// Calculates the elapsed time since the last frame. After a second has passed, it writes the elapsed time to the console.
    /// </summary>
    /// <param name="gameTime"></param>
    public override void Update(GameTime gameTime)
    {
        _writeToConsole = false;
        _elapsedTime += gameTime.ElapsedGameTime;

        if (_elapsedTime > TimeSpan.FromSeconds(1))
        {
            _elapsedTime -= TimeSpan.FromSeconds(1);
            _frameRate = _frameCounter;
            _frameCounter = 0;
            _writeToConsole = true;
        }
    }
    /// <summary>
    /// Increments the number of frames and then draws the frame rate to the screen and writes it to the console.
    /// </summary>
    /// <param name="gameTime">The <see cref="GameTime"/> of the <see cref="Game"/>.</param>
    public override void Draw(GameTime gameTime)
    {
        _frameCounter++;

        string fps = $"fps: {_frameRate} mem : {GC.GetTotalMemory(false)}";
        if (_spriteBatch != null && _spriteFont != null)
        {
            _spriteBatch.DrawString(_spriteFont, fps, new Vector2(1, 1), Color.Black);
            _spriteBatch.DrawString(_spriteFont, fps, new Vector2(0, 0), Color.White);
        }
        else if (_writeToConsole)
        {
            Console.WriteLine(fps);
        }
    }

    public int FrameRate => _frameRate;
}

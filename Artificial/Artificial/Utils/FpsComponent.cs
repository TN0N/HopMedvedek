using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Artificial.Artificial.Utils;
/// <summary>
/// Defines a <see cref="DrawableGameComponent"/> that displays the number of frames per second.
/// </summary>
public class FpsComponent: DrawableGameComponent
{
    private SpriteBatch _spriteBatch; // The components spriteBatch
    private SpriteFont _spriteFont; // The components spriteFont

    private int _frameRate = 0; // The number of counted frames from the elapsed second
    private int _frameCounter = 0; // The counter of frames
    private TimeSpan _elapsedTime = TimeSpan.Zero;
    private bool _writeToConsole = false; // Defines whether or not to write to console

    /// <summary>
    /// Creates a new <see cref="FpsComponent"/>.
    /// </summary>
    /// <param name="game">The <see cref="Game"/>.</param>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to be used.</param>
    /// <param name="spriteFont">The <see cref="SpriteFont"/> to be used.</param>
    public FpsComponent(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont): base(game)
    { 
        _spriteBatch = spriteBatch;
        _spriteFont = spriteFont;
    }
    /// <summary>
    /// Creates a new <see cref="FpsComponent"/> with <see langword="null"/> for its <see cref="SpriteBatch"/> and <see cref="SpriteFont"/>.
    /// </summary>
    /// <param name="game">The <see cref="Game"/>.</param>
    public FpsComponent(Game game) : base(game)
    {
        _spriteBatch = null;
        _spriteFont = null;
    }
    /// <summary>
    /// Increments <see cref="_elapsedTime"/> and then checks its value. 
    /// If the value is <see langword="1"/> then <see langword="1"/> second is subtracted from the elapsed time and the value of <see cref="_frameRate"/> is set to <see cref="_frameCounter"/>.
    /// After that the <see cref="_frameCounter"/> is reset to <see langword="0"/>.
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
    /// Draws the frame rate to the screen and prints the value to the console.
    /// </summary>
    /// <param name="gameTime">The current <see cref="GameTime"/>.</param>
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

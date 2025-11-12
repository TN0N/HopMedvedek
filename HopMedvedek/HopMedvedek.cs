using HopMedvedek.Graphics;
using HopMedvedek.Scene;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace HopMedvedek;

public class HopMedvedek : Game
{
    private GraphicsDeviceManager _graphics;
    protected GameRenderer _currentRenderer;

    public HopMedvedek()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = 320;
        _graphics.PreferredBackBufferHeight = 576;
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        LoadLevel();
        base.Initialize();
    }

    protected void LoadLevel()
    {
        Level level = new Level(this);
        Director _currentDirector = new Director(this);
        _currentRenderer = new GameRenderer(this, level, _currentDirector.Camera);
        Components.Add(_currentRenderer);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
    }
}

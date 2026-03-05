using Artificial.Artificial.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace HopMedvedek;

public class HopMedvedek : Game {
    private GraphicsDeviceManager _graphics;

    public HopMedvedek()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = 320;
        _graphics.PreferredBackBufferHeight = 560;

        _graphics.ApplyChanges();
        Content.RootDirectory = "Content";
        IsMouseVisible = false;

        Components.Add(new Gameplay(this));
        Components.Add(new FpsComponent(this));
    }
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        base.Update(gameTime);
    }
}



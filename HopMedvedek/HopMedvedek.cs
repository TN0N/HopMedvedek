using Artificial.Artificial.Utils;
using HopMedvedek.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace HopMedvedek;

public class HopMedvedek : Game {
    private GraphicsDeviceManager _graphics; // The graphics device.
    private Type[] _levelClasses; // The level types

    //private Stack<GameState> _stateStack; // The game states

    public HopMedvedek()
    {
        _graphics = new GraphicsDeviceManager(this);

        LoadOptions();

        Components.Add(new Gameplay(this));
        Components.Add(new FpsComponent(this));
    }
    private void LoadOptions()
    {
        Options.Options.LoadOptions();

        _graphics.PreferredBackBufferWidth = Options.Options.Current.GraphicsDeviceWidth;
        _graphics.PreferredBackBufferHeight = Options.Options.Current.GraphicsDeviceHeight;
        
        IsMouseVisible = Options.Options.Current.IsMouseVisible;
        Content.RootDirectory = HopMedvedekConstants.HOP_MEDVEDEK_ROOT_DIRECTORY;

        _graphics.ApplyChanges();

    }
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        base.Update(gameTime);
    }
}



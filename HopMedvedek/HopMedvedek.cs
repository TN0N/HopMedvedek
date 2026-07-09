using Artificial.Artificial.Utils;
using HopMedvedek.Audio;
using HopMedvedek.Data;
using HopMedvedek.GameStates;
using HopMedvedek.GameStates.GamePlay;
using HopMedvedek.GameStates.Menus;
using HopMedvedek.Level;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace HopMedvedek;

public class HopMedvedek : Game {
    private GraphicsDeviceManager _graphics; // The graphics device.
    private Type[] _levelClasses; // The level types

    private Stack<GameState> _stateStack; // The game states

    public HopMedvedek()
    {
        _graphics = new GraphicsDeviceManager(this);

        //Components.Add(new GamePlay(this));
        //Components.Add(new FpsComponent(this));
        SoundEngine.Init(this);

        _stateStack = new Stack<GameState>();
    }
    public Type GetLevelType(LevelType type) => _levelClasses[(int)type];
    private void LoadOptions()
    {
        Options.Options.LoadOptions();
        //Window.AllowUserResizing = true;
        _graphics.PreferredBackBufferWidth = Options.Options.Current.GraphicsDeviceWidth;
        _graphics.PreferredBackBufferHeight = Options.Options.Current.GraphicsDeviceHeight;
        
        IsMouseVisible = Options.Options.Current.IsMouseVisible;
        Content.RootDirectory = HopMedvedekConstants.HOP_MEDVEDEK_ROOT_DIRECTORY;

        _graphics.ApplyChanges();

    }
    public void StackState(GameState gameState)
    {
        if (_stateStack.Count > 0)
        {
            GameState currentActiveState = _stateStack.Peek();
            currentActiveState.Deactivate();
        }
        _stateStack.Push(gameState);
        Components.Add(gameState);
        gameState.Activate();
    }
    public void PushState(GameState gameState)
    {
        // Deactivate Current
        if (_stateStack.Count > 0)
        {
            GameState currentActiveState = _stateStack.Peek();
            currentActiveState.Deactivate();
            Components.Remove(currentActiveState);
        }

        // Push new
        _stateStack.Push(gameState);
        Components.Add(gameState);
        gameState.Activate();
    }

    public void PopState()
    { 
        GameState currentActiveState = _stateStack.Pop();
        currentActiveState.Deactivate();
        Components.Remove(currentActiveState);

        currentActiveState = _stateStack.Peek();
        Components.Add(currentActiveState);
        currentActiveState.Activate();
    }
    protected override void Initialize()
    {
        LoadOptions();
        /*
        _levelClasses = new Type[(int)LevelType.LastType] {
           typeof(Level.Levels.LanguageLevel),
           typeof(Level.Levels.MathLevel)
        };*/
        
        PushState(new MainMenu(this));
        
        base.Initialize();
        SoundEngine.Play(SoundEffectType.HopMedvedekMainTheme, null, null, Options.Options.Current.MusicVolume, looping: true);
    }
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        base.Update(gameTime);
    }
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        base.Draw(gameTime);
    }
}



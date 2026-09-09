using Artificial.Artificial.Utils;
using HopMedvedek.Audio;
using HopMedvedek.Data;
using HopMedvedek.GameStates;
using HopMedvedek.GameStates.GamePlay;
using HopMedvedek.GameStates.Menus;
using HopMedvedek.Level;
using Microsoft.Xna.Framework;
#if ANDROID || IOS
using Microsoft.Xna.Framework.Graphics;
#endif
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace HopMedvedek;

public class HopMedvedek : Game {
    private GraphicsDeviceManager _graphics;
    private Type[] _levelClasses;

    private Stack<GameState> _stateStack;

    public HopMedvedek()
    {
        _graphics = new GraphicsDeviceManager(this);
        SoundEngine.Init(this);

        _stateStack = new Stack<GameState>();
    }
    public Type GetLevelType(LevelType type) => _levelClasses[(int)type];
    private void LoadOptions()
    {
        Options.Options.LoadOptions();
        ApplyBackBufferSize();

        IsMouseVisible = Options.Options.Current.IsMouseVisible;
        Content.RootDirectory = HopMedvedekConstants.HOP_MEDVEDEK_ROOT_DIRECTORY;

        _graphics.ApplyChanges();

    }

    private void ApplyBackBufferSize()
    {
#if ANDROID || IOS
        DisplayMode native = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode;
        if (native.Width > 0 && native.Height > 0)
        {
            _graphics.PreferredBackBufferWidth = native.Width;
            _graphics.PreferredBackBufferHeight = native.Height;
        }
        _graphics.IsFullScreen = true;
#else
        _graphics.PreferredBackBufferWidth = Options.Options.Current.GraphicsDeviceWidth;
        _graphics.PreferredBackBufferHeight = Options.Options.Current.GraphicsDeviceHeight;
#endif
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
        if (!Components.Contains(currentActiveState))
        {
            Components.Add(currentActiveState);
            
        }
        currentActiveState.Activate();
        
    }

    public void ApplyOptions()
    {
        SoundEngine.Instance.SetMusicVolume(Options.Options.Current.MusicVolume);
        SoundEngine.Instance.SetSoundsVolume(Options.Options.Current.GameVolume);

        ApplyBackBufferSize();
        _graphics.ApplyChanges();

        foreach (GameState state in _stateStack)
        {
            state.Initialize();
            state.Reload();
        }
        
    }
    protected override void Initialize()
    {
        LoadOptions();
        Data.PlayerData.LoadData();
        
        PushState(new MainMenu(this));
        
        base.Initialize();
        SoundEngine.Play(SoundEffectType.HopMedvedekMainTheme, null, null, Options.Options.Current.MusicVolume, looping: true, music:true);
    }
    protected override void Update(GameTime gameTime)
    {
#if !IOS
        // iOS forbids an app closing itself (Game.Exit() is an error there).
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
#endif
        base.Update(gameTime);
        global::HopMedvedek.Input.HopInput.EndFrame();
    }
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        base.Draw(gameTime);
    }
}



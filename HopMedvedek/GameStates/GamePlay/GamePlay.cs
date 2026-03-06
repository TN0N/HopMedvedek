using Artificial.Artificial.Utils;
using HopMedvedek.Entities;
using HopMedvedek.Graphics;
using HopMedvedek.Level;
using HopMedvedek.Physics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace HopMedvedek.GameStates.GamePlay;


public class GamePlay : GameState
{
    private LevelBase _level;
    private Player _player;

    private int _score;
    private int _coins;
    private int _hearts;

    private GameHud _hud;
    private GameRenderer _gameRenderer;
    private GuiRenderer _hudRenderer;
    private PhysicsEngine _physics;

    private FpsComponent _fpsComponent;
    public GamePlay(Game game, Type levelClass) : base(game)
    {
        _startInit(levelClass);
        _player = new Player(game, _level.Bear);
        _finishInit();
    }
    private void _startInit(Type levelClass)
    {
        _level = Activator.CreateInstance(levelClass, Game) as LevelBase;
        
    }
    private void _finishInit()
    { 
        _physics = new PhysicsEngine(Game, _level);
        _gameRenderer = new GameRenderer(Game, _level);
        _fpsComponent = new FpsComponent(Game);
        _hud = new GameHud(Game);
        _hudRenderer = new GuiRenderer(Game, _hud.Scene);

        _hudRenderer.DrawOrder = 1;

        _player.UpdateOrder =       0;
        _physics.UpdateOrder =      1;
        _level.UpdateOrder =        2;
        _level.Scene.UpdateOrder =  3;
        UpdateOrder =               4;
    }
    public override void Activate()
    {
        Game.Components.Add(_level);
        
        Game.Components.Add(_hud);
        Game.Components.Add(_hudRenderer);
        Game.Components.Add(_gameRenderer);
        Game.Components.Add(_physics);
        Game.Components.Add(_player);
        Game.Components.Add(_fpsComponent);

        // Add all gameComponents created by level.Scene
        foreach (var item in _level.Scene)
            if (item is GameComponent gameComponent)
                Game.Components.Add(gameComponent);
    }
    public override void Deactivate()
    {
        Game.Components.Remove(_level);
        Game.Components.Remove(_hud);
        Game.Components.Remove(_hudRenderer);
        Game.Components.Remove(_gameRenderer);
        Game.Components.Remove(_physics);
        Game.Components.Remove(_player);
        Game.Components.Remove(_fpsComponent);

        // Deactivate all gameComponents created by level.Scene
        foreach (var item in _level.Scene)
            if (item is GameComponent gameComponent)
                Game.Components.Remove(gameComponent);
    }
}

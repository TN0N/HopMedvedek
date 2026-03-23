using Artificial.Artificial.Utils;
using Express.Graphics;
using HopMedvedek.Entities;
using HopMedvedek.Graphics;
using HopMedvedek.Gui.Hud;
using HopMedvedek.Level;
using HopMedvedek.Physics;
using Microsoft.Xna.Framework;
using System;

namespace HopMedvedek.GameStates.GamePlay;


public class GamePlay : GameState
{
    private LevelBase _level;
    private Player _player;

    private int _score;
    private int _coins;
    private int _hearts;

    private GameHud _hud;
    private Renderer _gameRenderer;
    //private Renderer _hudRenderer;
    private PhysicsEngine _physics;
    private DebugRenderer _debugRenderer;

    private FpsComponent _fpsComponent;
    public GamePlay(Game game, Type levelClass) : base(game)
    {
        System.Diagnostics.Debug.WriteLine("Creating new gameplay");
        _startInit(levelClass);
        _player = new Player(game, _level.Bear);
        _finishInit();
    }
    private void _startInit(Type levelClass)
    {
        System.Diagnostics.Debug.WriteLine("Creating new level");
        _level = Activator.CreateInstance(levelClass, Game) as LevelBase;
        
    }
    private void _finishInit()
    { 
        _physics = new PhysicsEngine(Game, _level);
        _gameRenderer = new Renderer(Game, _level.Scene);
        _fpsComponent = new FpsComponent(Game);
        _hud = new GameHud(Game);
        _debugRenderer = new DebugRenderer(Game, _level.Scene);
        //_hudRenderer = new Renderer(Game, _hud.Scene);

        _gameRenderer.DrawOrder = 2;
        //_hudRenderer.DrawOrder = 1;

        _player.UpdateOrder =       0;
        _physics.UpdateOrder =      1;
        _level.UpdateOrder =        2;
        _level.Scene.UpdateOrder =  3;
        UpdateOrder =               4;
    }
    public override void Activate()
    {
        System.Diagnostics.Debug.WriteLine("Activating");
        Game.Components.Add(_level);
        
        Game.Components.Add(_hud);
        Game.Components.Add(_debugRenderer);
        //Game.Components.Add(_hudRenderer);
        Game.Components.Add(_gameRenderer);
        Game.Components.Add(_physics);
        Game.Components.Add(_player);
        Game.Components.Add(_fpsComponent);

        // Add all gameComponents created by level.Scene
        /*foreach (var item in _level.Scene)
            if (item is GameComponent gameComponent)
                Game.Components.Add(gameComponent);*/
    }
    public override void Deactivate()
    {
        Game.Components.Remove(_level);
        Game.Components.Remove(_hud);
        Game.Components.Remove(_debugRenderer);
        //Game.Components.Remove(_hudRenderer);
        Game.Components.Remove(_gameRenderer);
        Game.Components.Remove(_physics);
        Game.Components.Remove(_player);
        Game.Components.Remove(_fpsComponent);

        // Deactivate all gameComponents created by level.Scene
        /*foreach (var item in _level.Scene)
            if (item is GameComponent gameComponent)
                Game.Components.Remove(gameComponent);*/
    }
}

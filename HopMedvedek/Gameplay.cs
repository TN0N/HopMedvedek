using HopMedvedek.Graphics;
using HopMedvedek.Scene;
using HopMedvedek.Physics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Express.Graphics;

namespace HopMedvedek;

public class Gameplay: GameComponent
{
    protected Level _level;
    protected Entities.Player _player;
    protected PhysicsEngine _physics;
    protected Renderer _renderer;
    protected DebugRenderer _debugRenderer;
    //protected int _lives;
    //protected int _difficulty;

    public Gameplay(Game game): base(game) {
        _level = new Level(game);
        _player = new Entities.Player(Game, _level.Bear);
        _physics = new PhysicsEngine(Game, _level);
        _renderer = new Renderer(Game, this);
        _debugRenderer = new DebugRenderer(Game, _level.Scene);

        _player.UpdateOrder = 0;
        _physics.UpdateOrder = 1;
        _level.UpdateOrder = 2;
        UpdateOrder = 3;

        Game.Components.Add(_level);
        Game.Components.Add(_player);
        Game.Components.Add(_physics);
        Game.Components.Add(_renderer);
        Game.Components.Add(_debugRenderer);
    }

    public Level Level => _level;
    //public int Lives => _lives;

    public override void Initialize()
    {
        _debugRenderer.ColliderColor = Color.Black;
        _debugRenderer.MovementColor = Color.Blue;
        _debugRenderer.ItemColor = Color.Red;
        _debugRenderer.TransformMatrix = _level.Camera;
        _player.SetCamera(_level.Camera);
        Reset();
        base.Initialize();
    }
    public override void Update(GameTime gameTime)
    {
        _debugRenderer.TransformMatrix = _level.Camera;
    }
    public void Reset()
    {
        _level.ResetLevel();
    }
}

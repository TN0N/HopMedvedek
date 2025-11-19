using Express.Scene;
using HopMedvedek.Scene.Objects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HopMedvedek.Scene;

public class Level : GameComponent {
    protected SimpleScene _scene;
    protected Bear _bear;
    protected List<Ground> _grounds;
    protected Rectangle _bounds;
    protected TreeBase _treeBase;
    protected List<TreeMid> _treeMids;

    public Level(Game game) : base(game) {
        _scene = new SimpleScene(Game);
        Game.Components.Add(_scene);

        _bear = new Bear();
        _grounds = new List<Ground>();
        _treeMids = new List<TreeMid>();
        _treeBase = new TreeBase();
    }
    public IScene Scene => _scene;
    public Bear Bear => _bear;
    public List<Ground> Grounds => _grounds;
    public Rectangle Bounds => _bounds;

    public override void Initialize()
    {
        float aspectRatio = (float)Game.Window.ClientBounds.Width /
                                   Game.Window.ClientBounds.Height;

        _bounds = new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height);

        _bear.Position.X = 160;
        _bear.Position.Y = 240;


        _treeBase.Position.X = Game.Window.ClientBounds.Width/2;
        _treeBase.Position.Y = Game.Window.ClientBounds.Height - 16;

        TreeMid treeMid = new TreeMid();
        treeMid.Position.X = Game.Window.ClientBounds.Width / 2;
        treeMid.Position.Y = _treeBase.Position.Y + treeMid.Height;
        _treeMids.Add(treeMid);

        for (float i = 0; i < _bounds.Width; i+=0)
        {
            Ground ground = new Ground();
            ground.Position.X = i;
            ground.Position.Y = _bounds.Height - ground.Height;
            _grounds.Add(ground);
            i += ground.Width;
        }
    }
    public virtual void ResetLevel()
    {
        _scene.Clear();
        _scene.Add(_treeBase);
        _scene.Add(_treeMids);
        _scene.Add(_bear);
        _scene.Add(_grounds);
    }
    public override void Update(GameTime gameTime)
    {
        while (_treeMids.Last<TreeMid>().Position.Y > 0)
        {
            System.Diagnostics.Debug.WriteLine(_treeMids.Last<TreeMid>().Position.Y);
            TreeMid treeMid = new TreeMid();
            treeMid.Position.X = _treeMids.Last<TreeMid>().Position.X;
            treeMid.Position.Y = _treeMids.Last<TreeMid>().Position.Y - treeMid.Height;
            _treeMids.Add(treeMid);
        }
    }
}

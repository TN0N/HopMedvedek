using Express.Scene;
using HopMedvedek.Scene.Objects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

        System.Diagnostics.Debug.WriteLine(_grounds.Count);
        while (_grounds.Count < 1 || _grounds.Last<Ground>().Width + _grounds.Last<Ground>().Position.X < Game.Window.ClientBounds.Width)
        {
            Ground ground = new Ground();
            ground.Position.Y = Game.Window.ClientBounds.Height - 8;
            ground.Position.X = (_grounds.Count > 0) ? _grounds.Last<Ground>().Position.X + _grounds.Last<Ground>().Width : 0;
            _grounds.Add(ground);
        }
        while (_treeMids.Count < 1 || _treeMids.Last<TreeMid>().Position.Y > 0)
        {
            TreeMid treeMid = new TreeMid();
            treeMid.Position.X = Game.Window.ClientBounds.Width / 2; ;
            treeMid.Position.Y = (_treeMids.Count > 0)? _treeMids.Last<TreeMid>().Position.Y - treeMid.Height : _treeBase.Position.Y + treeMid.Height;
            _treeMids.Add(treeMid);
        }

    }
    public virtual void ResetLevel()
    {
        _scene.Clear();
        _scene.Add(_treeBase);
        //_scene.Add(_treeMids);
        foreach(var treeMid in _treeMids)
            _scene.Add(treeMid);
        foreach (var ground in _grounds)
            _scene.Add(ground);
        _scene.Add(_bear);
    }
    public override void Update(GameTime gameTime)
    {
        if (_bear.Position.X - _bear.Width/2 > Game.Window.ClientBounds.Width)
            _bear.Position.X = 0 - _bear.Width / 2;
        if (_bear.Position.X + _bear.Width / 2 < 0)
            _bear.Position.X = Game.Window.ClientBounds.Width + _bear.Width / 2;
        
    }
}

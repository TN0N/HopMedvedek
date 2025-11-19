using Express.Scene;
using HopMedvedek.Scene.Objects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace HopMedvedek.Scene;

public class Level : GameComponent {
    protected SimpleScene _scene;
    protected Bear _bear;
    protected List<Ground> _grounds;
    protected Rectangle _bounds;

    public Level(Game game) : base(game) {
        _scene = new SimpleScene(Game);
        Game.Components.Add(_scene);

        _bear = new Bear();
        _grounds = new List<Ground>();
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

        _bear.Position.X = 0;
        _bear.Position.Y = 0;

        for (float i = 0; i < _bounds.Width; i+=0)
        {
            System.Diagnostics.Debug.WriteLine("adding ground");
            
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

        _scene.Add(_bear);
        _scene.Add(_grounds);
    }
    public override void Update(GameTime gameTime)
    {
        
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopMedvedek.Scene;

public class Level : GameComponent {
    protected Scene _scene;

    public Level(Game game) : base(game) {
        _scene = new Scene();
    }
    public Scene Scene {
        get { return _scene; }
        set { _scene = value; }
    }
    public override void Initialize()
    {
        Console.WriteLine("Loading level");
        base.Initialize();
        Reset();
    }
    public virtual void Reset()
    {
        Console.WriteLine("Resetting level");
    }
    protected override void Dispose(bool disposing)
    {
        Console.WriteLine("Unloading level");
        base.Dispose(disposing);
    }
}

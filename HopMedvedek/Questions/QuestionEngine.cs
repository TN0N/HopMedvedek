using Artificial.Artificial.Mirage;
using Express.Graphics;
using Express.Scene;
using Express.Scene.Objects.Movement;
using Express.Scene.Objects.Rotation;
using Express.Scene.Objects.Shapes;
using HopMedvedek.Gui.Elements;
using HopMedvedek.Gui.Hud;
using HopMedvedek.Level;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace HopMedvedek.Graphics;

public class QuestionEngine : GameComponent
{
    protected LevelBase _level;
    protected GameHud _gameHud;

    public QuestionEngine(Game game, LevelBase level, GameHud gameHud) : base(game)
    {
        _level = level;
        _gameHud = gameHud;
    }

    public override void Initialize()
    {
        base.Initialize();
    }
}

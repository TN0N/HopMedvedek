using HopMedvedek.Entities;

namespace HopMedvedek.GameStates.GamePlay;

public class GamePlay : GameState
{
    private LevelBase _level;
    private Player player;

    private int _score;
    private int _coins;
    private int _hearts;

    private GameHud _hud;
    private GameRenderer _gameRenderer;
    private GuiRenderer _hudRenderer;
    private PhysicsEngine _physics;


}

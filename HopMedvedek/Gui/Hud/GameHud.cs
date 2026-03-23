using Artificial.Artificial.Mirage;
using Express.Scene;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HopMedvedek.Gui.Hud;

public class GameHud : GameComponent
{
    protected SimpleScene _scene;
    protected Label _playerScore;
    protected Label _playerCoins;
    protected Label _playerHearts;
    protected Label _playerPinecones;

    public IScene Scene => _scene;

    public GameHud(Game game) : base(game)
    {
        _scene = new SimpleScene(game);
        Game.Components.Add(_scene);
    }
    public override void Initialize()
    {
        /*
        SpriteFont font = Game.Content.Load<SpriteFont>("Hudfont");

        _playerScore = new Label(font, "Score: 0", new Vector2(0, 0));
        _playerCoins = new Label(font, "Coins: 0", new Vector2(0, 0));
        _playerHearts = new Label(font, "Hearts: 0", new Vector2(0, 0));
        _playerPinecones = new Label(font, "Pinecones: 0", new Vector2(0, 0));

        _playerScore.HorizontalAlign = HorizontalAlign.Center;
        _playerCoins.HorizontalAlign = HorizontalAlign.Left;
        _playerHearts.HorizontalAlign = HorizontalAlign.Left;
        _playerPinecones.HorizontalAlign = HorizontalAlign.Left;

        _scene.Add(_playerScore);
        _scene.Add(_playerCoins);
        _scene.Add(_playerHearts);
        _scene.Add(_playerPinecones);
        */
    }
    public override void Update(GameTime gameTime)
    {
    }
}

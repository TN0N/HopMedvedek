using Artificial.Artificial.Mirage;
using Express.Graphics;
using Express.Scene;
using Express.Scores;
using HopMedvedek.Data;
using HopMedvedek.Gui.Elements;
using HopMedvedek.Level;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace HopMedvedek.Gui.Hud;

public class GameHud : GameComponent
{
    protected SimpleScene _scene;
    protected LevelBase _level;

    protected Image _coinImage, _heartImage, _pineconeImage, _owlImage;

    protected Label _playerScore;
    protected Label _playerCoins;
    protected Label _playerHearts;
    protected Label _playerPinecones;

    public IScene Scene => _scene;

    public GameHud(Game game, LevelBase level) : base(game)
    {
        _scene = new SimpleScene(game);
        _level = level;
        Game.Components.Add(_scene);
    }
    public override void Initialize()
    {
        
        SpriteFont font = Game.Content.Load<SpriteFont>(HopMedvedekConstants.HOP_MEDVEDEK_LUCKIESTGUY_FONT);

        _scene.SceneTextureData = new Dictionary<string, Texture2D>
        {
            [HopMedvedekConstants.HOP_MEDVEDEK_COIN_TEXTURE] = Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_COIN_TEXTURE),
            [HopMedvedekConstants.HOP_MEDVEDEK_HEART_TEXTURE] = Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_HEART_TEXTURE),
            [HopMedvedekConstants.HOP_MEDVEDEK_PINECONE_ROTATE_TEXTURE] = Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_PINECONE_ROTATE_TEXTURE),
            [HopMedvedekConstants.HOP_MEDVEDEK_OWL_TEXTURE] = Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_OWL_TEXTURE)
        };

        _coinImage = new Image(
            new AnimatedSprite(HopMedvedekConstants.HOP_MEDVEDEK_COIN_TEXTURE, new Rectangle(0, 0, 15, 16), new Vector2(7, 8), 8, 900, true),
            new Rectangle(20, 80, 30, 32)
            );
        _heartImage = new Image(
            new AnimatedSprite(HopMedvedekConstants.HOP_MEDVEDEK_HEART_TEXTURE, new Rectangle(0, 0, 15, 16), new Vector2(7, 8), 6, 1000, true),
            new Rectangle(20, 115, 30, 32)
            );
        _pineconeImage = new Image(
            new AnimatedSprite(HopMedvedekConstants.HOP_MEDVEDEK_PINECONE_ROTATE_TEXTURE, new Rectangle(0, 0, 30, 32), new Vector2(15, 16), 9, 1300, true),
            new Rectangle(20, 150, 30, 32)
            );
        _owlImage = new Image(
            new AnimatedSprite(HopMedvedekConstants.HOP_MEDVEDEK_OWL_TEXTURE, new Rectangle(0, 0, 68, 54), new Vector2(34, 27), 8, 700, true),
            new Rectangle(350, 100, 100, 80)
            );

        _playerScore = new Label(font, "0", new Vector2(Game.Window.ClientBounds.Width/2, 20));
        _playerCoins = new Label(font, "0", new Vector2(40, 70));
        _playerHearts = new Label(font, "0", new Vector2(40, 105));
        _playerPinecones = new Label(font, "0", new Vector2(40, 140));

        _playerScore.HorizontalAlign = HorizontalAlign.Center;
        _playerCoins.HorizontalAlign = HorizontalAlign.Left;
        _playerHearts.HorizontalAlign = HorizontalAlign.Left;
        _playerPinecones.HorizontalAlign = HorizontalAlign.Left;


        _scene.Add(_coinImage);
        _scene.Add(_heartImage);
        _scene.Add(_pineconeImage);
        _scene.Add(_owlImage);

        _scene.Add(_playerScore);
        _scene.Add(_playerCoins);
        _scene.Add(_playerHearts);
        _scene.Add(_playerPinecones);
    }
    public override void Update(GameTime gameTime)
    {
        _playerScore.Text = "" + Scores.score;
    }
}

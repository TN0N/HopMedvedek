using Artificial.Artificial.Mirage;
using Express.Graphics;
using Express.Scene;
using Express.Scene.Objects;
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

    protected Image _coinImage, _heartImage, _pineconeImage, _owlImage, _questionImage, _questionBubble, _correctWrong;

    protected Label _playerScore;
    protected Label _playerCoins;
    protected Label _playerHearts;
    protected Label _playerPinecones;

    protected Lifetime _correctWrongLifetime;
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
            [HopMedvedekConstants.HOP_MEDVEDEK_OWL_TEXTURE] = Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_OWL_TEXTURE),
            [HopMedvedekConstants.HOP_MEDVEDEK_SPEECH_BUBBLE_TEXTURE] = Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_SPEECH_BUBBLE_TEXTURE),
            [HopMedvedekConstants.HOP_MEDVEDEK_CORRECT] = Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_CORRECT),
            [HopMedvedekConstants.HOP_MEDVEDEK_WRONG] = Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_WRONG),
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
        _questionBubble = new Image(
            new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_SPEECH_BUBBLE_TEXTURE, new Rectangle(0, 0, 300, 400), new Vector2(150, 200)),
            new Rectangle(HopMedvedekConstants.screenWidth / 2, (int)_owlImage.Position.Y + 105, 300, 400)
            );

        _playerScore = new Label(font, "0", new Vector2(HopMedvedekConstants.screenWidth / 2, 20));
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
    public void ShowQuestionImage(string questionSheetTexture, Rectangle textureRectangle)
    {
        _questionImage = new Image(
            new Sprite(questionSheetTexture, textureRectangle, new Vector2(textureRectangle.Width / 2, textureRectangle.Height / 2)),
            new Rectangle(HopMedvedekConstants.screenWidth / 2, (int)_owlImage.Position.Y+100, 128, 192)
            );
        _questionImage.LayerDepth = 0.9f;
        _scene.Add(_questionBubble);
        _scene.Add(_questionImage);
        
    }
    public void HideQuestionImage(bool? correct)
    {
        if (_questionImage != null)
        {
            _scene.Remove(_questionBubble);
            _scene.Remove(_questionImage);
            _questionImage = null;
        }
        if (correct != null)
        {
            if ((bool)correct)
            {
                _correctWrong = new Image(
                    new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_CORRECT, new Rectangle(0, 0, 128, 128), new Vector2(64, 64)),
                    new Rectangle(HopMedvedekConstants.screenWidth / 2, HopMedvedekConstants.screenHeight, 128, 128));
            }
            else if (!(bool)correct)
            {
                _correctWrong = new Image(
                    new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_WRONG, new Rectangle(0, 0, 128, 128), new Vector2(64, 64)),
                    new Rectangle(HopMedvedekConstants.screenWidth / 2, HopMedvedekConstants.screenHeight, 128, 128));
            }
            _correctWrong.Velocity = new Vector2(0, -200);
            _correctWrong.Decay = new Vector2(1, 0.99f);
            _scene.Add(_correctWrong);
        }
    }
    public override void Update(GameTime gameTime)
    {
        //float v = -200 * (float)gameTime.ElapsedGameTime.TotalSeconds;
        //Vector2 correctWrongVelocity = new Vector2(0, v);
        /**/
        if (_correctWrong != null)
        {
            if (_correctWrongLifetime == null)
                _correctWrongLifetime = new Lifetime(gameTime.TotalGameTime.TotalMilliseconds, 1.5f);
            else if (_correctWrongLifetime.IsAlive)
                _correctWrongLifetime.Update(gameTime);
            else
            {
                _correctWrongLifetime = null;
                _scene.Remove(_correctWrong);
                _correctWrong = null;
            }
        }

        

        _playerScore.Text = "" + Scores.score;
        _playerHearts.Text = "" + _level.Bear.PlayerHP;
        _playerCoins.Text = "" + _level.Bear.PlayerCoins;
        _playerPinecones.Text = "" + _level.Bear.PlayerPinecones;
    }
}

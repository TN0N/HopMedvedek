using Express.Graphics;
using Express.Scene.Objects.Movement;
using HopMedvedek.Scene.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace HopMedvedek.Graphics;

public class GameRenderer : DrawableGameComponent
{
    protected SpriteBatch _spriteBatch;
    protected Texture2D _levelBackground, _natureTexture, _playerTexture;
    protected Dictionary<string, AnimatedSprite> _playerSprites;

    protected Sprite _trunkBase, _trunkMid, _ground;
    protected Gameplay _gameplay;

    public GameRenderer(Game game, Gameplay gameplay) : base(game)
    {
        _gameplay = gameplay;
    }


    public override void Initialize()
    {
        base.Initialize();
    }


    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _levelBackground = Game.Content.Load<Texture2D>("sky");
        _natureTexture = Game.Content.Load<Texture2D>("nature");
        _playerTexture = Game.Content.Load<Texture2D>("bear");

        const int playerAnimationSpeed = 500;



        // Load player animations
        _playerSprites = new Dictionary<string, AnimatedSprite>();
        _playerSprites.Add("idle", new AnimatedSprite(_playerTexture, new Rectangle(0, 0, 23, 32), new Vector2(12,16), 12, playerAnimationSpeed, true));
        _playerSprites.Add("walkThrow", new AnimatedSprite(_playerTexture, new Rectangle(0, 32, 23, 32), new Vector2(12, 16), 12, playerAnimationSpeed, true));
        _playerSprites.Add("walk", new AnimatedSprite(_playerTexture, new Rectangle(0, 64, 23, 32), new Vector2(12, 16), 12, playerAnimationSpeed, true));
        _playerSprites.Add("jumpUp", new AnimatedSprite(_playerTexture, new Rectangle(0, 96, 23, 32), new Vector2(12, 16), 6, playerAnimationSpeed, true));
        _playerSprites.Add("jumpDown", new AnimatedSprite(_playerTexture, new Rectangle(115, 96, 23, 32), new Vector2(12, 16), 6, playerAnimationSpeed, true));
        _playerSprites.Add("jumpThrow", new AnimatedSprite(_playerTexture, new Rectangle(0, 128, 23, 32), new Vector2(12, 16), 12, playerAnimationSpeed, true));
        _playerSprites.Add("dazed", new AnimatedSprite(_playerTexture, new Rectangle(0, 160, 23, 32), new Vector2(12, 16), 12, playerAnimationSpeed, true));


        _trunkBase = new Sprite();
        _trunkBase.Texture = _natureTexture;
        _trunkBase.SourceRectangle = new Rectangle(28, 11, 47, 26);
        _trunkBase.Origin = new Vector2(23, 13);

        _trunkMid = new Sprite();
        _trunkMid.Texture = _natureTexture;
        _trunkMid.SourceRectangle = new Rectangle(0, 0, 28, 37);
        _trunkMid.Origin = new Vector2(14, 37);

        _ground = new Sprite();
        _ground.Texture = _natureTexture;
        _ground.SourceRectangle = new Rectangle(0, 37, 320, 16);
        _ground.Origin = new Vector2(160, 8);
    }
    public override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.LightSkyBlue);
        _spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, _gameplay.Level.Camera);

        foreach (object item in _gameplay.Level.Scene)
        {
            Sprite sprite = null;
            SpriteEffects spriteEffects = SpriteEffects.None;
            switch (item)
            {
                case Ground:
                    sprite = _ground;
                    break;
                case TreeBase:
                    sprite = _trunkBase; break;
                case TreeMid:
                    sprite = _trunkMid;
                    break;
                case Bear _bear:
                    switch (_bear.State)
                    { 
                        case Bear.StateEnum.Idle:
                            sprite = _playerSprites["idle"].SpriteAtTime(gameTime.TotalGameTime.TotalMilliseconds);
                            break;
                        case Bear.StateEnum.Walk:
                            sprite = _playerSprites["walk"].SpriteAtTime(gameTime.TotalGameTime.TotalMilliseconds);
                            break;
                        case Bear.StateEnum.WalkThrow:
                            sprite = _playerSprites["walkThrow"].SpriteAtTime(gameTime.TotalGameTime.TotalMilliseconds);
                            break;
                        case Bear.StateEnum.JumpUp:
                            sprite = _playerSprites["jumpUp"].SpriteAtTime(gameTime.TotalGameTime.TotalMilliseconds);
                            break;
                        case Bear.StateEnum.JumpDown:
                            sprite = _playerSprites["jumpDown"].SpriteAtTime(gameTime.TotalGameTime.TotalMilliseconds);
                            break;
                        case Bear.StateEnum.JumpThrow:
                            sprite = _playerSprites["jumpThrow"].SpriteAtTime(gameTime.TotalGameTime.TotalMilliseconds);
                            break;
                        case Bear.StateEnum.Dazed:
                            sprite = _playerSprites["dazed"].SpriteAtTime(gameTime.TotalGameTime.TotalMilliseconds);
                            break;
                    }
                    switch (_bear.Facing)
                    { 
                        case Bear.FacingEnum.Left:
                            spriteEffects = SpriteEffects.None;
                            break;
                        case Bear.FacingEnum.Right:
                            spriteEffects = SpriteEffects.FlipHorizontally;
                            break;
                    }
                    break;
                default:
                    break;
            }
            if (item is IPosition itemWithPos && sprite is not null)
            {
                _spriteBatch.Draw(sprite.Texture, itemWithPos.Position, sprite.SourceRectangle, Color.White, 0f, sprite.Origin, 1f, spriteEffects, 0);
            }
        }
        _spriteBatch.End();
    }
}

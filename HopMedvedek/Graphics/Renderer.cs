using Express.Graphics;
using Express.Scene.Objects.Movement;
using HopMedvedek.Entities;
using HopMedvedek.Scene;
using HopMedvedek.Scene.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace HopMedvedek.Graphics;

public class Renderer : DrawableGameComponent
{
    protected SpriteBatch _spriteBatch;
    protected Texture2D _levelBackground, _natureTexture, _playerTexture;
    protected Dictionary<string, AnimatedSprite> _playerSprites;

    protected Sprite _trunkBase, _trunkMid, _ground;
    protected Gameplay _gameplay;
    protected Matrix _camera;

    public Renderer(Game game, Gameplay gameplay) : base(game)
    {
        _gameplay = gameplay;
    }

    public Matrix Camera => _camera;

    public override void Initialize()
    {
        _camera = Matrix.CreateScale(new Vector3(1, 1, 1));
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
        _playerSprites.Add("idle", new AnimatedSprite(_playerTexture, new Rectangle(0, 0, 36, 42), new Vector2(0,0), 12, playerAnimationSpeed, true));
        _playerSprites.Add("throw", new AnimatedSprite(_playerTexture, new Rectangle(0, 42, 36, 42), new Vector2(0, 0), 8, playerAnimationSpeed, true));
        _playerSprites.Add("walk", new AnimatedSprite(_playerTexture, new Rectangle(0, 84, 36, 42), new Vector2(0, 0), 8, playerAnimationSpeed, true));
        _playerSprites.Add("jumpUp", new AnimatedSprite(_playerTexture, new Rectangle(0, 126, 36, 42), new Vector2(0, 0), 5, playerAnimationSpeed, true));
        _playerSprites.Add("jumpDown", new AnimatedSprite(_playerTexture, new Rectangle(0, 168, 36, 42), new Vector2(0, 0), 5, playerAnimationSpeed, true));
        

        _trunkBase = new Sprite();
        _trunkBase.Texture = _natureTexture;
        _trunkBase.SourceRectangle = new Rectangle(28, 11, 47, 26);
        _trunkBase.Origin = new Vector2(23, 26);

        _trunkMid = new Sprite();
        _trunkMid.Texture = _natureTexture;
        _trunkMid.SourceRectangle = new Rectangle(0, 0, 28, 37);
        _trunkMid.Origin = new Vector2(14, 37);

        _ground = new Sprite();
        _ground.Texture = _natureTexture;
        _ground.SourceRectangle = new Rectangle(0, 37, 16, 320);
        _ground.Origin = new Vector2(0, 0);
    }
    public override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.LightSkyBlue);
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, _camera);

        foreach (object item in _gameplay.Level.Scene)
        {
            Sprite sprite = null;
            SpriteEffects spriteEffects = SpriteEffects.None;
            switch (item)
            {
                case List<Ground> grounds:
                    foreach (var ground in grounds)
                    {
                        sprite = _ground;
                        if (ground is IPosition groundWithPos && sprite is not null)
                            _spriteBatch.Draw(sprite.Texture, groundWithPos.Position, sprite.SourceRectangle,
                                 Color.White, 0f, sprite.Origin, 1f, spriteEffects, 0);
                    }
                    break;
                case TreeBase:
                    sprite = _trunkBase; break;
                case List<TreeMid> treeMids:
                    foreach (var treeMid in treeMids)
                    {
                        sprite = _trunkMid;
                        if (treeMid is IPosition treeMidWithPos && sprite is not null)
                            _spriteBatch.Draw(sprite.Texture, treeMidWithPos.Position, sprite.SourceRectangle,
                                 Color.White, 0f, sprite.Origin, 1f, spriteEffects, 0);
                    }
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
                        case Bear.StateEnum.JumpUp:
                            sprite = _playerSprites["jumpUp"].SpriteAtTime(gameTime.TotalGameTime.TotalMilliseconds);
                            break;
                        case Bear.StateEnum.JumpDown:
                            sprite = _playerSprites["jumpDown"].SpriteAtTime(gameTime.TotalGameTime.TotalMilliseconds);
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
                _spriteBatch.Draw(sprite.Texture, itemWithPos.Position, sprite.SourceRectangle,
                                  Color.White, 0f, sprite.Origin, 1f, spriteEffects, 0);
            }
        }
        _spriteBatch.End();
    }
}

using Express.Graphics;
using Express.Scene;
using Express.Scene.Objects.Movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace HopMedvedek.Graphics;

public class Renderer : DrawableGameComponent
{
    
    protected SpriteBatch _spriteBatch;
    protected SpriteSortMode _spriteSortMode = SpriteSortMode.Deferred;
    protected BlendState _blendState = null;
    protected SamplerState _samplerState = null;
    protected DepthStencilState _depthStencilState = null;
    protected RasterizerState _rasterizerState = null;
    protected Effect _effect = null;

    protected IScene _scene;

    public Renderer(Game game, IScene scene) : base(game)
    {
        _scene = scene;
        _spriteBatch = new SpriteBatch(game.GraphicsDevice);
    }
    protected void ChangeSpriteMode(ITexture textureItem)
    {

        if (textureItem.SpriteSortMode != _spriteSortMode
         || textureItem.BlendState != _blendState
         || textureItem.SamplerState != _samplerState
         || textureItem.DepthStencilState != _depthStencilState
         || textureItem.RasterizerState != _rasterizerState
         || textureItem.Effect != _effect)
        {
            _spriteSortMode = textureItem.SpriteSortMode;
            _blendState = textureItem.BlendState;
            _samplerState = textureItem.SamplerState;
            _depthStencilState = textureItem.DepthStencilState;
            _rasterizerState = textureItem.RasterizerState;
            _effect = textureItem.Effect;
            _spriteBatch.End();
            _spriteBatch.Begin(_spriteSortMode, _blendState, _samplerState, _depthStencilState, _rasterizerState, _effect, _scene.CameraMatrix);
        }


    }
    public override void Initialize()
    {
        base.Initialize();
    }
    public override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.LightSkyBlue);

        

        _spriteBatch.Begin(_spriteSortMode, _blendState, _samplerState, _depthStencilState, _rasterizerState, _effect, _scene.CameraMatrix);
        foreach (object item in _scene)
        {
            if (item is ITexture textureItem && item is IPosition itemPosition)
            {
                ChangeSpriteMode(textureItem);
            }
            /*
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
            }*/
        }
        _spriteBatch.End();
    }
}

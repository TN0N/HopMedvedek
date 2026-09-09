using Express.Graphics;
using Express.Scene;
using Express.Scene.Objects.Colliders;
using Express.Scene.Objects.Movement;
using HopMedvedek.Audio;
using HopMedvedek.Data;
using Microsoft.Xna.Framework;

namespace HopMedvedek.Scene.Objects;

public class Coin : Entity, IAARectangleCollider, IPosition, ICustomCollider
{
    protected AnimatedSprite _animation = new AnimatedSprite(HopMedvedekConstants.HOP_MEDVEDEK_MENU_ELEMENTS, new Rectangle(358, 118, 15, 16), new Vector2(7, 8), 8, 700, true);
    protected IScene _scene;

    public Coin(Game game, IScene scene) : base(game)
    {
        _width = 30;
        _height = 32;
        _scene = scene;
        //_decay = new Vector2(1f, 1f);

        _mass = 10f;
        _layerDepth = 0.8f;
    }
    public bool CollidingWith(object item, bool defaultValue = false)
    {
        if (item is Bear bear)
        {
            bear.PlayerCoins++;
            _scene.Remove(this);
            SoundEngine.Play(SoundEffectType.Coin, null, null, Options.Options.Current.GameVolume);
        }
        return false;
    }
    public void CollidedWith(object item)
    {

        
    }

    public override Sprite Sprite(GameTime gameTime)
    {
        return _animation.SpriteAtTime(gameTime.TotalGameTime.TotalMilliseconds);
    }
}

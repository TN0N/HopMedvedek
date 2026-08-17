using Microsoft.Xna.Framework;
using Artificial.Artificial.Mirage;
using HopMedvedek.Gui.Elements;
using HopMedvedek.Data.Strings;
using Express.Graphics;
using HopMedvedek.Data;
using Microsoft.Xna.Framework.Graphics;
namespace HopMedvedek.GameStates.Menus;

public class ShopMenu : Menu
{
    protected Label _coinsLabel;
    protected Image _coinsImage, _skinImage;
    protected Button _leftButton, _rightButton, _buyButton, _applyButton;
    public ShopMenu(Game game) : base(game)
    {
        base.Initialize();
        _leftButton = new Button(new Rectangle(30, 300, 50, 50), _buttonBackground, _luckiestGuy, "<");
        _rightButton = new Button(new Rectangle(330, 300, 50, 50), _buttonBackground, _luckiestGuy, ">");
        _buyButton = new Button(new Rectangle(100, 400, 200, 90), _buttonBackground, _luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_SHOP_MENU_BUY][Options.Options.Current.Language]);
        _applyButton = new Button(new Rectangle(100, 500, 200, 90), _buttonBackground, _luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_SHOP_MENU_APPLY][Options.Options.Current.Language]);
        _coinsImage = new Image(
            new AnimatedSprite(HopMedvedekConstants.HOP_MEDVEDEK_MENU_ELEMENTS, new Rectangle(358, 118, 15, 16), new Vector2(7, 8), 8, 900, true),
            new Rectangle(30, 130, 45, 48)
            );
        _coinsLabel = new Label(_luckiestGuy, PlayerData.Current.Coins + "", new Vector2(70, 135));
        _coinsLabel.VerticalAlign = VerticalAlign.Middle;
        _coinsLabel.HorizontalAlign = HorizontalAlign.Left;

        _scene.SceneTextureData.Add(HopMedvedekConstants.HOP_MEDVEDEK_BEAR_TEXTURE, Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_BEAR_TEXTURE));

        _skinImage = new Image(
            new AnimatedSprite(HopMedvedekConstants.HOP_MEDVEDEK_BEAR_TEXTURE, new Rectangle(0, 0, 23, 32), new Vector2(11, 16), 12, 900, true),
            new Rectangle(200, 300, 92, 128)
            );

        _scene.Add(_skinImage);
        _scene.Add(_coinsImage);
        _scene.Add(_coinsLabel);
        _scene.Add(_buyButton);
        _scene.Add(_applyButton);
        _scene.Add(_leftButton);
        _scene.Add(_rightButton);
        _scene.Add(_back);
    }
    public override void Update(GameTime gameTime)
    {
        _coinsLabel.Text = PlayerData.Current.Coins + "";
        base.Update(gameTime);
        GameState newState = null;
        if (newState is not null)
        {
            _hopMedvedek.PushState(newState);
        }
    }
}


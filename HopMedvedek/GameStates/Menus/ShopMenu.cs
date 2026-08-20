using Artificial.Artificial.Mirage;
using Express.Graphics;
using HopMedvedek.Data;
using HopMedvedek.Data.Strings;
using HopMedvedek.Gui.Elements;
using HopMedvedek.Shop;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace HopMedvedek.GameStates.Menus;

public class ShopMenu : Menu
{
    protected Label _coinsLabel, _skinName, _skinCost;
    protected Image _coinsImage, _skinImage;
    protected Button _leftButton, _rightButton, _buyButton, _applyButton;
    protected Shop.Shop _shop;

    public ShopMenu(Game game) : base(game)
    {
        _shop = new Shop.Shop();
        base.Initialize();
        _leftButton = new Button(new Rectangle(30, 300, 50, 50), _buttonBackground, _luckiestGuy, "<");
        _rightButton = new Button(new Rectangle(330, 300, 50, 50), _buttonBackground, _luckiestGuy, ">");
        _buyButton = new Button(new Rectangle(100, 450, 200, 90), _buttonBackground, _luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_SHOP_MENU_BUY][Options.Options.Current.Language]);
        _applyButton = new Button(new Rectangle(100, 550, 200, 90), _buttonBackground, _luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_SHOP_MENU_APPLY][Options.Options.Current.Language]);
        _coinsImage = new Image(
            new AnimatedSprite(HopMedvedekConstants.HOP_MEDVEDEK_MENU_ELEMENTS, new Rectangle(358, 118, 15, 16), new Vector2(7, 8), 8, 900, true),
            new Rectangle(30, 130, 45, 48)
            );
        _coinsLabel = new Label(_luckiestGuy, PlayerData.Current.Coins + "", new Vector2(70, 135));
        _coinsLabel.VerticalAlign = VerticalAlign.Middle;
        _coinsLabel.HorizontalAlign = HorizontalAlign.Left;

        _scene.SceneTextureData.Add(HopMedvedekConstants.HOP_MEDVEDEK_BEAR_TEXTURE, Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_BEAR_TEXTURE));
        _scene.SceneTextureData.Add(HopMedvedekConstants.HOP_MEDVEDEK_BEAR_RED_TEXTURE, Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_BEAR_RED_TEXTURE));
        _scene.SceneTextureData.Add(HopMedvedekConstants.HOP_MEDVEDEK_BEAR_GREEN_TEXTURE, Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_BEAR_GREEN_TEXTURE));
        _scene.SceneTextureData.Add(HopMedvedekConstants.HOP_MEDVEDEK_BEAR_BLUE_TEXTURE, Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_BEAR_BLUE_TEXTURE));
        _scene.SceneTextureData.Add(HopMedvedekConstants.HOP_MEDVEDEK_BEAR_RAINBOW_TEXTURE, Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_BEAR_RAINBOW_TEXTURE));


        _skinName = new Label(_luckiestGuy, _shop.DisplaySkin.Name + "", new Vector2(200, 200));
        _skinCost = new Label(_luckiestGuy, _shop.DisplaySkin.Price + "", new Vector2(200, 400));

        _skinName.HorizontalAlign = HorizontalAlign.Center;
        _skinName.VerticalAlign = VerticalAlign.Middle;
        _skinCost.HorizontalAlign = HorizontalAlign.Center;
        _skinCost.VerticalAlign = VerticalAlign.Middle;
        LoadSkin();

        _scene.Add(_skinName);
        _scene.Add(_skinCost);
        _scene.Add(_coinsImage);
        _scene.Add(_coinsLabel);
        _scene.Add(_buyButton);
        _scene.Add(_applyButton);
        _scene.Add(_leftButton);
        _scene.Add(_rightButton);
        _scene.Add(_back);
    }
    public override void ReloadLabels()
    {
        _buyButton.Label.Text = Strings.Localizations[StringKey.HOP_MEDVEDEK_SHOP_MENU_BUY][Options.Options.Current.Language];
        _applyButton.Label.Text = Strings.Localizations[StringKey.HOP_MEDVEDEK_SHOP_MENU_APPLY][Options.Options.Current.Language];
        _back.Label.Text = Strings.Localizations[StringKey.HOP_MEDVEDEK_COMMON_MENU_BACK][Options.Options.Current.Language];
        LoadSkin();
    }
    private void LoadSkin()
    {
        _scene.Remove(_skinImage);

        _skinImage = new Image(
            new AnimatedSprite(_shop.DisplaySkin.Texture, new Rectangle(0, 0, 23, 32), new Vector2(11, 16), 12, 900, true),
            new Rectangle(200, 300, 92, 128)
            );

        _skinName.Text = Strings.Localizations[Enum.Parse<StringKey>(_shop.DisplaySkin.Name)][Options.Options.Current.Language];
        _skinCost.Text = (_shop.DisplaySkin.Owned) ?
            Strings.Localizations[StringKey.HOP_MEDVEDEK_SHOP_MENU_OWNED][Options.Options.Current.Language] :
            Strings.Localizations[StringKey.HOP_MEDVEDEK_SHOP_MENU_PRICE][Options.Options.Current.Language] + ": " + _shop.DisplaySkin.Price;


        bool canBuy = !_shop.DisplaySkin.Owned;
        bool canApply = _shop.DisplaySkin.Owned && _shop.DisplaySkin.Texture != PlayerData.Current.SkinTexture;

        if (canBuy)
        {
            _buyButton.Enabled = true;
            _buyButton.Color = Color.White;
        }
        else {
            _buyButton.Enabled = false;
            _buyButton.Color = Color.Gray;
        }

        if (canApply)
        {
            _applyButton.Enabled = true;
            _applyButton.Color = Color.White;
        }
        else
        {
            _applyButton.Enabled = false;
            _applyButton.Color = Color.Gray;
        }
        _scene.Add(_skinImage);
    }
    
    public override void Update(GameTime gameTime)
    {
        _coinsLabel.Text = PlayerData.Current.Coins + "";
        base.Update(gameTime);
        GameState newState = null;
        if (_leftButton.WasReleased)
        {
            _shop.ShiftDisplaySkin(false);
            LoadSkin();
        }
        if (_rightButton.WasReleased)
        {
            _shop.ShiftDisplaySkin(true);
            LoadSkin();
        }
        if (_buyButton.WasReleased && _buyButton.Enabled)
        {
            _shop.Buy();
            _buyButton.UpdateWithInverseView(new Matrix());
            LoadSkin();
            return;
        }
        if (_applyButton.WasReleased)
        { 
            _shop.ApplySkin();
            _applyButton.UpdateWithInverseView(new Matrix());
            LoadSkin();
            return;
        }
        if (newState is not null)
        {
            _hopMedvedek.PushState(newState);
        }
    }
}


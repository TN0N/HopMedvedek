using HopMedvedek.Audio;
using HopMedvedek.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HopMedvedek.Shop;

public class Shop
{
    protected Dictionary<string, ShopItem> _shopItems = new();
    protected string _displaySkin;
    private class ShopItemData
    {
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public bool Owned { get; set; }
        public string Texture { get; set; } = string.Empty;
    }
    public Shop()
    {
        LoadShopItems();
    }
    private void LoadShopItems()
    {
        _displaySkin = PlayerData.Current.Skin;

        string json = File.ReadAllText(
            HopMedvedekConstants.HOP_MEDVEDEK_SHOP_ITEMS_PATH
        );
        JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
        jsonOptions.IncludeFields = true;
        jsonOptions.PropertyNameCaseInsensitive = true;

        Dictionary<string, ShopItemData>? items =
            JsonSerializer.Deserialize<Dictionary<string, ShopItemData>>(json, jsonOptions);

        if (items == null)
            return;

        _shopItems = new Dictionary<string, ShopItem>();

        foreach (var item in items)
        {
            _shopItems[item.Key] = new ShopItem(
                item.Value.Name,
                item.Value.Price,
                item.Value.Owned,
                item.Value.Texture
            );
        }
        foreach (string key in _shopItems.Keys)
        { 
            System.Diagnostics.Debug.WriteLine(
                key + ": " + 
                _shopItems[key].Name + "\n" +
                _shopItems[key].Price + "\n" +
                _shopItems[key].Owned + "\n" +
                _shopItems[key].Texture
                );
        }
    }
    private void SaveItems()
    {
        string json = JsonSerializer.Serialize(_shopItems, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(HopMedvedekConstants.HOP_MEDVEDEK_SHOP_ITEMS_PATH, json);
    }
    public void ApplySkin()
    {
        PlayerData.Current.Skin = _displaySkin;
        PlayerData.Current.SkinTexture = _shopItems[_displaySkin].Texture;

        PlayerData.SaveData();
    }
    public void Buy()
    {
        if (PlayerData.Current.Coins < _shopItems[_displaySkin].Price)
        {
            SoundEngine.Play(SoundEffectType.WrongAnswer, null, null, Options.Options.Current.GameVolume);
            return;
        }
        SoundEngine.Play(SoundEffectType.CorrectAnswer, null, null, Options.Options.Current.GameVolume);
        _shopItems[_displaySkin].Owned = true;
        PlayerData.Current.Coins -= _shopItems[_displaySkin].Price;
        PlayerData.SaveData();
        SaveItems();

    }
    public ShopItem DisplaySkin
    {
        get => _shopItems[_displaySkin];
    }
    public void ShiftDisplaySkin(bool right)
    { 
        int index = _shopItems.Keys.ToList().IndexOf(_displaySkin);
        System.Diagnostics.Debug.WriteLine(index);

        index += (right) ? 1 : -1;

        if (index < 0)
            index = _shopItems.Count - 1;
        if (index > _shopItems.Count - 1)
            index = 0;

        _displaySkin = _shopItems.ElementAt(index).Key;
        System.Diagnostics.Debug.WriteLine(_displaySkin);
    }
}

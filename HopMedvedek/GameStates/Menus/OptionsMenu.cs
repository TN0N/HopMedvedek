using Microsoft.Xna.Framework;
using Artificial.Artificial.Mirage;
using HopMedvedek.Data.Strings;
using HopMedvedek.Gui.Elements;
using HopMedvedek.Data;
using Microsoft.Xna.Framework.Graphics;
using Express.Graphics;
using HopMedvedek.Options;
using System.Collections.Generic;
using System;
namespace HopMedvedek.GameStates.Menus;

public class OptionsMenu : Menu
{
    protected Label _resolutionLabel, _gameVolumeLabel, _musicVolumeLabel, _languageLabel;
    protected Slider _gameVolumeSlider, _musicVolumeSlider;
    protected Dropdown _languageDropdown, _resolutionDropdown;
    public OptionsMenu(Game game) : base(game)
    {
        base.Initialize();
        
        int buttonWidth = 280;

        //_scene.SceneTextureData.Add(HopMedvedekConstants.HOP_MEDVEDEK_MENU_ELEMENTS, Game.Content.Load<Texture2D>(HopMedvedekConstants.HOP_MEDVEDEK_MENU_ELEMENTS));


        

        _gameVolumeLabel = new Label(_luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_OPTIONS_GAME_VOLUME_LABEL][Options.Options.Current.Language], new Vector2(20, 120));
        _gameVolumeLabel.Scale = new Vector2(0.8f, 0.8f);

        //Rectangle volumeSliderRectangle = new Rectangle((int)_gameVolumeLabel.Position.X, (int)_gameVolumeLabel.Position.Y, 480, 30);
        _gameVolumeSlider = new Slider(
            new Rectangle((int)_gameVolumeLabel.Position.X, (int)_gameVolumeLabel.Position.Y + 50, 280, 15),
            new Vector2(30, 35),
            new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_MENU_ELEMENTS, new Rectangle(0, 0, 480, 30), new Vector2(240, 15)),
            new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_MENU_ELEMENTS, new Rectangle(358, 84, 24, 32), new Vector2(12, 16)),
            _luckiestGuy,
            Options.Options.Current.GameVolume
            );

        _musicVolumeLabel = new Label(_luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_OPTIONS_MUSIC_VOLUME_LABEL][Options.Options.Current.Language], new Vector2(20, 220));
        _musicVolumeLabel.Scale = new Vector2(0.8f, 0.8f);

        _musicVolumeSlider = new Slider(
            new Rectangle((int)_musicVolumeLabel.Position.X, (int)_musicVolumeLabel.Position.Y + 50, 280, 15),
            new Vector2(30, 35),
            new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_MENU_ELEMENTS, new Rectangle(0, 0, 480, 30), new Vector2(240, 15)),
            new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_MENU_ELEMENTS, new Rectangle(358, 84, 24, 32), new Vector2(12, 16)),
            _luckiestGuy,
            Options.Options.Current.MusicVolume
            );

        _languageLabel = new Label(_luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_OPTIONS_LANGUAGE_LABEL][Options.Options.Current.Language], new Vector2(20, 320));
        _languageLabel.Scale = new Vector2(0.8f, 0.8f);
        _languageDropdown = new Dropdown(
            new Rectangle((int)_languageLabel.Position.X, (int)_languageLabel.Position.Y + 35, 180, 40),
            new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_MENU_ELEMENTS, new Rectangle(0, 84, 358, 154), new Vector2(279, 77)),
            _luckiestGuy,
            (LanguageEnum)Options.Options.Current.Language,
            new Dictionary<object, string>()
            {
                [LanguageEnum.si] = Strings.Localizations[StringKey.HOP_MEDVEDEK_OPTIONS_LANGUAGE_SLOVENIAN][Options.Options.Current.Language],
                [LanguageEnum.en] = Strings.Localizations[StringKey.HOP_MEDVEDEK_OPTIONS_LANGUAGE_ENGLISH][Options.Options.Current.Language],
            },
            _scene
            );

        

        _resolutionLabel = new Label(_luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_OPTIONS_RESOLUTION_LABEL][Options.Options.Current.Language], new Vector2(20, 420));
        _resolutionLabel.Scale = new Vector2(0.8f, 0.8f);

        Enum.TryParse("_" + Options.Options.Current.GraphicsDeviceWidth + "x" + Options.Options.Current.GraphicsDeviceHeight, out ResolutionEnum resolution);
        _resolutionDropdown = new Dropdown(
            new Rectangle((int)_resolutionLabel.Position.X, (int)_resolutionLabel.Position.Y + 35, 180, 40),
            new Sprite(HopMedvedekConstants.HOP_MEDVEDEK_MENU_ELEMENTS, new Rectangle(0, 84, 358, 154), new Vector2(279, 77)),
            _luckiestGuy,
            resolution,
            new Dictionary<object, string>()
            {
                [ResolutionEnum._408x906] = "408 x 906",
                [ResolutionEnum._720x1280] = "720 x 1280",
                [ResolutionEnum._1080x1920] = "1080 x 1920",
            },
            _scene
            );




        
        _scene.Add(_languageDropdown);
        _scene.Add(_resolutionDropdown);
        _scene.Add(_back);
        _scene.Add(_gameVolumeSlider);
        _scene.Add(_musicVolumeSlider);
        _scene.Add(_resolutionLabel);
        _scene.Add(_gameVolumeLabel);
        _scene.Add(_musicVolumeLabel);
        _scene.Add(_languageLabel);
    }
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        GameState newState = null;

        
        if (_back.WasReleased)
        {

            string resolution = ((ResolutionEnum)_resolutionDropdown.SelectedKey).ToString();
            resolution = resolution.Replace("_", "");
            string[] dimensions = resolution.Split('x');

            Options.Options.Current.GameVolume = _gameVolumeSlider.Value;
            Options.Options.Current.MusicVolume = _musicVolumeSlider.Value;
            Options.Options.Current.Language = (LanguageEnum)_languageDropdown.SelectedKey;
            Options.Options.Current.GraphicsDeviceWidth = int.Parse(dimensions[0]);
            Options.Options.Current.GraphicsDeviceHeight = int.Parse(dimensions[1]);
            Options.Options.SaveOptions();
        }

        if (newState is not null)
        {
            _hopMedvedek.PushState(newState);
        }
    }
}

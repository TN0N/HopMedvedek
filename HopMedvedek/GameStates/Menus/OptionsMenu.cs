using Microsoft.Xna.Framework;
using Artificial.Artificial.Mirage;
using HopMedvedek.Data.Strings;
namespace HopMedvedek.GameStates.Menus;

public class OptionsMenu : Menu
{
    protected Label _resolutionLabel, _gameVolumeLabel, _musicVolumeLabel, _languageLabel;
    public OptionsMenu(Game game) : base(game)
    {
        base.Initialize();
        
        int buttonWidth = 280;

        

        _resolutionLabel = new Label(_luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_OPTIONS_RESOLUTION_LABEL][Options.Options.Current.Language], new Vector2(20, 300));
        _resolutionLabel.Scale = new Vector2(0.8f, 0.8f);

        _gameVolumeLabel = new Label(_luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_OPTIONS_GAME_VOLUME_LABEL][Options.Options.Current.Language], new Vector2(20, 400));
        _gameVolumeLabel.Scale = new Vector2(0.8f, 0.8f);

        _musicVolumeLabel = new Label(_luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_OPTIONS_MUSIC_VOLUME_LABEL][Options.Options.Current.Language], new Vector2(20, 500));
        _musicVolumeLabel.Scale = new Vector2(0.8f, 0.8f);

        _languageLabel = new Label(_luckiestGuy, Strings.Localizations[StringKey.HOP_MEDVEDEK_OPTIONS_LANGUAGE_LABEL][Options.Options.Current.Language], new Vector2(20, 600));
        _languageLabel.Scale = new Vector2(0.8f, 0.8f);

        _scene.Add(_back);
        _scene.Add(_resolutionLabel);
        _scene.Add(_gameVolumeLabel);
        _scene.Add(_musicVolumeLabel);
        _scene.Add(_languageLabel);
    }
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        GameState newState = null;

        /*
        else if (_options.WasReleased)
        {
            newState = new Options(Game);
        }*/

        if (newState is not null)
        {
            _hopMedvedek.PushState(newState);
        }
    }
}

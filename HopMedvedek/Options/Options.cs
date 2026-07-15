using HopMedvedek.Data;
using HopMedvedek.Data.Strings;
using System.IO;
using System.Text.Json;

namespace HopMedvedek.Options;
/// <summary>
/// Defines all the options the user can adjust.
/// </summary>
public static class Options
{
    /// <summary>
    /// The options available.
    /// </summary>
    public sealed class OptionsData
    {
        public int GraphicsDeviceWidth { get; set; }
        public int GraphicsDeviceHeight { get; set; }
        public float GameVolume { get; set; }
        public float MusicVolume { get; set; } 
        public LanguageEnum Language { get; set; }
        public bool IsMouseVisible { get; set; }
    }
    /// <summary>
    /// The current option data.
    /// </summary>
    public static OptionsData Current { get; private set; } = new();
    /// <summary>
    /// Loads the options from the options.json.
    /// </summary>
    public static void LoadOptions()
    {
        string json = File.ReadAllText(HopMedvedekConstants.HOP_MEDVEDEK_OPTIONS_PATH);
        Current = JsonSerializer.Deserialize<OptionsData>(json) ?? new OptionsData();
    }
    /// <summary>
    /// Saves the options to options.json.
    /// </summary>
    public static void SaveOptions()
    {
        string json = JsonSerializer.Serialize(Current, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(HopMedvedekConstants.HOP_MEDVEDEK_OPTIONS_PATH, json);
    }
}
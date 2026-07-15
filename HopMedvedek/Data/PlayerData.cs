using HopMedvedek.Data;
using HopMedvedek.Data.Strings;
using System.IO;
using System.Text.Json;

namespace HopMedvedek.Data;
/// <summary>
/// Defines all the options the user can adjust.
/// </summary>
public static class PlayerData
{
    /// <summary>
    /// The options available.
    /// </summary>
    public sealed class Player
    {
        public int HighScore { get; set; }
        public int Coins { get; set; }
        public int Year01LanguageLevelCorrectAnswers { get; set; }
        public int Year01LanguageLevelWrongAnswers { get; set; }
        public int Year01MathsLevelCorrectAnswers { get; set; }
        public int Year01MathsLevelWrongAnswers { get; set; }
    }
    /// <summary>
    /// The current option data.
    /// </summary>
    public static Player Current { get; private set; } = new();
    /// <summary>
    /// Loads the options from the options.json.
    /// </summary>
    public static void LoadData()
    {
        string json = File.ReadAllText(HopMedvedekConstants.HOP_MEDVEDEK_PLAYER_DATA_PATH);
        Current = JsonSerializer.Deserialize<Player>(json) ?? new Player();
    }
    /// <summary>
    /// Saves the options to options.json.
    /// </summary>
    public static void SaveData()
    {
        string json = JsonSerializer.Serialize(Current, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(HopMedvedekConstants.HOP_MEDVEDEK_PLAYER_DATA_PATH, json);
    }
}
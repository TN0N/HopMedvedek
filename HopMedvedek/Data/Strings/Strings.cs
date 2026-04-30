using System.Collections.Generic;

namespace HopMedvedek.Data.Strings;
public enum StringKey
{
    // Common
    HOP_MEDVEDEK_COMMON_MENU_BACK,

    // Main menu
    HOP_MEDVEDEK_MAIN_MENU_PLAY,
    HOP_MEDVEDEK_MAIN_MENU_OPTIONS,

    // Options menu
    HOP_MEDVEDEK_OPTIONS_RESOLUTION_LABEL,
    HOP_MEDVEDEK_OPTIONS_GAME_VOLUME_LABEL,
    HOP_MEDVEDEK_OPTIONS_MUSIC_VOLUME_LABEL,
    HOP_MEDVEDEK_OPTIONS_LANGUAGE_LABEL,

    HOP_MEDVEDEK_OPTIONS_LANGUAGE_ENGLISH,
    HOP_MEDVEDEK_OPTIONS_LANGUAGE_SLOVENIAN,

}
public static class Strings
{
    public static Dictionary<StringKey, Dictionary<LanguageEnum, string>> Localizations = new Dictionary<StringKey, Dictionary<LanguageEnum, string>>()
    {
        [StringKey.HOP_MEDVEDEK_COMMON_MENU_BACK] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Back",
            [LanguageEnum.si] = "Nazaj",
        },
        [StringKey.HOP_MEDVEDEK_MAIN_MENU_PLAY] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Play",
            [LanguageEnum.si] = "Igraj",
        },
        [StringKey.HOP_MEDVEDEK_MAIN_MENU_OPTIONS] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Options",
            [LanguageEnum.si] = "Nastavitve",
        },
        [StringKey.HOP_MEDVEDEK_OPTIONS_RESOLUTION_LABEL] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Resolution",
            [LanguageEnum.si] = "Ločljivost",
        },
        [StringKey.HOP_MEDVEDEK_OPTIONS_GAME_VOLUME_LABEL] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Game Volume",
            [LanguageEnum.si] = "Glasnost igre",
        },
        [StringKey.HOP_MEDVEDEK_OPTIONS_MUSIC_VOLUME_LABEL] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Music Volume",
            [LanguageEnum.si] = "Glasnost glasbe",
        },
        [StringKey.HOP_MEDVEDEK_OPTIONS_LANGUAGE_LABEL] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Language",
            [LanguageEnum.si] = "Jezik",
        },
        [StringKey.HOP_MEDVEDEK_OPTIONS_LANGUAGE_ENGLISH] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "English",
            [LanguageEnum.si] = "English",
        },
        [StringKey.HOP_MEDVEDEK_OPTIONS_LANGUAGE_SLOVENIAN] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Slovenščina",
            [LanguageEnum.si] = "Slovenščina",
        },
    };
}

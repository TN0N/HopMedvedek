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

    // Year_01_Language_Question
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,

    // Year_01_Language_Answers
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MOTHER,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_FATHER,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HOUSE,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_TREE,

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
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "What is on the picture?",
            [LanguageEnum.si] = "Kaj je na sliki?",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MOTHER] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Mother",
            [LanguageEnum.si] = "Mami",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_FATHER] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Father",
            [LanguageEnum.si] = "Oče",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HOUSE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "House",
            [LanguageEnum.si] = "Hiša",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_TREE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Tree",
            [LanguageEnum.si] = "Drevo",
        },
    };
}

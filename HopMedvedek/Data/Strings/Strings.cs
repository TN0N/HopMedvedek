using System.Collections.Generic;

namespace HopMedvedek.Data.Strings;
public enum StringKey
{
    // Common
    HOP_MEDVEDEK_COMMON_MENU_BACK,

    // Main menu
    HOP_MEDVEDEK_MAIN_MENU_PLAY,
    HOP_MEDVEDEK_MAIN_MENU_OPTIONS

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
    };
}

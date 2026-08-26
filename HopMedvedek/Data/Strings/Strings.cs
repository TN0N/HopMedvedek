using System.Collections.Generic;

namespace HopMedvedek.Data.Strings;
public enum StringKey
{
    // Common
    HOP_MEDVEDEK_COMMON_MENU_BACK,

    // Main menu
    HOP_MEDVEDEK_MAIN_MENU_PLAY,
    HOP_MEDVEDEK_MAIN_MENU_SHOP,
    HOP_MEDVEDEK_MAIN_MENU_OPTIONS,

    // Options menu
    HOP_MEDVEDEK_OPTIONS_RESOLUTION_LABEL,
    HOP_MEDVEDEK_OPTIONS_GAME_VOLUME_LABEL,
    HOP_MEDVEDEK_OPTIONS_MUSIC_VOLUME_LABEL,
    HOP_MEDVEDEK_OPTIONS_LANGUAGE_LABEL,

    HOP_MEDVEDEK_OPTIONS_LANGUAGE_ENGLISH,
    HOP_MEDVEDEK_OPTIONS_LANGUAGE_SLOVENIAN,
    // Shop menu
    HOP_MEDVEDEK_SHOP_MENU_BUY,
    HOP_MEDVEDEK_SHOP_MENU_APPLY,
    HOP_MEDVEDEK_SHOP_MENU_PRICE,
    HOP_MEDVEDEK_SHOP_MENU_OWNED,

    // Skin names
    HOP_MEDVEDEK_SKIN_BEAR_BROWN,
    HOP_MEDVEDEK_SKIN_BEAR_RED,
    HOP_MEDVEDEK_SKIN_BEAR_GREEN,
    HOP_MEDVEDEK_SKIN_BEAR_BLUE,
    HOP_MEDVEDEK_SKIN_BEAR_RAINBOW,

    // Death menu
    HOP_MEDVEDEK_DEATH_MENU_SCORE,
    HOP_MEDVEDEK_DEATH_MENU_HIGH_SCORE,
    HOP_MEDVEDEK_DEATH_MENU_COINS,
    HOP_MEDVEDEK_DEATH_MENU_RESTART,
    HOP_MEDVEDEK_DEATH_MENU_RETURN_TO_MAIN_MENU,
    HOP_MEDVEDEK_DEATH_MENU_DEATH_TEXT,

    // Pause menu
    HOP_MEDVEDEK_PAUSE_MENU_CONTINUE,
    HOP_MEDVEDEK_PAUSE_MENU_OPTIONS,
    HOP_MEDVEDEK_PAUSE_MENU_RESTART,
    HOP_MEDVEDEK_PAUSE_MENU_RETURN_TO_MAIN_MENU,

    // Year Selection Menu

    HOP_MEDVEDEK_YEAR_SELECTION_MENU_YEAR_01,
    HOP_MEDVEDEK_YEAR_SELECTION_MENU_YEAR_02,
    HOP_MEDVEDEK_YEAR_SELECTION_MENU_YEAR_03,
    HOP_MEDVEDEK_YEAR_SELECTION_MENU_YEAR_04,

    // Subjects
    HOP_MEDVEDEK_SUBJECT_LANGUAGE,
    HOP_MEDVEDEK_SUBJECT_MATHS,

    // Year_01_Language_Question
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE,

    // Year_01_Language_Answers
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_APPLE,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BABY,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BALL,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BANANA,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BED,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BEE,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BIRD,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BOAT,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BOOK,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BOY,

    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BREAD,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CASTLE,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BUS,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CAKE,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CAR,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CAT,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CHAIR,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CHICKEN,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SPOON,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CLOCK,

    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_COAT,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_COW,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CUP,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_DAD,
    //HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_DESK,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_DOG,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_DOOR,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_DUCK,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_EGG,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_EYE,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_FARM,

    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_FISH,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_FLOWER,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_FOOT,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CLOWN,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_FROG,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_GAME,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_GARDEN,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_GIRL,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HAND,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HAT,

    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SOCK,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HILL,
    //HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HOME,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HORSE,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HOUSE,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_ICE_CREAM,
    //HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_JACKET,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_JUICE,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_KEY,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_KING,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_KITE,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_LEG,

    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_LION,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MAN,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MILK,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MUM,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MONKEY,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MOON,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MAGNET,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MOUSE,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_NEST,
    //HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_NIGHT,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_NOSE,

    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PARK,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PEN,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PENCIL,
    //HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PET,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PIG,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PIZZA,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PLANT,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_QUEEN,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_RABBIT,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_RAIN,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_RIVER,

    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_ROAD,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MUSHROOM,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SHEEP,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SHOE,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SHELL,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CLOUD,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SNAKE,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SNOWFLAKE,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_STAR,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SUN,

    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_TABLE,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MAP,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BEAR,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_TIGER,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_TRAIN,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_TREE,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_TRUCK,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_WATER,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_WHALE,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_WINDOW,

    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_WOMAN,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_WORM,
    //HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_YARD,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_ZEBRA,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MOUNTAIN,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_DRUM,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HEART,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CUPBOARD,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_NET,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PEACH,
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CARD,

    // Year01 maths
    HOP_MEDVEDEK_YEAR_01_MATHS_QUESTION_ADDITION,
    HOP_MEDVEDEK_YEAR_01_MATHS_QUESTION_SUBTRACTION,

}
public static class Strings
{
    public static Dictionary<StringKey, Dictionary<LanguageEnum, string>> Localizations = new Dictionary<StringKey, Dictionary<LanguageEnum, string>>()
    {
// Menu Labels
    // Common
        [StringKey.HOP_MEDVEDEK_COMMON_MENU_BACK] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "<",
            [LanguageEnum.si] = "<",
        },
    // Main Menu
        [StringKey.HOP_MEDVEDEK_MAIN_MENU_PLAY] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Play",
            [LanguageEnum.si] = "Igraj",
        },
        [StringKey.HOP_MEDVEDEK_MAIN_MENU_SHOP] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Shop",
            [LanguageEnum.si] = "Trgovina",
        },
        [StringKey.HOP_MEDVEDEK_MAIN_MENU_OPTIONS] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Options",
            [LanguageEnum.si] = "Nastavitve",
        },
    // Options
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
        // Shop
        [StringKey.HOP_MEDVEDEK_SHOP_MENU_BUY] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Buy",
            [LanguageEnum.si] = "Kupi"
        },
        [StringKey.HOP_MEDVEDEK_SHOP_MENU_APPLY] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Apply",
            [LanguageEnum.si] = "Nastavi"
        },
        [StringKey.HOP_MEDVEDEK_SHOP_MENU_PRICE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Price",
            [LanguageEnum.si] = "Cena"
        },
        [StringKey.HOP_MEDVEDEK_SHOP_MENU_OWNED] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Owned",
            [LanguageEnum.si] = "Kupljeno"
        },
        // Skin names
        [StringKey.HOP_MEDVEDEK_SKIN_BEAR_BROWN] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Brown bear",
            [LanguageEnum.si] = "Rjavi medved"
        },
        [StringKey.HOP_MEDVEDEK_SKIN_BEAR_RED] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Red bear",
            [LanguageEnum.si] = "Rdeči medved"
        },
        [StringKey.HOP_MEDVEDEK_SKIN_BEAR_GREEN] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Green bear",
            [LanguageEnum.si] = "Zeleni medved"
        },
        [StringKey.HOP_MEDVEDEK_SKIN_BEAR_BLUE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Blue bear",
            [LanguageEnum.si] = "Modri medved"
        },
        [StringKey.HOP_MEDVEDEK_SKIN_BEAR_RAINBOW] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Rainbow bear",
            [LanguageEnum.si] = "Mavrični medved"
        },

        // Death menu
        [StringKey.HOP_MEDVEDEK_DEATH_MENU_SCORE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Score: ",
            [LanguageEnum.si] = "Rezultat: "
        },
        [StringKey.HOP_MEDVEDEK_DEATH_MENU_HIGH_SCORE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "High Score: ",
            [LanguageEnum.si] = "Najboljši Rezultat: "
        },
        [StringKey.HOP_MEDVEDEK_DEATH_MENU_COINS] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Coins: ",
            [LanguageEnum.si] = "Kovanci: "
        },
        [StringKey.HOP_MEDVEDEK_DEATH_MENU_RESTART] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Restart",
            [LanguageEnum.si] = "Igraj"
        },
        [StringKey.HOP_MEDVEDEK_DEATH_MENU_RETURN_TO_MAIN_MENU] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Main Menu",
            [LanguageEnum.si] = "Glavni Meni"
        },
        [StringKey.HOP_MEDVEDEK_DEATH_MENU_DEATH_TEXT] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Game Over!",
            [LanguageEnum.si] = "Konec Igre!"
        },
        // Pause menu
        [StringKey.HOP_MEDVEDEK_PAUSE_MENU_CONTINUE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Continue",
            [LanguageEnum.si] = "Nadaljuj"
        },
        [StringKey.HOP_MEDVEDEK_PAUSE_MENU_OPTIONS] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Options",
            [LanguageEnum.si] = "Nastavitve"
        },
        [StringKey.HOP_MEDVEDEK_PAUSE_MENU_RESTART] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Restart",
            [LanguageEnum.si] = "Ponovno Začni"
        },
        [StringKey.HOP_MEDVEDEK_PAUSE_MENU_RETURN_TO_MAIN_MENU] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Main Menu",
            [LanguageEnum.si] = "Glavni Meni"
        },
        // Year selection menu
        [StringKey.HOP_MEDVEDEK_YEAR_SELECTION_MENU_YEAR_01] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Year 1",
            [LanguageEnum.si] = "1. Razred"
        },
        [StringKey.HOP_MEDVEDEK_YEAR_SELECTION_MENU_YEAR_02] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Year 2",
            [LanguageEnum.si] = "2. Razred"
        },
        [StringKey.HOP_MEDVEDEK_YEAR_SELECTION_MENU_YEAR_03] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Year 3",
            [LanguageEnum.si] = "3. Razred"
        },
        [StringKey.HOP_MEDVEDEK_YEAR_SELECTION_MENU_YEAR_04] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Year 4",
            [LanguageEnum.si] = "4. Razred"
        },
        // Subjects
        [StringKey.HOP_MEDVEDEK_SUBJECT_LANGUAGE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Language",
            [LanguageEnum.si] = "Jezik"
        },
        [StringKey.HOP_MEDVEDEK_SUBJECT_MATHS] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Mathematics",
            [LanguageEnum.si] = "Matematika"
        },
        // Level question-answer text
        // Year 01
        // Year 01 language questions
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_QUESTION_WHAT_IS_ON_THE_PICTURE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "WHAT  IS  THIS?",
            [LanguageEnum.si] = "KAJ  JE  TO?",
        },
        // Year 01 language answers
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_APPLE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "APPLE",
            [LanguageEnum.si] = "JABOLKA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BABY] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "BABY",
            [LanguageEnum.si] = "DOJENČEK",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BALL] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "BALL",
            [LanguageEnum.si] = "ŽOGA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BANANA] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "BANANA",
            [LanguageEnum.si] = "BANANA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BED] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "BED",
            [LanguageEnum.si] = "POSTELJA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BEE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "BEE",
            [LanguageEnum.si] = "ČEBELA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BIRD] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "BIRD",
            [LanguageEnum.si] = "PTICA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BOAT] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "BOAT",
            [LanguageEnum.si] = "LADJA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BOOK] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "BOOK",
            [LanguageEnum.si] = "KNJIGA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BOY] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "BOY",
            [LanguageEnum.si] = "FANT",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BREAD] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "BREAD",
            [LanguageEnum.si] = "KRUH",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CASTLE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "CASTLE",
            [LanguageEnum.si] = "GRAD",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BUS] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "BUS",
            [LanguageEnum.si] = "AVTOBUS",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CAKE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "CAKE",
            [LanguageEnum.si] = "TORTA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CAR] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "CAR",
            [LanguageEnum.si] = "AVTO",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CAT] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "CAT",
            [LanguageEnum.si] = "MAČKA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CHAIR] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "CHAIR",
            [LanguageEnum.si] = "STOL",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CHICKEN] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "CHICKEN",
            [LanguageEnum.si] = "KOKOŠ",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SPOON] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "SPOON",
            [LanguageEnum.si] = "ŽLICA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CLOCK] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "CLOCK",
            [LanguageEnum.si] = "URA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_COAT] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "COAT",
            [LanguageEnum.si] = "BUNDA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_COW] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "COW",
            [LanguageEnum.si] = "KRAVA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CUP] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "CUP",
            [LanguageEnum.si] = "KOZAREC",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_DAD] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "DAD",
            [LanguageEnum.si] = "OČE",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_DOG] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "DOG",
            [LanguageEnum.si] = "PES",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_DOOR] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "DOOR",
            [LanguageEnum.si] = "VRATA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_DUCK] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "DUCK",
            [LanguageEnum.si] = "RACA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_EGG] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "EGG",
            [LanguageEnum.si] = "JAJCE",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_EYE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "EYE",
            [LanguageEnum.si] = "OKO",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_FARM] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "FARM",
            [LanguageEnum.si] = "KMETIJA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_FISH] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "FISH",
            [LanguageEnum.si] = "RIBA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_FLOWER] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "FLOWER",
            [LanguageEnum.si] = "ROŽA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_FOOT] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "FOOT",
            [LanguageEnum.si] = "STOPALO",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CLOWN] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "CLOWN",
            [LanguageEnum.si] = "KLOVN",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_FROG] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "FROG",
            [LanguageEnum.si] = "ŽABA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_GAME] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "GAME",
            [LanguageEnum.si] = "IGRA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_GARDEN] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "GARDEN",
            [LanguageEnum.si] = "VRT",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_GIRL] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "GIRL",
            [LanguageEnum.si] = "PUNCA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HAND] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "ROKA",
            [LanguageEnum.si] = "DLAN",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HAT] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "HAT",
            [LanguageEnum.si] = "KLOBUK",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SOCK] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "SOCK",
            [LanguageEnum.si] = "NOGAVICA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HILL] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "HILL",
            [LanguageEnum.si] = "HRIB",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HORSE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "HORSE",
            [LanguageEnum.si] = "KONJ",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HOUSE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "HOUSE",
            [LanguageEnum.si] = "HIŠA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_ICE_CREAM] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "ICE CREAM",
            [LanguageEnum.si] = "SLADOLED",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_JUICE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "JUICE",
            [LanguageEnum.si] = "SOK",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_KEY] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "KEY",
            [LanguageEnum.si] = "KLJUČ",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_KING] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "KING",
            [LanguageEnum.si] = "KRAL",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_KITE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "KITE",
            [LanguageEnum.si] = "ZMAJ",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_LEG] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "LEG",
            [LanguageEnum.si] = "NOGA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_LION] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "LION",
            [LanguageEnum.si] = "LEV",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MAN] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "MAN",
            [LanguageEnum.si] = "MOŠKI",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MILK] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "MILK",
            [LanguageEnum.si] = "MLEKO",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MUM] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "MUM",
            [LanguageEnum.si] = "MAMI",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MONKEY] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "MONKEY",
            [LanguageEnum.si] = "OPICA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MOON] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "MOON",
            [LanguageEnum.si] = "LUNA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MAGNET] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "MAGNET",
            [LanguageEnum.si] = "MAGNET",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MOUSE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "MOUSE",
            [LanguageEnum.si] = "MIŠ",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_NEST] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "NEST",
            [LanguageEnum.si] = "GNEZDO",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_NOSE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "NOSE",
            [LanguageEnum.si] = "NOS",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PARK] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "PARK",
            [LanguageEnum.si] = "PARK",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PEN] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "PEN",
            [LanguageEnum.si] = "PERO",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PENCIL] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "PENCIL",
            [LanguageEnum.si] = "SVINČNIK",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PIG] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "PIG",
            [LanguageEnum.si] = "PUJS",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PIZZA] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "PIZZA",
            [LanguageEnum.si] = "PICA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PLANT] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "PLANT",
            [LanguageEnum.si] = "RASTLINA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_QUEEN] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "QUEEN",
            [LanguageEnum.si] = "KRALJICA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_RABBIT] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "RABBIT",
            [LanguageEnum.si] = "ZAJEC",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_RAIN] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "RAIN",
            [LanguageEnum.si] = "DEŽ",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_RIVER] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "RIVER",
            [LanguageEnum.si] = "REKA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_ROAD] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "ROAD",
            [LanguageEnum.si] = "CESTA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MUSHROOM] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "MUSHROOM",
            [LanguageEnum.si] = "GOBA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SHEEP] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "SHEEP",
            [LanguageEnum.si] = "OVCA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SHOE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "SHOE",
            [LanguageEnum.si] = "ČEVELJ",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SHELL] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "SHELL",
            [LanguageEnum.si] = "ŠKOLJKA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CLOUD] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "CLOUD",
            [LanguageEnum.si] = "OBLAK",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SNAKE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "SNAKE",
            [LanguageEnum.si] = "KAČA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SNOWFLAKE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "SNOWFLAKE",
            [LanguageEnum.si] = "SNEŽINKA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_STAR] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "STAR",
            [LanguageEnum.si] = "ZVEZDA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SUN] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "SUN",
            [LanguageEnum.si] = "SONCE",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_TABLE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "TABLE",
            [LanguageEnum.si] = "MIZA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MAP] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "MAP",
            [LanguageEnum.si] = "ZEMLJEVID",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BEAR] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "BEAR",
            [LanguageEnum.si] = "MEDVED",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_TIGER] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "TIGER",
            [LanguageEnum.si] = "TIGER",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_TRAIN] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "TRAIN",
            [LanguageEnum.si] = "VLAK",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_TREE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "TREE",
            [LanguageEnum.si] = "DREVO",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_TRUCK] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "TRUCK",
            [LanguageEnum.si] = "TOVORNJAK",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_WATER] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "WATER",
            [LanguageEnum.si] = "VODA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_WHALE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "WHALE",
            [LanguageEnum.si] = "KIT",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_WINDOW] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "WINDOW",
            [LanguageEnum.si] = "OKNO",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_WOMAN] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "WOMAN",
            [LanguageEnum.si] = "ŽENSKA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_WORM] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "WORM",
            [LanguageEnum.si] = "DEŽEVNICA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_ZEBRA] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "ZEBRA",
            [LanguageEnum.si] = "ZEBRA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MOUNTAIN] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "MOUNTAIN",
            [LanguageEnum.si] = "GORA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_DRUM] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "DRUM",
            [LanguageEnum.si] = "BOBEN",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HEART] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "HEART",
            [LanguageEnum.si] = "SRCE",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CUPBOARD] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "CUPBOARD",
            [LanguageEnum.si] = "OMARA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_NET] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "NET",
            [LanguageEnum.si] = "MREŽA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PEACH] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "PEACH",
            [LanguageEnum.si] = "BRESKEV",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CARD] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "CARD",
            [LanguageEnum.si] = "KARTA",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_MATHS_QUESTION_ADDITION] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "{0} + {1} = ?",
            [LanguageEnum.si] = "{0} + {1} = ?",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_MATHS_QUESTION_SUBTRACTION] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "{0} - {1} = ?",
            [LanguageEnum.si] = "{0} - {1} = ?",
        },
    };
}

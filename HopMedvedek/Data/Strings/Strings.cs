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
    HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CARD

}
public static class Strings
{
    public static Dictionary<StringKey, Dictionary<LanguageEnum, string>> Localizations = new Dictionary<StringKey, Dictionary<LanguageEnum, string>>()
    {
// Menu Labels
    // Common
        [StringKey.HOP_MEDVEDEK_COMMON_MENU_BACK] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Back",
            [LanguageEnum.si] = "Nazaj",
        },
    // Main Menu
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
            [LanguageEnum.en] = "What is on the picture?",
            [LanguageEnum.si] = "Kaj je na sliki?",
        },
        // Year 01 language answers
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_APPLE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Apple",
            [LanguageEnum.si] = "Jabolka",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BABY] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Baby",
            [LanguageEnum.si] = "Dojenček",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BALL] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Ball",
            [LanguageEnum.si] = "Žoga",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BANANA] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Banana",
            [LanguageEnum.si] = "Banana",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BED] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Bed",
            [LanguageEnum.si] = "Postelja",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BEE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Bee",
            [LanguageEnum.si] = "Čebela",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BIRD] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Bird",
            [LanguageEnum.si] = "Ptica",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BOAT] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Boat",
            [LanguageEnum.si] = "Ladja",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BOOK] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Book",
            [LanguageEnum.si] = "Knjiga",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BOY] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Boy",
            [LanguageEnum.si] = "Fant",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BREAD] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Bread",
            [LanguageEnum.si] = "Kruh",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CASTLE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Castle",
            [LanguageEnum.si] = "Grad",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BUS] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Bus",
            [LanguageEnum.si] = "Avtobus",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CAKE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Cake",
            [LanguageEnum.si] = "Torta",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CAR] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Car",
            [LanguageEnum.si] = "Avto",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CAT] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Cat",
            [LanguageEnum.si] = "Mačka",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CHAIR] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Chair",
            [LanguageEnum.si] = "Stol",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CHICKEN] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Chicken",
            [LanguageEnum.si] = "Kokoš",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SPOON] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Spoon",
            [LanguageEnum.si] = "Žlica",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CLOCK] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Clock",
            [LanguageEnum.si] = "Ura",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_COAT] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Coat",
            [LanguageEnum.si] = "Bunda",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_COW] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Cow",
            [LanguageEnum.si] = "Krava",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CUP] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Cup",
            [LanguageEnum.si] = "Kozarec",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_DAD] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Dad",
            [LanguageEnum.si] = "Oče",
        },
       /* [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_DESK] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "",
            [LanguageEnum.si] = "Banana",
        },*/
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_DOG] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Dog",
            [LanguageEnum.si] = "Pes",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_DOOR] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Door",
            [LanguageEnum.si] = "Vrata",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_DUCK] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Duck",
            [LanguageEnum.si] = "Raca",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_EGG] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Egg",
            [LanguageEnum.si] = "Jajce",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_EYE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Eye",
            [LanguageEnum.si] = "Uč",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_FARM] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Farm",
            [LanguageEnum.si] = "Kmetija",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_FISH] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Fish",
            [LanguageEnum.si] = "Riba",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_FLOWER] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Flower",
            [LanguageEnum.si] = "Roža",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_FOOT] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Foot",
            [LanguageEnum.si] = "Stopalo",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CLOWN] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Clown",
            [LanguageEnum.si] = "Klovn",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_FROG] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Frog",
            [LanguageEnum.si] = "Žaba",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_GAME] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Game",
            [LanguageEnum.si] = "Igra",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_GARDEN] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Garden",
            [LanguageEnum.si] = "Vrt",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_GIRL] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Girl",
            [LanguageEnum.si] = "Punca",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HAND] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Roka",
            [LanguageEnum.si] = "Dlan",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HAT] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Hat",
            [LanguageEnum.si] = "Klobuk",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SOCK] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Sock",
            [LanguageEnum.si] = "Nogavica",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HILL] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Hill",
            [LanguageEnum.si] = "Hrib",
        },
        /*[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HOME] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Home",
            [LanguageEnum.si] = "Dom",
        },*/
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HORSE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Horse",
            [LanguageEnum.si] = "Konj",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HOUSE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "House",
            [LanguageEnum.si] = "Hiša",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_ICE_CREAM] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Ice cream",
            [LanguageEnum.si] = "Sladoled",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_JUICE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Juice",
            [LanguageEnum.si] = "Sok",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_KEY] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Key",
            [LanguageEnum.si] = "Ključ",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_KING] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "King",
            [LanguageEnum.si] = "Kral",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_KITE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Kite",
            [LanguageEnum.si] = "Zmaj",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_LEG] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Leg",
            [LanguageEnum.si] = "Noga",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_LION] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Lion",
            [LanguageEnum.si] = "Lev",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MAN] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Man",
            [LanguageEnum.si] = "Moški",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MILK] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Milk",
            [LanguageEnum.si] = "Mleko",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MUM] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Mum",
            [LanguageEnum.si] = "Mami",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MONKEY] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Monkey",
            [LanguageEnum.si] = "Opica",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MOON] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Moon",
            [LanguageEnum.si] = "Luna",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MAGNET] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Magnet",
            [LanguageEnum.si] = "Magnet",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MOUSE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Mouse",
            [LanguageEnum.si] = "Miš",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_NEST] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Nest",
            [LanguageEnum.si] = "Gnezdo",
        },
        /*[StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_NIGHT] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Night",
            [LanguageEnum.si] = "Noč",
        },*/
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_NOSE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Nose",
            [LanguageEnum.si] = "Nos",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PARK] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Park",
            [LanguageEnum.si] = "Park",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PEN] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Pen",
            [LanguageEnum.si] = "Pero",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PENCIL] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Pencil",
            [LanguageEnum.si] = "Svinčnik",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PIG] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Pig",
            [LanguageEnum.si] = "Pujs",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PIZZA] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Pizza",
            [LanguageEnum.si] = "Pica",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PLANT] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Plant",
            [LanguageEnum.si] = "Rastlina",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_QUEEN] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Queen",
            [LanguageEnum.si] = "Kraljica",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_RABBIT] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Rabbit",
            [LanguageEnum.si] = "Zajec",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_RAIN] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Rain",
            [LanguageEnum.si] = "Dež",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_RIVER] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "River",
            [LanguageEnum.si] = "Reka",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_ROAD] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Road",
            [LanguageEnum.si] = "Cesta",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MUSHROOM] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Mushroom",
            [LanguageEnum.si] = "Goba",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SHEEP] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Sheep",
            [LanguageEnum.si] = "Ovca",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SHOE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Shoe",
            [LanguageEnum.si] = "Čevelj",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SHELL] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Shell",
            [LanguageEnum.si] = "Školka",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CLOUD] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Cloud",
            [LanguageEnum.si] = "Oblak",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SNAKE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Snake",
            [LanguageEnum.si] = "Kača",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SNOWFLAKE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Snowflake",
            [LanguageEnum.si] = "Snežinka",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_STAR] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Star",
            [LanguageEnum.si] = "Zvezda",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_SUN] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Sun",
            [LanguageEnum.si] = "Sonce",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_TABLE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Table",
            [LanguageEnum.si] = "Miza",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MAP] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Map",
            [LanguageEnum.si] = "Zemljevid",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_BEAR] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Bear",
            [LanguageEnum.si] = "Medved",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_TIGER] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Tiger",
            [LanguageEnum.si] = "Tiger",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_TRAIN] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Train",
            [LanguageEnum.si] = "Vlak",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_TREE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Tree",
            [LanguageEnum.si] = "Drevo",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_TRUCK] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Truck",
            [LanguageEnum.si] = "Tovornjak",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_WATER] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Water",
            [LanguageEnum.si] = "Voda",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_WHALE] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Whale",
            [LanguageEnum.si] = "kit",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_WINDOW] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Window",
            [LanguageEnum.si] = "Okno",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_WOMAN] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Woman",
            [LanguageEnum.si] = "Ženska",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_WORM] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Worm",
            [LanguageEnum.si] = "Deževnica",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_ZEBRA] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Zebra",
            [LanguageEnum.si] = "Zebra",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_MOUNTAIN] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Mountain",
            [LanguageEnum.si] = "Gora",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_DRUM] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Drum",
            [LanguageEnum.si] = "Boben",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_HEART] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Heart",
            [LanguageEnum.si] = "Srce",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CUPBOARD] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Cupboard",
            [LanguageEnum.si] = "Omara",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_NET] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Net",
            [LanguageEnum.si] = "Mreža",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_PEACH] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Peach",
            [LanguageEnum.si] = "Breskev",
        },
        [StringKey.HOP_MEDVEDEK_YEAR_01_LANGUAGE_ANSWER_CARD] = new Dictionary<LanguageEnum, string>()
        {
            [LanguageEnum.en] = "Card",
            [LanguageEnum.si] = "Karta",
        },
    };
}

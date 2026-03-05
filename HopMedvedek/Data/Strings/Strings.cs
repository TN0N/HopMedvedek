using System.Collections.Generic;

namespace HopMedvedek.Data.Strings;
public enum StringEnum
{ 
    test_string_0,
}
public static class Strings
{
    public static Dictionary<StringEnum, Dictionary<LanguageEnum, string>> _strings = new Dictionary<StringEnum, Dictionary<LanguageEnum, string>>();
}

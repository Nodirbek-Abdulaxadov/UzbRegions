namespace UzbRegions.Models;

public enum Language
{
    uz,
    oz,
    en,
    ru
}

public static class LanguageExtensions
{
    public static Language ToLanguage(this string language)
        => language switch
        {
            "uz" => Language.uz,
            "oz" => Language.oz,
            "en" => Language.en,
            "ru" => Language.ru,
            _ => Language.uz
        };
}
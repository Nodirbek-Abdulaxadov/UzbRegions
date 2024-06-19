namespace UzbRegions.Models;

public class District
{
    public int Id { get; set; }
    public string Name_Uz { get; set; } = string.Empty;
    public string Name_Oz { get; set; } = string.Empty;
    public string Name_En { get; set; } = string.Empty;
    public string Name_Ru { get; set; } = string.Empty;
}

public static class DistrictExtensions
{
    public static object GetByLanguage(this List<District> districts, Language language)
        => districts.Select(district =>
            new
            {
                district.Id,
                Name = language switch
                {
                    Language.uz => district.Name_Uz,
                    Language.oz => district.Name_Oz,
                    Language.en => district.Name_En,
                    Language.ru => district.Name_Ru,
                    _ => district.Name_Uz,
                }
            }
        );
}
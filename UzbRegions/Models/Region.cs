namespace UzbRegions.Models;

public class Region
{
    public int Id { get; set; }
    public string Name_Uz { get; set; } = string.Empty;
    public string Name_Oz { get; set; } = string.Empty;
    public string Name_En { get; set; } = string.Empty;
    public string Name_Ru { get; set; } = string.Empty;
    public List<District> Districts { get; set; } = [];
}

public static class RegionExtensions
{
    public static object GetByLanguage(this List<Region> regions, Language language)
        => regions.Select(region =>
            new
            {
                region.Id,
                Name = language switch
                {
                    Language.uz => region.Name_Uz,
                    Language.oz => region.Name_Oz,
                    Language.en => region.Name_En,
                    Language.ru => region.Name_Ru,
                    _ => region.Name_Uz,
                },
                Districts = region.Districts.GetByLanguage(language)
            }
        );
    
    public static object GetSingleByLanguage(this List<Region> regions, Language language)
        => regions.Select(region =>
            new
            {
                region.Id,
                Name = language switch
                {
                    Language.uz => region.Name_Uz,
                    Language.oz => region.Name_Oz,
                    Language.en => region.Name_En,
                    Language.ru => region.Name_Ru,
                    _ => region.Name_Uz,
                }
            }
        );
}
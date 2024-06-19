namespace UzbRegions.Controllers;

[ApiController]
public class RegionsController : ControllerBase
{
    private static List<Region> Regions;

    static RegionsController()
    {
        Regions = JsonConvert.DeserializeObject<List<Region>>(System.IO.File.ReadAllText("regions.json")) ?? [];
    }

    [HttpGet("api/regions/all")]
    [OutputCache(Duration = 86_400_000)]
    [ResponseCache(Duration = 86_400_000)]
    public IActionResult Get()
    {
        return Ok(Regions);
    }

    [HttpGet("api/regions/all/{lang}")]
    [OutputCache(Duration = 86_400_000)]
    [ResponseCache(Duration = 86_400_000)]
    public IActionResult Get(string lang)
    {
        return Ok(Regions.GetByLanguage(lang.ToLanguage()));
    }
}
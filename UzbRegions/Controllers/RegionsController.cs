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
    public IActionResult GetAll()
    {
        return Ok(Regions);
    }

    [HttpGet("api/regions")]
    [OutputCache(Duration = 86_400_000)]
    [ResponseCache(Duration = 86_400_000)]
    public IActionResult GetOnlyRegions()
    {
        return Ok(Regions.Select(x => new
        {
            x.Id,
            x.Name_Uz,
            x.Name_Oz,
            x.Name_En,
            x.Name_Ru
        }));
    }

    [HttpGet("api/regions/{lang}")]
    [OutputCache(Duration = 86_400_000)]
    [ResponseCache(Duration = 86_400_000)]
    public IActionResult GetOnlyRegionsByLanguage(string lang)
    {
        return Ok(Regions.GetSingleByLanguage(lang.ToLanguage()));
    }

    [HttpGet("api/regions/all/{lang}")]
    [OutputCache(Duration = 86_400_000)]
    [ResponseCache(Duration = 86_400_000)]
    public IActionResult GetAllByLanguage(string lang)
    {
        return Ok(Regions.GetByLanguage(lang.ToLanguage()));
    }

    [HttpGet("api/districts")]
    [OutputCache(Duration = 86_400_000)]
    [ResponseCache(Duration = 86_400_000)]
    public IActionResult GetDistrictByLanguage([FromQuery] DistrictQueryParams districtQueryParams)
    {
        var region = Regions.FirstOrDefault(r => r.Id == districtQueryParams.region_id);
        if (region == null)
        {
            return NotFound();
        }

        return Ok(region.Districts.GetByLanguage(districtQueryParams.lang.ToLanguage()));
    }
}
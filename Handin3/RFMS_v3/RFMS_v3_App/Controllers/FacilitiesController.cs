using Microsoft.AspNetCore.Mvc;
using RFMS_v3_App.Models;
using RFMS_v3_App.Models.Dto;
using RFMS_v3_App.Services;

namespace RFMS_v3_App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FacilitiesController : ControllerBase
{

    private readonly FacilityDbService _facilityDbService;

    public FacilitiesController(FacilityDbService facilityDbService)
    {
        _facilityDbService = facilityDbService;
    }

    [HttpGet("GPSAndName/")]
    public async Task<ActionResult<List<FacilityGPSNameAndKindDto>>> GetAvailableFacilitiesGPSAndName()
    {
        return Ok(await _facilityDbService.GetAvailableFacilitiesGPSAndNameAsync());
    }

    [HttpGet("GPSAndName/OrderBy/Kind/")]
    public async Task<ActionResult<List<Facility>>> GetFacilitiesGPSAndNameOrderedByKind()
    {
        return Ok(await _facilityDbService.GetFacilitiesOrderByKindAsync());
    }

    [HttpGet]
    public async Task<ActionResult<List<Facility>>> Get()
    {
        var citizens = await _facilityDbService.GetAsync();

        return Ok(citizens);
    }

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Facility>> Get(string id)
    {
        var citizen = await _facilityDbService.GetAsync(id);

        if (citizen == null)
        {
            return NotFound();
        }

        return Ok(citizen);
    }

    [HttpPost]
    public async Task<ActionResult<FacilityNoIdDto>> Post([FromBody] FacilityNoIdDto facility)
    {
        await _facilityDbService.CreateAsync(facility);
        return Ok(facility);
    }


    [HttpDelete("{id:length(24)}")]
    public async Task<ActionResult> Delete(string id)
    {
        var citizen = await _facilityDbService.GetAsync(id);

        if (citizen == null)
        {
            return NotFound();
        }

        await _facilityDbService.RemoveAsync(id);

        return NoContent();
    }


}

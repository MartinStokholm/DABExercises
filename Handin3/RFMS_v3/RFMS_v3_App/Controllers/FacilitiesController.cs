using Microsoft.AspNetCore.Mvc;
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
    public async Task<ActionResult<List<FacilityGPSAndNameDto>>> GetAvailableFacilitiesGPSAndName()
    {
        return Ok();
    }

    [HttpGet("GPSAndName/OrderBy/Kind/")]
    public async Task<ActionResult<List<FacilityGPSAndNameDto>>> GetFacilitiesGPSAndNameOrderedByKind()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult<FacilityAddressAndNameDto>> Post([FromBody] FacilityAddressAndNameDto facility)
    {
        await _facilityDbService.CreateAsync(facility);
        return Ok(facility);
        //return CreatedAtAction(nameof(Get), new { id = facility.Id }, facility);
    }


}

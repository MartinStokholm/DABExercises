using Microsoft.AspNetCore.Mvc;
using RFMS_v3_App.Models.Dto;
namespace RFMS_v3_App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FacilitiesController : ControllerBase
{
    public FacilitiesController()
    {
        
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


}

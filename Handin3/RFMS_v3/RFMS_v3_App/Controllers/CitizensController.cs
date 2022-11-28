using Microsoft.AspNetCore.Mvc;
using RFMS_v3_App.Models.Dto;
using RFMS_v3_App.Services;

namespace RFMS_v2_app.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CitizensController : ControllerBase
{
    private readonly CitizenDbService _citizenDbService;
    public CitizensController(CitizenDbService citizenDbService)
    {
        _citizenDbService = citizenDbService;
    }
    [HttpGet]
    public async Task<ActionResult<List<CitizenNoBookingsDto>>> GetCitizens()
    {
        return Ok();
    }
}

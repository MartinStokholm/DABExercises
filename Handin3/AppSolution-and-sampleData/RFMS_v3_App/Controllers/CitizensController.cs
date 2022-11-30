using Microsoft.AspNetCore.Mvc;
using RFMS_v3_App.Models;
using RFMS_v3_App.Models.Dto;
using RFMS_v3_App.Services;
using Citizen = RFMS_v3_App.Models.Citizen;

namespace RFMS_v3_App.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CitizensController : ControllerBase
{
    private readonly CitizenDbService _citizenDbService;

    public CitizensController(CitizenDbService citizenDbService)
    {
        _citizenDbService = citizenDbService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CitizenNoIdDto>>> Get()
    {
        var citizens = await _citizenDbService.GetAsync();

        return Ok(citizens);
    }

    [HttpPost("CreateOne")]
    public async Task<ActionResult<CitizenNoIdDto>> Post([FromBody] CitizenNoIdDto citizen)
    {
        await _citizenDbService.CreateAsync(citizen);
        return Ok(citizen);
    }
}

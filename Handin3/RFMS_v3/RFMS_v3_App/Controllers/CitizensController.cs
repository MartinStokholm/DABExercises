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
    public async Task<ActionResult<List<CitizenNoBookingsDto>>> Get()
    {
        var citizens = await _citizenDbService.GetAsync();

        return Ok(citizens);
    }

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<CitizenNoBookingsDto>> Get(string id)
    {
        var citizen = await _citizenDbService.GetAsync(id);

        if (citizen == null)
        {
            return NotFound();
        }

        return Ok(citizen);
    }

    [HttpPost]
    public async Task<ActionResult<CitizenNoBookingsDto>> Post([FromBody] CitizenNoBookingsDto citizen)
    {
        await _citizenDbService.CreateAsync(citizen);
        //return Ok(citizen);
        return CreatedAtAction(nameof(Get), new { id = citizen.Id }, citizen);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<ActionResult> PutCPR(string id, CitizenCPRDto updateCitizen)
    {
        var citizen = await _citizenDbService.GetAsync(id);

        if (citizen == null)
        {
            return NotFound();
        }
        citizen.CPR = updateCitizen.CPR;

        await _citizenDbService.UpdateAsync(id, citizen);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<ActionResult> Delete(string id)
    {
        var citizen = await _citizenDbService.GetAsync(id);

        if (citizen == null)
        {
            return NotFound();
        }

        await _citizenDbService.RemoveAsync(id);

        return NoContent();
    }
}

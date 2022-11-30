using Microsoft.AspNetCore.Mvc;
using RFMS_v3_App.Models;
using RFMS_v3_App.Models.Dto;
using RFMS_v3_App.Services;

namespace RFMS_v3_App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MaintenanceInterventionsController : ControllerBase
{
    private readonly MaintainceInterventionDbService _maintainceInterventionDbService;
 
    public MaintenanceInterventionsController(MaintainceInterventionDbService maintainceInterventionDbService)
    {
        _maintainceInterventionDbService = maintainceInterventionDbService;
    }

    [HttpGet("History")]
    public async Task<ActionResult<List<MaintenanceIntervention>>> GetMaintenanceHistory()
    {
        var result = await _maintainceInterventionDbService.GetHistoryAsync();
        return Ok(result);
    }
    
    [HttpPost("CreateOne")]
    public async Task<ActionResult<MaintenanceInterventionCreateDto>> Post([FromBody] MaintenanceInterventionCreateDto maintenanceIntervention)
    {
        await _maintainceInterventionDbService.CreateAsync(maintenanceIntervention);
        return Accepted(maintenanceIntervention);
    }
}

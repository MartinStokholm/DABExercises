using Microsoft.AspNetCore.Mvc;
using RFMS_v3_App.Models;
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
        return Ok();
    }
}

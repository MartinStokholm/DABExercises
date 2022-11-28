using Microsoft.AspNetCore.Mvc;
using RFMS_v3_App.Models;

namespace RFMS_v3_App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MaintenanceInterventionsController : ControllerBase
{

    public MaintenanceInterventionsController()
    {
    }
    
    [HttpGet("History")]
    public async Task<ActionResult<List<MaintenanceIntervention>>> GetMaintenanceHistory()
    {
        return Ok();
    }
}

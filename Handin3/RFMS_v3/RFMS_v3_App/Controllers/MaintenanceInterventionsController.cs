using Microsoft.AspNetCore.Mvc;
using RFMS_v2_app.Models;

namespace RFMS_v2_app.Controllers
{
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
}

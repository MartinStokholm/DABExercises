using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RFMS_v2_app.Models;

namespace RFMS_v2_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceInterventionsController : ControllerBase
    {
        private readonly DataContext _context;

        public MaintenanceInterventionsController(DataContext context)
        {
            _context = context;
        }
        [HttpGet("History")]
        public async Task<ActionResult<List<MaintenanceIntervention>>> GetMaintenanceHistory()
        {
            var dbMaintenanceIntervention = await _context.MaintenanceInterventions.ToListAsync();
            if (dbMaintenanceIntervention == null) { return NotFound("No maintenance history could be found"); }
            foreach (var item in dbMaintenanceIntervention)
            {
                _context.Entry(item).Reference(i => i.Facility).Load();
        
            }
            return Ok(dbMaintenanceIntervention);
        }
    }
}

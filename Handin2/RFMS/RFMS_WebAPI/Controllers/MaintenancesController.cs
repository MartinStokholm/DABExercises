using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RFMS_WebAPI.Models;

namespace RFMS_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenancesController : ControllerBase
    {
        private readonly DataContext _context;

        public MaintenancesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("History")]
        public async Task<ActionResult<List<Maintenance>>> GetMaintenanceHistory()
        {
            var dbMaintenances = await _context.Maintenances.ToListAsync();
            if (dbMaintenances == null) { return NotFound("No maintenance history could be found"); }
            return Ok(dbMaintenances);
        }
    }
}

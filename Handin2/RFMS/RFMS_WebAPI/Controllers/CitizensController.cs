using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RFMS_WebAPI.Models;

namespace RFMS_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitizensController : ControllerBase
    {
        private readonly DataContext _context;

        public CitizensController(DataContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<CitizenNoBooking>>> GetCitizens()
        {
            var dbCitizens = await _context.Citizens.ToListAsync();
            return Ok(dbCitizens.Adapt<List<CitizenNoBooking>>());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RFMS_v2_app.Models;
using RFMS_v2_app.Models.Dto;

namespace RFMS_v2_app.Controllers
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
        public async Task<ActionResult<List<CitizenNoBookingsDto>>> GetCitizens()
        {
            var dbCitizens = await _context.Citizens.ToListAsync();
            return Ok(dbCitizens.Adapt<List<CitizenNoBookingsDto>>());
        }
    }
}

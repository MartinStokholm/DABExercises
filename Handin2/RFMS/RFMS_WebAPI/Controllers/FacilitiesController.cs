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
    public class FacilitiesController : ControllerBase
    {
        private readonly DataContext _context;

        public FacilitiesController(DataContext context)
        {
            _context = context;
        }
        
        [HttpGet("AddressAndName/Available/")]
        public async Task<ActionResult<List<FacilityAddressAndName>>> GetAvailableFacilitiesAddressAndName()
        {
            var dbFacilitiesAvailable = await _context.Facilities.Where(f => f.IsAvailable).ToListAsync();
            return Ok(dbFacilitiesAvailable.Adapt<List<FacilityAddressAndName>>());
        }
        
        [HttpGet("AddressAndName/OrderBy/Kind/")]
        public async Task<ActionResult<List<FacilityAddressAndName>>> GetFacilitiesAddressAndNameOrderedByKind()
        {
            var dbFacilitiesAvailable = await _context.Facilities.OrderBy(f => f.Kind).ToListAsync();
            return Ok(dbFacilitiesAvailable.Adapt<List<FacilityAddressAndName>>());
        }
    }
}

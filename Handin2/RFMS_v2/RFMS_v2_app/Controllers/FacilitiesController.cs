using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mapster;
using RFMS_v2_app.Models.Dto;

namespace RFMS_v2_app.Controllers
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

        [HttpGet("GPSAndName/")]
        public async Task<ActionResult<List<FacilityGPSAndNameDto>>> GetAvailableFacilitiesGPSAndName()
        {
            var dbFacilitiesAvailable = await _context.Facilities.ToListAsync();
            return Ok(dbFacilitiesAvailable.Adapt<List<FacilityGPSAndNameDto>>());
        }

        [HttpGet("GPSAndName/OrderBy/Kind/")]
        public async Task<ActionResult<List<FacilityGPSAndNameDto>>> GetFacilitiesGPSAndNameOrderedByKind()
        {
            var dbFacilitiesAvailable = await _context.Facilities.OrderBy(f => f.Kind).ToListAsync();
            return Ok(dbFacilitiesAvailable.Adapt<List<FacilityGPSAndNameDto>>());
        }


    }
}

using Microsoft.AspNetCore.Mvc;
using RFMS_v2_app.Models.Dto;

namespace RFMS_v2_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilitiesController : ControllerBase
    {
        public FacilitiesController()
        {
            
        }

        [HttpGet("GPSAndName/")]
        public async Task<ActionResult<List<FacilityGPSAndNameDto>>> GetAvailableFacilitiesGPSAndName()
        {
            return Ok();
        }

        [HttpGet("GPSAndName/OrderBy/Kind/")]
        public async Task<ActionResult<List<FacilityGPSAndNameDto>>> GetFacilitiesGPSAndNameOrderedByKind()
        {
            return Ok();
        }


    }
}

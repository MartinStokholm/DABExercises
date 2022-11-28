using Microsoft.AspNetCore.Mvc;
using RFMS_v2_app.Models.Dto;

namespace RFMS_v2_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitizensController : ControllerBase
    {

        public CitizensController()
        {
      
        }
        [HttpGet]
        public async Task<ActionResult<List<CitizenNoBookingsDto>>> GetCitizens()
        {
            return Ok();
        }
    }
}

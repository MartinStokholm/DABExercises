using Microsoft.AspNetCore.Mvc;
using RFMS_v2_app.Models.Dto;

namespace RFMS_v2_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {

        public ReservationsController()
        {
        }
        
        [HttpGet("ReservationDetails")]
        public async Task<ActionResult<List<ReservationDetailsWithGPSDto>>> GetReservations()
        {
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using RFMS_v3_App.Models.Dto;

namespace RFMS_v3_App.Controllers;

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

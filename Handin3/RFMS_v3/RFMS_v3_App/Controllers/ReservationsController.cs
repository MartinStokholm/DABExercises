using Microsoft.AspNetCore.Mvc;
using RFMS_v3_App.Models.Dto;
using RFMS_v3_App.Services;

namespace RFMS_v3_App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservationsController : ControllerBase
{
    private readonly ReservationDbService _reservationDbService;
    
    public ReservationsController(ReservationDbService reservationDbService)
    {
        _reservationDbService = reservationDbService;
    }
    
    [HttpGet("ReservationDetails")]
    public async Task<ActionResult<List<ReservationDetailsWithGPSDto>>> GetReservations()
    {
        return Ok();
    }
}

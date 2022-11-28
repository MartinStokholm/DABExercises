using Microsoft.AspNetCore.Mvc;
using RFMS_v3_App.Models.Dto;

namespace RFMS_v2_app.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingsController : ControllerBase
{        
    public BookingsController()
    {
        
    }

    [HttpGet("WithParticipantsCPR/{bookingId}")]
    public async Task<ActionResult<BookingWithCitizenCPRDto>> GetBookingParticipantsCPR(long bookingId)
    {
        return Ok();
    }
}

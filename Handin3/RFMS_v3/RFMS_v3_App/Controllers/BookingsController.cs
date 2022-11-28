using Microsoft.AspNetCore.Mvc;
using RFMS_v3_App.Models.Dto;
using RFMS_v3_App.Services;

namespace RFMS_v3_App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingsController : ControllerBase
{
    private readonly BookingDbService _bookingDbService;
    public BookingsController(BookingDbService bookingDbService)
    {
        _bookingDbService = bookingDbService;
    }

    [HttpGet("WithParticipantsCPR/{bookingId}")]
    public async Task<ActionResult<BookingWithCitizenCPRDto>> GetBookingParticipantsCPR(string bookingId)
    {
        return Ok();
    }
}

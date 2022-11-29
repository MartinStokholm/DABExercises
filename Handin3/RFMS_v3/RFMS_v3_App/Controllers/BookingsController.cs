using Microsoft.AspNetCore.Mvc;
using RFMS_v3_App.Models;
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

    [HttpGet("WithParticipantsCPR")]
    public async Task<ActionResult<List<BookingWithCitizensCPR>>> GetBookingsWithCitizensCPR()
    {
        var bookings = await _bookingDbService.GetBookingsWithCitizensCPRAsync();
        return Ok(bookings);
    }
    
    [HttpGet("Details")]
    public async Task<ActionResult<BookingDetailsDto>> GetBookingDetailsAsync()
    {
        var result = await _bookingDbService.GetBookingDetailsAsync();
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<List<Booking>>> Get()
    {
        var booking = await _bookingDbService.GetAsync();

        return Ok(booking);
    }

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Booking>> Get(string id)
    {
        var booking = await _bookingDbService.GetAsync(id);

        if (booking == null)
        {
            return NotFound();
        }

        return Ok(booking);
    }

    [HttpPost("CreateOne")]
    public async Task<ActionResult<Booking>> Post([FromBody] BookingCreateDto newBooking)
    {
        await _bookingDbService.CreateAsync(newBooking);
        return Ok(newBooking);
    }


    [HttpDelete("{id:length(24)}")]
    public async Task<ActionResult> Delete(string id)
    {
        var booking = await _bookingDbService.GetAsync(id);

        if (booking == null)
        {
            return NotFound();
        }

        await _bookingDbService.RemoveAsync(id);

        return NoContent();
    }
}

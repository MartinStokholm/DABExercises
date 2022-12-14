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
    public class BookingsController : ControllerBase
    {
        private readonly DataContext _context;

        public BookingsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("WithParticipantsCPR/{bookingId}")]
        public async Task<ActionResult<BookingWithParticipantsCPR>> GetBookingParticipantsCPR(long bookingId)
        {
            var dbBooking = await _context.Bookings.FindAsync(bookingId);
            if (dbBooking == null) { return NotFound("Booking could not be found"); }
            _context.Entry(dbBooking).Reference(b => b.Facility).Load();
            _context.Entry(dbBooking).Collection(b => b.Citizens).Load();

            var bookingWithParticipantsCPR = dbBooking.Adapt<BookingWithParticipantsCPR>();

            foreach (var citizen in dbBooking.Citizens)
            {
                var citizenCPR = new CitizenCPR
                {
                    CitizenId = citizen.Id,
                    CPR = citizen.CPR
                };
                bookingWithParticipantsCPR.CitizensCPR.Add(citizenCPR);
            }

            return Ok(bookingWithParticipantsCPR);
        }

    }
}

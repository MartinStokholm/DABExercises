using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RFMS_v2_app.Models.Dto;

namespace RFMS_v2_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly DataContext _context;

        public ReservationsController(DataContext context)
        {
            _context = context;
        }
        
        [HttpGet("ReservationDetails")]
        public async Task<ActionResult<List<ReservationDetailsWithGPSDto>>> GetReservations()
        {
            var dbReservations = await _context.Reservations.ToListAsync();

            var reservationDetailsList = new List<ReservationDetailsWithGPSDto>();

            foreach (var item in dbReservations)
            {
                await _context.Entry(item).Reference(i => i.Booking).LoadAsync();
                await _context.Entry(item).Reference(i => i.Citizen).LoadAsync();
                await _context.Entry(item.Booking).Reference(b => b.Facility).LoadAsync();

                var reservationDetails = new ReservationDetailsWithGPSDto();

                reservationDetails.FirstName = item.Citizen.FirstName;
                reservationDetails.LastName = item.Citizen.LastName;
                reservationDetails.CVR = item.Citizen.CVR;
                reservationDetails.BookingStartTime = item.Booking.BookingStartTime;
                reservationDetails.BookingEndTime = item.Booking.BookingEndTime;
                reservationDetails.Name = item.Booking.Facility.Name;
                reservationDetails.Kind = item.Booking.Facility.Kind;
                reservationDetails.Latitude = item.Booking.Facility.Latitude;
                reservationDetails.Longitude = item.Booking.Facility.Longitude;
                //reservationDetails.StreetName = item.Booking.Facility.StreetName;
                //reservationDetails.StreetNumber = item.Booking.Facility.StreetNumber;
                //reservationDetails.ZipCode = item.Booking.Facility


                reservationDetailsList.Add(reservationDetails);
            }

            return Ok(reservationDetailsList);
        }
    }
}

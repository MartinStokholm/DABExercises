using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using RFMS_WebAPI.Models;

namespace RFMS_WebAPI.Controllers
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
        public async Task<ActionResult<List<ReservationDetails>>> GetReservations()
        {
            var dbReservations = await _context.Reservations.ToListAsync();
            
            var reservationDetailsList = new List<ReservationDetails>();

            foreach (var item in dbReservations)
            {
                await _context.Entry(item).Reference(i => i.Booking).LoadAsync();
                await _context.Entry(item).Reference(i => i.Citizen).LoadAsync();
                await _context.Entry(item.Booking).Reference(b => b.Facility).LoadAsync();

                var reservationDetails = new ReservationDetails();

                reservationDetails.FirstName = item.Citizen.FirstName;
                reservationDetails.LastName = item.Citizen.LastName;
                reservationDetails.CPR = item.Citizen.CPR;
                reservationDetails.BookingStartTime = item.Booking.BookingStartTime;
                reservationDetails.BookingEndTime = item.Booking.BookingEndTime;
                reservationDetails.Name = item.Booking.Facility.Name;
                reservationDetails.Kind = item.Booking.Facility.Kind;
                reservationDetails.Latitude = item.Booking.Facility.Latitude;
                reservationDetails.Longitude = item.Booking.Facility.Longitude;
               

                reservationDetailsList.Add(reservationDetails);
            }
            
            return Ok(reservationDetailsList);
        }

    }
}

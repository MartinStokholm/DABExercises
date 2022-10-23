using System.ComponentModel.DataAnnotations.Schema;

namespace RFMS_WebAPI.Models
{
    public class Reservation
    {
        public long Id { get; set; }
        
        [ForeignKey("Id")]
        public long CitizenId { get; set; }
        public Citizen Citizen { get; set; } = new Citizen();
        
        [ForeignKey("Id")]
        public long BookingId { get; set; }
        public Booking Booking { get; set; } = new Booking();
        
    }
}

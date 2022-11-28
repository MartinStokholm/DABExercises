using System.ComponentModel.DataAnnotations.Schema;

namespace RFMS_v2_app.Models
{
    public class Booking
    {
        public long Id { get; set; }
        public DateTime BookingStartTime { get; set; }
        public DateTime BookingEndTime { get; set; }
        public int NumberOfPeople { get; set; }
        public string Notes { get; set; } = "";       
    }
}

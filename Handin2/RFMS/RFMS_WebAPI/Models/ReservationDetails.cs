using System.ComponentModel.DataAnnotations.Schema;

namespace RFMS_WebAPI.Models
{
    public class ReservationDetails
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int? CVR { get; set; }
        
        public DateTime BookingStartTime { get; set; }
        public DateTime BookingEndTime { get; set; }

        public string Name { get; set; } = "";
        public string Kind { get; set; } = "";
        public string StreetName { get; set; } = "";
        public string StreetNumber { get; set; } = "";
        public string ZipCode { get; set; } = "";
        
    }
}

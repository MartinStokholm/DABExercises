using Microsoft.Extensions.Logging.Abstractions;

namespace RFMS_WebAPI.Models
{
    public class CitizenNoBooking
    {
        public long Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Category { get; set; } = "";
        public int? CVR { get; set; }
        public long CPR { get; set; }

    }
}

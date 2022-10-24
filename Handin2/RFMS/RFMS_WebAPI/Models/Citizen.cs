using Microsoft.Extensions.Logging.Abstractions;

namespace RFMS_WebAPI.Models
{
    public class Citizen
    {
        public Citizen()
        {
            this.Bookings = new HashSet<Booking>();
        }
        public long Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Category { get; set; } = "";
        public int? CVR { get; set; }
        public long CPR { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}

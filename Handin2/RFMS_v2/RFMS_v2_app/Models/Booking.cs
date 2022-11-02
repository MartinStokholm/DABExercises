using System.ComponentModel.DataAnnotations.Schema;

namespace RFMS_v2_app.Models
{
    public class Booking
    {
        public Booking()
        {
            this.Citizens = new HashSet<Citizen>();
        }
        public long Id { get; set; }
        public DateTime BookingStartTime { get; set; }
        public DateTime BookingEndTime { get; set; }
        public int NumberOfPeople { get; set; }
        public string Notes { get; set; } = "";
        [ForeignKey("Id")]
        public long FacilityId { get; set; }
        public Facility Facility { get; set; } = new Facility();

        public virtual ICollection<Citizen> Citizens { get; set; } = new List<Citizen>();

    }
}

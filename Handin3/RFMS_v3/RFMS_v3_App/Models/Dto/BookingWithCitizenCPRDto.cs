using System.ComponentModel.DataAnnotations.Schema;

namespace RFMS_v2_app.Models.Dto
{
    public class BookingWithCitizenCPRDto
    {
        public long Id { get; set; }
        public DateTime BookingStartTime { get; set; }
        public DateTime BookingEndTime { get; set; }
        public int NumberOfPeople { get; set; }
        public string Notes { get; set; } = "";
        [ForeignKey("Id")]
        public long FacilityId { get; set; }
        public Facility Facility { get; set; } = new Facility();
        public virtual List<CitizenCPRDto> CitizensCPR { get; set; } = new List<CitizenCPRDto>();

    }
}

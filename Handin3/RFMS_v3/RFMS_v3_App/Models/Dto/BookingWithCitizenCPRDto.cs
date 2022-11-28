using System.ComponentModel.DataAnnotations.Schema;

namespace RFMS_v3_App.Models.Dto
{
    public class BookingWithCitizenCPRDto
    {
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

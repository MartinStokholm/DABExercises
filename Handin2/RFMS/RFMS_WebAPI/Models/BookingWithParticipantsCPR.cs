using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFMS_WebAPI.Models
{
    public class BookingWithParticipantsCPR
    {
  
        public long Id { get; set; }
        public DateTime BookingStartTime { get; set; } 
        public DateTime BookingEndTime { get; set; }
        public int NumberOfPeople { get; set; }
        public string Notes { get; set; } = "";
        [ForeignKey("Id")]
        public long FacilityId { get; set; }
        public Facility Facility { get; set; } = new Facility();
        public virtual List<CitizenCPR> CitizensCPR { get; set; } = new List<CitizenCPR>();
     
    }
}

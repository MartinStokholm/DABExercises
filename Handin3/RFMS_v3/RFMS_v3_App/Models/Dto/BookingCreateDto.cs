namespace RFMS_v3_App.Models.Dto
{
    public class BookingCreateDto
    {
        public string BookedByCitizenFirstName { get; set; }
        public DateTime BookingStartTime { get; set; }
        public DateTime BookingEndTime { get; set; }
        public string Notes { get; set; } = "";
        public string FacilityName { get; set; } 
        public List<string> CitizenFirstNames { get; set; }
    }
}

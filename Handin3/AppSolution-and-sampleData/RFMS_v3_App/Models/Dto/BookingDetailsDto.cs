namespace RFMS_v3_App.Models.Dto
{
    public class BookingDetailsDto
    {
        public string FacilityName { get; set; }
        public Citizen Citizen { get; set; }
        public DateTime BookingStartTime { get; set; }
        public DateTime BookingEndTime { get; set; }
    }
}

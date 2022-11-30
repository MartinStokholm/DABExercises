namespace RFMS_v3_App.Models.Dto
{
    public class BookingWithCitizensCPR
    {
        public string? Id { get; set; }
        public DateTime BookingStartTime { get; set; }
        public DateTime BookingEndTime { get; set; }
        public int NumberOfPeople { get; set; }
        public List<long> CitizensCPR { get; set; } = new List<long>();
    }
}

namespace RFMS_v2_app.Models.Dto
{
    public class ReservationDetailsWithGPSDto
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public long? CVR { get; set; }

        public DateTime BookingStartTime { get; set; }
        public DateTime BookingEndTime { get; set; }

        public string Name { get; set; } = "";
        public string Kind { get; set; } = "";

        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}

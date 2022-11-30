namespace RFMS_v3_App.Models.Dto
{
    public class FacilityGPSNameAndKindDto
    {
        public string Name { get; set; } = "";
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Kind { get; set; } = "";
    }
}

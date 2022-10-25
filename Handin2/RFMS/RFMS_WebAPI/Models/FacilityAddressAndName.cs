using Microsoft.Build.Evaluation;

namespace RFMS_WebAPI.Models
{
    public class FacilityAddressAndName
    {
        public string Name { get; set; } = "";
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsAvailable { get; set; } = true;
        
    }
}

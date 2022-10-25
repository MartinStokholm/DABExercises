using Microsoft.Build.Evaluation;

namespace RFMS_WebAPI.Models
{
    public class Facility
    {
        public long Id { get; set; }
        public string Name { get; set; } = "";
        public string Kind { get; set; } = "";
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool CanBeReserved { get; set; } = true;
        public bool IsAvailable { get; set; } = true;
        public string AvailableItems { get; set; } = "";
        public string UsageRules { get; set; } = "";
    }
}

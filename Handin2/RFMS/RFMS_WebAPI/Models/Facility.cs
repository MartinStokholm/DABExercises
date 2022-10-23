using Microsoft.Build.Evaluation;

namespace RFMS_WebAPI.Models
{
    public class Facility
    {
        public long Id { get; set; }
        public string Name { get; set; } = "";
        public string Kind { get; set; } = "";
        public string StreetName { get; set; } = "";
        public string StreetNumber { get; set; } = "";
        public string ZipCode { get; set; } = "";
        public bool CanBeReserved { get; set; } = true;
        public bool IsAvailable { get; set; } = true;
        public string AvailableItems { get; set; } = "";
        public string UsageRules { get; set; } = "";
    }
}

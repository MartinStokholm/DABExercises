using Microsoft.Build.Evaluation;

namespace RFMS_WebAPI.Models
{
    public class FacilityAddressAndName
    {
        public string Name { get; set; } = "";
        public string StreetName { get; set; } = "";
        public string StreetNumber { get; set; } = "";
        public string ZipCode { get; set; } = "";
        public bool IsAvailable { get; set; } = true;
        
    }
}

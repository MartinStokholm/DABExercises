namespace RFMS_v3_App.Models.Dto
{
    public class FacilityGPSAndNameDto
    {
        public string Name { get; set; } = "";
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
    }
}

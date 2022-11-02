namespace RFMS_v2_app.Models.Dto
{
    public class FacilityAddressAndNameDto
    {
        public string Name { get; set; } = "";
        public string StreetName { get; set; } = "";
        public int StreetNumber { get; set; }
        public int ZipCode { get; set; }
       
    }
}

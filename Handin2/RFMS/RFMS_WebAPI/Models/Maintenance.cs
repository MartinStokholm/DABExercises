namespace RFMS_WebAPI.Models
{
    public class Maintenance
    {
        public long Id { get; set; }
        public string Describtion { get; set; } = "";
        public DateTime Date { get; set; }
        public long FacilityId { get; set; }
        public Facility Facility { get; set; } = new Facility();
    }
}

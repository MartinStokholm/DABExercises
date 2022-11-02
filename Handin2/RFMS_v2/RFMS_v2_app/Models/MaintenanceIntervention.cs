namespace RFMS_v2_app.Models
{
    public class MaintenanceIntervention
    {
        public long Id { get; set; }
        public string Describtion { get; set; } = "";
        public DateTime Date { get; set; }
        public long FacilityId { get; set; }
        public Facility Facility { get; set; } = new Facility();

    }
}

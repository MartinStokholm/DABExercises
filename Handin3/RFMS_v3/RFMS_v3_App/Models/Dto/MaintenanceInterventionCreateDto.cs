namespace RFMS_v3_App.Models.Dto
{
    public class MaintenanceInterventionCreateDto
    {
        public string Description { get; set; } = "";
        public DateTime Date { get; set; }
        public string FacilityName { get; set; }
    }
}

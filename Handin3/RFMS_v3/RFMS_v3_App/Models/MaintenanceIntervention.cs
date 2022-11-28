namespace RFMS_v3_App.Models;

public class MaintenanceIntervention
{
    public string? Id { get; set; }
    public string Description { get; set; } = "";
    public DateTime Date { get; set; }
    public Facility Facility { get; set; } = new Facility();


}

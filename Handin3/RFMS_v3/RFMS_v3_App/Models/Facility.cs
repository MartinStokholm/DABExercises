namespace RFMS_v3_App.Models;

public class Facility
{
    public long Id { get; set; }
    public string Name { get; set; } = "";
    public string Kind { get; set; } = "";
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public bool CanBeReserved { get; set; } = true;
    public string Items { get; set; } = "";
    public string UsageRules { get; set; } = "";

}

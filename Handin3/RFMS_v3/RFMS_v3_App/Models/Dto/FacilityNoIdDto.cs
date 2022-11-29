namespace RFMS_v3_App.Models.Dto;

public class FacilityNoIdDto
{
    public string? Name { get; set; }
    public string? Kind { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public bool Reserved { get; set; } = true;
    public string? UsageRules { get; set; }
    public List<Item> Items { get; set; } = new List<Item>();

}

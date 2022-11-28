using System.ComponentModel.DataAnnotations.Schema;

namespace RFMS_v3_App.Models;

public class Booking
{
    public int Id { get; set; }
    public DateTime BookingStartTime { get; set; }
    public DateTime BookingEndTime { get; set; }
    public int NumberOfPeople { get; set; }
    public string Notes { get; set; } = "";

    public Facility Facility { get; set; } = new Facility();
    public Citizen Citizen { get; set; } = new Citizen();
}

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFMS_v3_App.Models;

public class Booking
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public DateTime BookingStartTime { get; set; }
    public DateTime BookingEndTime { get; set; }
    public int NumberOfPeople { get; set; }
    public string Notes { get; set; } = "";
    public Citizen Citizen { get; set; }
    public Facility Facility { get; set; } = new Facility();
    public List<long> CitizensCPR { get; set; } = new List<long>();
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace RFMS_v3_App.Models;

public class Citizen
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [BsonElement("FirstName")]
    public string FirstName { get; set; } = "";
    [BsonElement("LastName")]
    public string LastName { get; set; } = "";
    [BsonElement("Email")]
    public string Email { get; set; } = "";
    [BsonElement("PhoneNumber")]
    public string PhoneNumber { get; set; } = "";
    [BsonElement("Category")]
    public string Category { get; set; } = "";
    public long? CVR { get; set; }
    public long CPR { get; set; }
}

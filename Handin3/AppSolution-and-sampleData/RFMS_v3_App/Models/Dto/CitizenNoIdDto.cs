using MongoDB.Bson.Serialization.Attributes;

namespace RFMS_v3_App.Models.Dto
{
    public class CitizenNoIdDto
    {
        [BsonElement("FirstName")]
        public string? FirstName { get; set; }
        [BsonElement("LastName")]
        public string? LastName { get; set; }
        [BsonElement("Email")]
        public string? Email { get; set; }
        [BsonElement("PhoneNumber")]
        public string? PhoneNumber { get; set; }
        [BsonElement("Category")]
        public string? Category { get; set; }
        [BsonElement("CVR")]
        public long? CVR { get; set; }
        [BsonElement("CPR")]
        public long CPR { get; set; }
    }
}

namespace RFMS_v2_app.Models
{
    public class Citizen
    {
        public long Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Category { get; set; } = "";
        public long? CVR { get; set; }
        public long CPR { get; set; }
    }
}

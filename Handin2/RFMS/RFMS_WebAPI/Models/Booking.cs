﻿using System.ComponentModel.DataAnnotations.Schema;

namespace RFMS_WebAPI.Models
{
    public class Booking
    {
        public long Id { get; set; }
        public DateTime BookingStartTime { get; set; } 
        public DateTime BookingEndTime { get; set; }
        public string Notes { get; set; } = "";
        [ForeignKey("Id")]
        public long FacilityId { get; set; }
        public Facility Facility { get; set; } = new Facility();
        public List<CitizenBooking> ParticipantsCPR { get; set; } = new List<CitizenBooking>();
    }
}

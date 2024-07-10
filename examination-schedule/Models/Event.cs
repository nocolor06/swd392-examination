using System;
using System.Collections.Generic;

namespace examination_schedule.Models
{
    public partial class Event
    {
        public int EventId { get; set; }
        public string? DoctorId { get; set; }
        public string? PatientId { get; set; }
        public string? StaffId { get; set; }
        public int? RoomId { get; set; }
        public int TimeSlotId { get; set; }
        public DateTime Date { get; set; }
        public string? EventType { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }

        public virtual Doctor? Doctor { get; set; }
        public virtual Patient? Patient { get; set; }
        public virtual Room? Room { get; set; }
        public virtual Staff? Staff { get; set; }
        public virtual TimeSlot TimeSlot { get; set; } = null!;
    }
}

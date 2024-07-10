using System;
using System.Collections.Generic;

namespace examination_schedule.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Events = new HashSet<Event>();
        }

        public string? Username { get; set; }
        public string PatientId { get; set; } = null!;
        public string? MedicalRecord { get; set; }

        public virtual User? UsernameNavigation { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}

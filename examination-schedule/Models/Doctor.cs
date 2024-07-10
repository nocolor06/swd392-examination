using System;
using System.Collections.Generic;

namespace examination_schedule.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Events = new HashSet<Event>();
        }

        public string? Username { get; set; }
        public string DoctorId { get; set; } = null!;
        public string? License { get; set; }
        public int? DeptId { get; set; }

        public virtual Department? Dept { get; set; }
        public virtual User? UsernameNavigation { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}

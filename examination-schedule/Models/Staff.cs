using System;
using System.Collections.Generic;

namespace examination_schedule.Models
{
    public partial class Staff
    {
        public Staff()
        {
            Events = new HashSet<Event>();
        }

        public string? Username { get; set; }
        public string StaffId { get; set; } = null!;

        public virtual User? UsernameNavigation { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}

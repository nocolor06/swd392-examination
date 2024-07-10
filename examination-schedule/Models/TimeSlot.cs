using System;
using System.Collections.Generic;

namespace examination_schedule.Models
{
    public partial class TimeSlot
    {
        public TimeSlot()
        {
            Events = new HashSet<Event>();
        }

        public int Id { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}

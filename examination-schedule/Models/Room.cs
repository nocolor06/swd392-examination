using System;
using System.Collections.Generic;

namespace examination_schedule.Models
{
    public partial class Room
    {
        public Room()
        {
            Events = new HashSet<Event>();
        }

        public int RoomId { get; set; }
        public string? RoomName { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}

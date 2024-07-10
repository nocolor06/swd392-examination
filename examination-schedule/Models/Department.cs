using System;
using System.Collections.Generic;

namespace examination_schedule.Models
{
    public partial class Department
    {
        public Department()
        {
            Doctors = new HashSet<Doctor>();
        }

        public int DeptId { get; set; }
        public string? DeptName { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}

using examination_schedule.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace examination_schedule.Pages.Requests
{
    public class IndexModel : PageModel
    {
        private readonly SWD392_ClinicScheduleContext context;

        public IndexModel(SWD392_ClinicScheduleContext context)
        {
            this.context = context;
        }

        public IList<Event> Requests { get; set; } = default!;

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        public string DoctorId { get; set; }

        public void OnGet(string from, string to, string doctorId)
        {
            From = !string.IsNullOrEmpty(from) ? DateTime.Parse(from) : null;
            To = !string.IsNullOrEmpty(to) ? DateTime.Parse(to) : null;
            DoctorId = doctorId;

            Requests = context.Events
            .Include(x => x.Doctor)
            .ThenInclude(doc => doc.UsernameNavigation)
            .Include(x => x.Patient)
            .ThenInclude(pat => pat.UsernameNavigation)
            .Include(x => x.Staff)
            .ThenInclude(sta => sta.UsernameNavigation)
            .Include(x => x.TimeSlot)
            .Include(x => x.Room)
            .Where(x =>
                (From == null || x.Date > From)
                && (To == null || x.Date < To)
                && (string.IsNullOrEmpty(DoctorId) || x.DoctorId == DoctorId)
                && x.Status == "Pending"
            )
            .ToList();
        }
    }
}

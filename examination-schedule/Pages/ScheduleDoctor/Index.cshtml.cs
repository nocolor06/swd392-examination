using System.Security.Claims;
using examination_schedule.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace examination_schedule.Pages.TimeTableDoctor
{
    public class IndexModel : PageModel
    {

        private readonly SWD392_ClinicScheduleContext _context;

        public IndexModel(SWD392_ClinicScheduleContext context)
        {
            _context = context;
        }
        public IList<Event> Requests { get; set; } = default!;

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        public string DoctorId { get; set; }
        public List<SelectListItem> Doctors { get; set; }

        public IList<Event> Events { get; set; } = new List<Event>();

        public IActionResult OnGet(string? from, string? to, string? doctorId)
        {
            if(HttpContext.User.Identity == null)
            {
                return RedirectToPage("/Login/Index");
            }

            string username = HttpContext.User.Identity.Name;

            Staff staff = _context.Staff
                .Where(x => x.Username.Equals(username))
                .FirstOrDefault();

            Doctors = _context.Doctors
            .Select(d => new SelectListItem
            {
                Value = d.DoctorId.ToString(),
                Text = $"{d.UsernameNavigation.FirstName} {d.UsernameNavigation.LastName}"
            })
            .ToList();

            if (staff == null)
            {
               return RedirectToPage("/Login/Index");
            }

            /*Events = _context.Events
                    .Include(e => e.Doctor)
                    .Include(e => e.Patient)
                    .Include(e => e.Room)
                    .Include(e => e.Staff)
                    .Include(e => e.TimeSlot)
                    .Where(e => e.Status.Equals("Approved")) 
                    .ToList();*/
            From = !string.IsNullOrEmpty(from) ? DateTime.Parse(from) : null;
            To = !string.IsNullOrEmpty(to) ? DateTime.Parse(to) : null;
            DoctorId = doctorId;

            Events = _context.Events
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
                && x.Status == "Approved"
            )
            .ToList();
            return Page();
        }
    }
}

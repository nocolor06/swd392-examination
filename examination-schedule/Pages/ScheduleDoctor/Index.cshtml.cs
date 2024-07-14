using System.Security.Claims;
using examination_schedule.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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


        public IList<Event> Events { get; set; } = new List<Event>();

        public IActionResult OnGet()
        {
            if(HttpContext.User.Identity == null)
            {
                return RedirectToPage("/Login/Index");
            }

            string username = HttpContext.User.Identity.Name;

            Doctor doctor = _context.Doctors
                .Where(x => x.Username.Equals(username))
                .FirstOrDefault();

            if(doctor == null)
            {
               return RedirectToPage("/Login/Index");
            }

            Events = _context.Events
                    .Include(e => e.Doctor)
                    .Include(e => e.Patient)
                    .Include(e => e.Room)
                    .Include(e => e.Staff)
                    .Include(e => e.TimeSlot)
                    .Where(e => e.DoctorId == doctor.DoctorId && e.Status.Equals("Approved")) 
                    .ToList();
            return Page();
        }
    }
}

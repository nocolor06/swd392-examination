using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using examination_schedule.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace examination_schedule.Pages.PatientRequests
{
    public class IndexModel : PageModel
    {
        private readonly SWD392_ClinicScheduleContext _context;

        public IndexModel(SWD392_ClinicScheduleContext context)
        {
            _context = context;
        }

        public IList<Event> Events { get; set; } = new List<Event>();

        public async Task OnGetAsync()
        {
            if (_context.Events != null)
            {
                Events = await _context.Events
                    .Include(e => e.Doctor)
                    .Include(e => e.Patient)
                    .Include(e => e.Room)
                    .Include(e => e.Staff)
                    .Include(e => e.TimeSlot)
                    .Where(e => e.Patient.Username == "poPio") // Filter by patient's username
                    .ToListAsync();
            }
        }
        public async Task<IActionResult> OnPostDeleteEventAsync(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var eventToDelete = await _context.Events.FindAsync(id);

            if (eventToDelete != null)
            {
                _context.Events.Remove(eventToDelete);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

    }
}

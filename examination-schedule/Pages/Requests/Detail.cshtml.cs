using examination_schedule.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace examination_schedule.Pages.DetailRequest
{
    public class IndexModel : PageModel
    {
        private readonly SWD392_ClinicScheduleContext _context;

        public IndexModel(SWD392_ClinicScheduleContext context)
        {
            _context = context;
        }
		public Event Event { get; set; } = new Event();

        [BindProperty]
        public int EventId { get; set; }

        public IActionResult OnGet(int id)
        {

            if(id < 0)
            {
                return RedirectToPage("/Homepage/Index");
            }

            Event = _context.Events
                    .Include(e => e.Doctor)
                    .ThenInclude(e => e.UsernameNavigation)
                    .Include(e => e.Patient)
                    .ThenInclude(e => e.UsernameNavigation)
                    .Include(e => e.Room)
                    .Include(e => e.Staff)
                    .Include(e => e.TimeSlot)
                .Where(o => o.EventId == id).FirstOrDefault();

            if(Event == null)
            {
                return RedirectToPage("/Homepage/Index");
            }

            return Page();
        }

        public IActionResult OnPost(string action)
        {
            switch (action)
            {
                case "approve":
                    ApproveEvent(EventId);
                    break;

                case "reject":
                    RejectEvent(EventId);
                    break;

                default:
                    break;
            }

            return RedirectToPage("/Requests/Index");
        }

        private void ApproveEvent(int eventId)
        {
            Models.Event model = _context.Events.Where(o => o.EventId.Equals(eventId)).FirstOrDefault();
            if (model == null) return;
            model.Status = "Approved";
            _context.Update(model);
            _context.SaveChanges();
        }

        private void RejectEvent(int eventId)
        {
            Models.Event model = _context.Events.Where(o => o.EventId.Equals(eventId)).FirstOrDefault();
            if (model == null) return;
            model.Status = "Rejected";
            _context.Update(model);
            _context.SaveChanges();
        }
    }
}

using examination_schedule.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace examination_schedule.Pages.Events
{
    public class CreateModel : PageModel
    {
        private readonly SWD392_ClinicScheduleContext _context;

        public CreateModel(SWD392_ClinicScheduleContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Doctors = new SelectList(_context.Doctors, "DoctorId", "Username");
            Patients = new SelectList(_context.Patients, "PatientId", "Username");
            Staff = new SelectList(_context.Staff, "StaffId", "Username");
            Rooms = new SelectList(_context.Rooms, "RoomId", "RoomName");
            TimeSlots = new SelectList(_context.TimeSlots, "Id", "StartTime"); // Assuming StartTime represents the time slot

            return Page();
        }

        [BindProperty]
        public Event Event { get; set; }

        public SelectList Doctors { get; set; }
        public SelectList Patients { get; set; }
        public SelectList Staff { get; set; }
        public SelectList Rooms { get; set; }
        public SelectList TimeSlots { get; set; }

        /*public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Doctors = new SelectList(_context.Doctors, "DoctorId", "Username");
                Patients = new SelectList(_context.Patients, "PatientId", "Username");
                Staff = new SelectList(_context.Staff, "StaffId", "Username");
                Rooms = new SelectList(_context.Rooms, "RoomId", "RoomName");
                TimeSlots = new SelectList(_context.TimeSlots, "Id", "StartTime");
                return Page();
            }

            _context.Events.Add(Event);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }*/
        public async Task<IActionResult> OnPostAsync()
        {
            // Log các giá trị của Event trước khi kiểm tra ModelState
            Console.WriteLine($"EventId: {Event.EventId}, DoctorId: {Event.DoctorId}, PatientId: {Event.PatientId}, StaffId: {Event.StaffId}, RoomId: {Event.RoomId}, TimeSlotId: {Event.TimeSlotId}, Date: {Event.Date}, EventType: {Event.EventType}, Status: {Event.Status}, Description: {Event.Description}");

            if (!ModelState.IsValid)
            {
                Doctors = new SelectList(_context.Doctors, "DoctorId", "Username");
                Patients = new SelectList(_context.Patients, "PatientId", "Username");
                Staff = new SelectList(_context.Staff, "StaffId", "Username");
                Rooms = new SelectList(_context.Rooms, "RoomId", "RoomName");
                TimeSlots = new SelectList(_context.TimeSlots, "Id", "StartTime");

                // Log các lỗi ModelState
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        Console.WriteLine($"ModelState error in {state.Key}: {error.ErrorMessage}");
                    }
                }

                /*return Page();*/
            }

            // Thêm Event vào cơ sở dữ liệu
            _context.Events.Add(Event);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Requests/Index");
        }


    }
}

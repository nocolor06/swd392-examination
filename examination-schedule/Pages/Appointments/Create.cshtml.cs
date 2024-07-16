using examination_schedule.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace examination_schedule.Pages.Appointments
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
            Doctors = new SelectList(
                    from doctor in _context.Doctors
                    join user in _context.Users on doctor.Username equals user.Username
                    select new { doctor.DoctorId, FullName = user.FirstName + " " + user.LastName },
                    "DoctorId", "FullName");
            Patients = new SelectList(
                    from patient in _context.Patients
                    join user in _context.Users on patient.Username equals user.Username
                    select new { patient.PatientId, FullName = user.FirstName + " " + user.LastName },
                    "PatientId", "FullName");
            Staff = new SelectList(
                    from staff in _context.Staff
                    join user in _context.Users on staff.Username equals user.Username
                    select new { staff.StaffId, FullName = user.FirstName + " " + user.LastName },
                    "StaffId", "FullName");
            Rooms = new SelectList(_context.Rooms, "RoomId", "RoomName");
            /*TimeSlots = new SelectList(_context.TimeSlots, "Id", "StartTime");*/ // Assuming StartTime represents the time slot
            TimeSlots = new SelectList(
                    from staff in _context.TimeSlots
                    select new { staff.Id, TimeSlot = staff.StartTime + " - " + staff.EndTime },
                    "Id", "TimeSlot");
            Event = new Event
            {
                EventType = "Appointment",
                Status = "Appoved"
            };
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
                /*Doctors = new SelectList(_context.Doctors, "DoctorId", "Username");*/
                Doctors = new SelectList(
                    from doctor in _context.Doctors
                    join user in _context.Users on doctor.Username equals user.Username
                    select new { doctor.DoctorId, FullName = user.FirstName + " " + user.LastName },
                    "DoctorId", "FullName");
                Patients = new SelectList(
                        from patient in _context.Patients
                        join user in _context.Users on patient.Username equals user.Username
                        select new { patient.PatientId, FullName = user.FirstName + " " + user.LastName },
                        "PatientId", "FullName");
                Staff = new SelectList(
                        from staff in _context.Staff
                        join user in _context.Users on staff.Username equals user.Username
                        select new { staff.StaffId, FullName = user.FirstName + " " + user.LastName },
                        "StaffId", "FullName");
                Rooms = new SelectList(_context.Rooms, "RoomId", "RoomName");
                /*TimeSlots = new SelectList(_context.TimeSlots, "Id", "StartTime");*/ // Assuming StartTime represents the time slot
                TimeSlots = new SelectList(
                        from staff in _context.TimeSlots
                        select new { staff.Id, TimeSlot = staff.StartTime + " - " + staff.EndTime },
                        "Id", "TimeSlot");

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
            Event.EventType = "Appointment";
            Event.Status = "Approved";

            // Thêm Event vào cơ sở dữ liệu
            _context.Events.Add(Event);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Requests/Index");
        }


    }
}

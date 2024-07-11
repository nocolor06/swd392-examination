using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using examination_schedule.Models;

namespace examination_schedule.Pages.PatientRequests
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
            LoadSelectLists();
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; } = new Event();

        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid || Event == null)
            //{
            //    // Load lại các SelectList cho dropdowns và báo lỗi
            //    LoadSelectLists();
            //    ModelState.AddModelError(string.Empty, "Thêm sự kiện không thành công. Vui lòng kiểm tra lại thông tin và thử lại.");
            //    return Page();
            //}

            try
            {
                // Set default values for EventType and Status
                Event.EventType = "Appointment";
                Event.Status = "Pending";

                _context.Events.Add(Event);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi khi lưu vào cơ sở dữ liệu
                ModelState.AddModelError(string.Empty, $"Đã xảy ra lỗi khi lưu sự kiện: {ex.Message}");
                LoadSelectLists(); // Load lại các SelectList cho dropdowns
                return Page();
            }
        }

        private void LoadSelectLists()
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "Username");
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "Username");
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomName");
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "Username");

            // Adjust as per your TimeSlot model, assuming StartTime and EndTime are properties of TimeSlot
            ViewData["TimeSlotId"] = new SelectList(_context.TimeSlots.Select(ts =>
                new SelectListItem
                {
                    Value = ts.Id.ToString(),
                    Text = $"{ts.StartTime}-{ts.EndTime}"
                }), "Value", "Text");
        }
    }
}

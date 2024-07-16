using System.Net.Mail;
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

        public void OnGet(string? from, string? to, string? doctorId)
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

        public async void OnPost()
        {
            string to = "hn8319542@gmail.com";
            string subject = "This is subject";
            string body = "Appointment request approved.";
            MailMessage mm = new MailMessage();
            mm.To.Add(to);
            mm.Subject = subject;
            mm.Body = body;
            mm.IsBodyHtml = false;
            mm.From = new MailAddress("huyenntkhe170863@fpt.edu.vn");
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true,
                Credentials = new System.Net.NetworkCredential("huyenntkhe170863@fpt.edu.vn", "zhui bqes ucgy peok")
            };
            smtpClient.Send(mm);
            ViewData["msg"] = "The mail has been sent";

            OnGet("", "", "");

        }
    }
}

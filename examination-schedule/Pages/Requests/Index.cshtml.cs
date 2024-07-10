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
            context = context;
        }

        public void OnGet()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EgdeBookingSystemV2.Data;
using EgdeBookingSystemV2.Models;

namespace EgdeBookingSystemV2.Pages.MyPage
{
    public class IndexModel : PageModel
    {
        private readonly EgdeBookingSystemV2.Data.EgdeBookingSystemConnection _context;

        public IndexModel(EgdeBookingSystemV2.Data.EgdeBookingSystemConnection context)
        {
            _context = context;
        }


        public IList<Booking> ActiveBookings { get;set; }
        public IList<Booking> HistoricBookings { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (User.Identity.Name == null)
            {
                return NotFound();
            }

            ActiveBookings = await _context.Bookings
                .Include(b => b.Equipment)
                .Where(b => b.UserEmail == User.Identity.Name)
                .Where(b => b.EndDate >= DateTime.Now)
                .OrderBy(b => b.StartDate)
                .ToListAsync();

            HistoricBookings = await _context.Bookings
                .Include(b => b.Equipment)
                .Where(b => b.UserEmail == User.Identity.Name)
                .Where(b => b.EndDate < DateTime.Now)
                .OrderByDescending(b => b.StartDate)
                .ToListAsync();

            return Page();
        }
    }
}

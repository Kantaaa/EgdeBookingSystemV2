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
    public class DetailsModel : PageModel
    {
        private readonly EgdeBookingSystemV2.Data.EgdeBookingSystemConnection _context;

        public DetailsModel(EgdeBookingSystemV2.Data.EgdeBookingSystemConnection context)
        {
            _context = context;
        }

        public Booking Booking { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Booking = await _context.Bookings
                .Include(b => b.Equipment).FirstOrDefaultAsync(m => m.ID == id);

            if (Booking == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

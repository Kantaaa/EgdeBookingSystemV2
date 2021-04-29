using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EgdeBookingSystemV2.Data;
using EgdeBookingSystemV2.Models;

namespace EgdeBookingSystemV2.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly EgdeBookingSystemV2.Data.EgdeBookingSystemConnection _context;

        public IndexModel(EgdeBookingSystemV2.Data.EgdeBookingSystemConnection context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; }

        public async Task OnGetAsync()
        {
            Booking = await _context.Bookings
                .Include(b => b.Equipment).ToListAsync();
        }
    }
}

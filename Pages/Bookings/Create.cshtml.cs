using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EgdeBookingSystemV2.Data;
using EgdeBookingSystemV2.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EgdeBookingSystemV2.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly EgdeBookingSystemV2.Data.EgdeBookingSystemConnection _context;

        public CreateModel(EgdeBookingSystemV2.Data.EgdeBookingSystemConnection context)
        {
            _context = context;
        }
        [BindProperty]
        public Equipment Equipment { get; set; }
        public IList<Booking> BookingList { get; set; }
        [Required]
      //  [Remote("ValidateDates", "Validator", ErrorMessage = "Du kan ikke booke bakover i tid. Sluttdato må komme etter startdato")]
        [BindProperty]
        public DateTime EndDate { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Equipment = await _context.Equipments
                    .Include(e => e.Category)
                    .Include(e => e.Location)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.ID == id);

            if (Equipment == null)
            {
                return NotFound();
            }

            BookingList = await _context.Bookings
                .Where(b => b.EquipmentID == id)
                .Where(b => b.EndDate >= DateTime.Now)
                .OrderBy(b => b.StartDate)
                .ToListAsync();

            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; }

        public async Task<IActionResult> OnPostAsync(int? id)
        {

            BookingList = await _context.Bookings
                .Where(b => b.EquipmentID == id)
                .Where(b => b.EndDate >= DateTime.Now)
                .OrderBy(b => b.StartDate)
                .ToListAsync();

            if (Booking.StartDate > Booking.EndDate)
            {

                return Page();
            }

            if (BookingList != null)
            {

                foreach (Booking b in BookingList)
                {
                    if (b.EquipmentID == Booking.EquipmentID)
                    {
                        if (((Booking.StartDate < b.StartDate) && (Booking.EndDate <= b.StartDate)) 
                            || ((Booking.StartDate >= b.EndDate) && (Booking.EndDate > b.EndDate)))
                        {
                            continue;
                      
                        }
                        else
                        {
                            return Page();
                        }
                    }
                }
            }

            //var errors = ModelState.Values.SelectMany(v => v.Errors);

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _context.Bookings.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("/UserView/Index");
        }
    }
}

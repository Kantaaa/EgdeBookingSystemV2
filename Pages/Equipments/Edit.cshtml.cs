using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EgdeBookingSystemV2.Data;
using EgdeBookingSystemV2.Models;

namespace EgdeBookingSystemV2.Pages.Equipments
{
    public class EditModel : PageModel
    {
        private readonly EgdeBookingSystemV2.Data.EgdeBookingSystemConnection _context;

        public EditModel(EgdeBookingSystemV2.Data.EgdeBookingSystemConnection context)
        {
            _context = context;
        }

        [BindProperty]
        public Equipment Equipment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Equipment = await _context.Equipments
                .Include(e => e.Category)
                .Include(e => e.Location).FirstOrDefaultAsync(m => m.ID == id);

            if (Equipment == null)
            {
                return NotFound();
            }
           ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "Name");
           ViewData["LocationID"] = new SelectList(_context.Locations, "ID", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Equipment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentExists(Equipment.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            TempData["Referrer2"] = "Endret";
            return RedirectToPage("./Index");
        }

        private bool EquipmentExists(int id)
        {
            return _context.Equipments.Any(e => e.ID == id);
        }
    }
}

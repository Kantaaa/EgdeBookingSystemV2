using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EgdeBookingSystemV2.Data;
using EgdeBookingSystemV2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EgdeBookingSystemV2.Pages.Equipments
{
    public class IndexModel : PageModel
    {
        private readonly EgdeBookingSystemV2.Data.EgdeBookingSystemConnection _context;

        public IndexModel(EgdeBookingSystemV2.Data.EgdeBookingSystemConnection context)
        {
            _context = context;
        }


        public IList<Equipment> EquipmentSearch { get; set; }
        public IList<Equipment> Equipment { get; set; }
        public SelectList Categories { get; set; }
        public SelectList Locations { get; set; }
        public SelectList Status { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string CategoryFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string LocationFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string BookedFilter { get; set; } = null;



        public async Task OnGetAsync()
        {
            Equipment = await _context.Equipments
                .Include(e => e.Category)
                .Include(e => e.Location).ToListAsync();

            IQueryable<string> categoryQuery = from c in _context.Categories
                                               orderby c.Name
                                               select c.Name;
            Categories = new SelectList(await categoryQuery.ToListAsync());

            IQueryable<string> locationQuery = from l in _context.Locations
                                               orderby l.Name
                                               select l.Name;
            Locations = new SelectList(await locationQuery.ToListAsync());

            string[] Statuses = { "ledig", "opptatt" };
            Status = new SelectList(Statuses);


            var equipments = from n in _context.Equipments
                             select n;
            if (!string.IsNullOrEmpty(SearchString))
            {
                equipments = equipments.Where(s => s.Name.Contains(SearchString) || s.ModelNumber.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(CategoryFilter))
            {
                equipments = equipments.Where(s => s.Category.Name.Equals(CategoryFilter));
            }
            if (!string.IsNullOrEmpty(LocationFilter))
            {
                equipments = equipments.Where(s => s.Location.Name.Equals(LocationFilter));
            }

            EquipmentSearch = await equipments.ToListAsync();
        }

    }
}





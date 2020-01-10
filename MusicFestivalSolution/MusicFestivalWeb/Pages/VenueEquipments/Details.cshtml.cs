using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace MusicFestivalWeb.Pages.VenueEquipments
{
    public class DetailsModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public DetailsModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public VenueEquipment VenueEquipment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VenueEquipment = await _context.VenueEquipments
                .Include(v => v.Equipment)
                .Include(v => v.Venue).FirstOrDefaultAsync(m => m.VenueEquipmentId == id);

            if (VenueEquipment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

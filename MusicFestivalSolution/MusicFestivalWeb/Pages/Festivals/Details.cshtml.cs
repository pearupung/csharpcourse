using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace MusicFestivalWeb.Pages.Festivals
{
    public class DetailsModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public DetailsModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public Festival Festival { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Festival = await _context.Festivals
                .Include(e => e.FestivalEvents)
                .ThenInclude(e => e.OrganisedEvent)
                .ThenInclude(e => e.Venue)
                .FirstOrDefaultAsync(m => m.FestivalId == id);

            if (Festival == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

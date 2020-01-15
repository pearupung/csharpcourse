using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace MusicFestivalWeb.Pages.OrganisedEvents
{
    public class DetailsModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public DetailsModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public OrganisedEvent OrganisedEvent { get; set; }
        public int? FestivalId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? festivalid)
        {
            if (id == null)
            {
                return NotFound();
            }

            FestivalId = festivalid;
            

            OrganisedEvent = await _context.Events
                .Include(o => o.Venue)
                .Include(o => o.Sets)
                .ThenInclude(s => s.Dj)
                .FirstOrDefaultAsync(m => m.OrganisedEventId == id);

            if (OrganisedEvent == null)
            {
                return NotFound();
            }
            return Page();
        }
        
        
    }
}

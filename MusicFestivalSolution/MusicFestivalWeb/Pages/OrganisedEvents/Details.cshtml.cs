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

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrganisedEvent = await _context.Events
                .Include(o => o.Venue).FirstOrDefaultAsync(m => m.OrganisedEventId == id);

            if (OrganisedEvent == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

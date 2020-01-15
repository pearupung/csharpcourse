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
    public class IndexModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public IndexModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<OrganisedEvent>? OrganisedEvent { get;set; }
        public int? FestivalId { get; set; }

        public async Task OnGetAsync(int? festivalId)
        {
            if (festivalId.HasValue)
            {
                FestivalId = festivalId.Value;
            }

            OrganisedEvent = await _context.Events
                .Include(o => o.Venue)
                .Where(e => !festivalId.HasValue || e.FestivalEvents
                    .Any(i => i.FestivalId == festivalId))
                .ToListAsync();
        }
    }
}

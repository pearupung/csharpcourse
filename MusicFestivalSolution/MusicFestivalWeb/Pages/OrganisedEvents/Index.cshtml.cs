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

        public IList<OrganisedEvent> OrganisedEvent { get;set; }

        public async Task OnGetAsync()
        {
            OrganisedEvent = await _context.Events
                .Include(o => o.Venue).ToListAsync();
        }
    }
}

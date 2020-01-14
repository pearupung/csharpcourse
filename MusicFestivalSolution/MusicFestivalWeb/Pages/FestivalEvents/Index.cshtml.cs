using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace MusicFestivalWeb.Pages.FestivalEvents
{
    public class IndexModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public IndexModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<FestivalEvent> FestivalEvent { get;set; }

        public async Task OnGetAsync()
        {
            FestivalEvent = await _context.FestivalEvents
                .Include(f => f.Festival)
                .Include(f => f.OrganisedEvent).ToListAsync();
        }
    }
}

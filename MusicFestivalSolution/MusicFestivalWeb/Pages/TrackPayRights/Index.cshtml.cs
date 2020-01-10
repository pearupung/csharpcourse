using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace MusicFestivalWeb.Pages.TrackPayRights
{
    public class IndexModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public IndexModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<TrackPayRight> TrackPayRight { get;set; }

        public async Task OnGetAsync()
        {
            TrackPayRight = await _context.TrackPayRights
                .Include(t => t.Person)
                .Include(t => t.Track).ToListAsync();
        }
    }
}

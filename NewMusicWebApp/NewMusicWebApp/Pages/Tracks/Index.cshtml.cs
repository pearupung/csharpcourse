using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace NewMusicWebApp.Pages.Tracks
{
    public class IndexModel : PageModel
    {
        private readonly DAL.AppDbContext _context;
        public int DjId { get; set; }

        public IndexModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<Track> Track { get;set; }

        public async Task OnGetAsync(int? djId)
        {
            if (djId != null)
            {
                DjId = djId.Value;
            }
            Track = await _context.Tracks
                .Where(a => djId == null || a.TrackId == djId)
                .Include(t => t.Category).ToListAsync();
        }
    }
}

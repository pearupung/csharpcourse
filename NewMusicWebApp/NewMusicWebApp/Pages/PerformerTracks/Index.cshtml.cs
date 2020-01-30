using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace NewMusicWebApp.Pages.PerformerTracks
{
    public class IndexModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public IndexModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<PerformerTrack> PerformerTrack { get;set; }

        public async Task OnGetAsync()
        {
            PerformerTrack = await _context.PerformerTracks
                .Include(p => p.Performer)
                .Include(p => p.Track).ToListAsync();
        }
    }
}

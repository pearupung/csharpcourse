using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace NewMusicWebApp.Pages.DjTracks
{
    public class IndexModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public IndexModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<DjTrack> DjTrack { get;set; }

        public async Task OnGetAsync()
        {
            DjTrack = await _context.DjTracks
                .Include(d => d.Dj)
                .Include(d => d.Track).ToListAsync();
        }
    }
}

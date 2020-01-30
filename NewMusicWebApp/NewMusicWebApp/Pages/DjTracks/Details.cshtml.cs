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
    public class DetailsModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public DetailsModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public DjTrack DjTrack { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DjTrack = await _context.DjTracks
                .Include(d => d.Dj)
                .Include(d => d.Track).FirstOrDefaultAsync(m => m.DjTrackId == id);

            if (DjTrack == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

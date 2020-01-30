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
    public class DetailsModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public DetailsModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public PerformerTrack PerformerTrack { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PerformerTrack = await _context.PerformerTracks
                .Include(p => p.Performer)
                .Include(p => p.Track).FirstOrDefaultAsync(m => m.PerformerTrackId == id);

            if (PerformerTrack == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

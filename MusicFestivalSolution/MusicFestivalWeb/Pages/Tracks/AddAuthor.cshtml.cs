using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace MusicFestivalWeb.Pages.Tracks
{
    public class AddAuthorTrackViewModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public AddAuthorTrackViewModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public Track Track { get; set; }
        public TrackAuthor NewTrackAuthor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Track = await _context.Tracks
                .Include(e => e.TrackAuthors)
                .FirstOrDefaultAsync(m => m.TrackId == id);

            if (Track == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace NewMusicWebApp.Pages.PerformerTracks
{
    public class EditModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public EditModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["PerformerId"] = new SelectList(_context.Performers, "PerformerId", "PerformerId");
           ViewData["TrackId"] = new SelectList(_context.Tracks, "TrackId", "TrackId");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PerformerTrack).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerformerTrackExists(PerformerTrack.PerformerTrackId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PerformerTrackExists(int id)
        {
            return _context.PerformerTracks.Any(e => e.PerformerTrackId == id);
        }
    }
}

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

namespace NewMusicWebApp.Pages.DjTracks
{
    public class EditModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public EditModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["DjId"] = new SelectList(_context.Djs, "DjId", "DjId");
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

            _context.Attach(DjTrack).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DjTrackExists(DjTrack.DjTrackId))
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

        private bool DjTrackExists(int id)
        {
            return _context.DjTracks.Any(e => e.DjTrackId == id);
        }
    }
}

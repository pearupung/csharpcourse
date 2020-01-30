using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL;
using Domain;

namespace NewMusicWebApp.Pages.PerformerTracks
{
    public class CreateModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public CreateModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PerformerId"] = new SelectList(_context.Performers, "PerformerId", "PerformerId");
        ViewData["TrackId"] = new SelectList(_context.Tracks, "TrackId", "TrackId");
            return Page();
        }

        [BindProperty]
        public PerformerTrack PerformerTrack { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PerformerTracks.Add(PerformerTrack);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

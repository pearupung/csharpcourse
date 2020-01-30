using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL;
using Domain;

namespace NewMusicWebApp.Pages.DjTracks
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
        ViewData["DjId"] = new SelectList(_context.Djs, "DjId", "DjId");
        ViewData["TrackId"] = new SelectList(_context.Tracks, "TrackId", "TrackId");
            return Page();
        }

        [BindProperty]
        public DjTrack DjTrack { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DjTracks.Add(DjTrack);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

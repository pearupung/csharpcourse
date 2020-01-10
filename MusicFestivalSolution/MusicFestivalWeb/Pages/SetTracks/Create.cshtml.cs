using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL;
using Domain;

namespace MusicFestivalWeb.Pages.SetTracks
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
        ViewData["SetId"] = new SelectList(_context.Sets, "SetId", "SetId");
        ViewData["TrackId"] = new SelectList(_context.Tracks, "TrackId", "TrackId");
            return Page();
        }

        [BindProperty]
        public SetTrack SetTrack { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SetTracks.Add(SetTrack);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

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

namespace MusicFestivalWeb.Pages.TrackAuthors
{
    public class EditModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public EditModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TrackAuthor TrackAuthor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TrackAuthor = await _context.TrackAuthors
                .Include(t => t.Author)
                .Include(t => t.Track)
                .Include(t => t.TrackAuthorType).FirstOrDefaultAsync(m => m.TrackAuthorId == id);

            if (TrackAuthor == null)
            {
                return NotFound();
            }
           ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "EmailAddress");
           ViewData["TrackId"] = new SelectList(_context.Tracks, "TrackId", "TrackName");
           ViewData["TrackAuthorTypeId"] = new SelectList(_context.TrackAuthorTypes, "TrackAuthorTypeId", "TrackAuthorTypeName");
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

            _context.Attach(TrackAuthor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackAuthorExists(TrackAuthor.TrackAuthorId))
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

        private bool TrackAuthorExists(int id)
        {
            return _context.TrackAuthors.Any(e => e.TrackAuthorId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace MusicFestivalWeb.Pages.TrackAuthors
{
    public class DeleteModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public DeleteModel(DAL.AppDbContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TrackAuthor = await _context.TrackAuthors.FindAsync(id);

            if (TrackAuthor != null)
            {
                _context.TrackAuthors.Remove(TrackAuthor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

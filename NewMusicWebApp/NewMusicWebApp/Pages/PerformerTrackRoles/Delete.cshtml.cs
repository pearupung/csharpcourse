using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace NewMusicWebApp.Pages.PerformerTrackRoles
{
    public class DeleteModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public DeleteModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PerformerTrackRole PerformerTrackRole { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PerformerTrackRole = await _context.PerformerTrackRoles
                .Include(p => p.PerformerRole)
                .Include(p => p.PerformerTrack).FirstOrDefaultAsync(m => m.PerformerTrackRoleId == id);

            if (PerformerTrackRole == null)
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

            PerformerTrackRole = await _context.PerformerTrackRoles.FindAsync(id);

            if (PerformerTrackRole != null)
            {
                _context.PerformerTrackRoles.Remove(PerformerTrackRole);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

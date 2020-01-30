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

namespace NewMusicWebApp.Pages.PerformerTrackRoles
{
    public class EditModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public EditModel(DAL.AppDbContext context)
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
           ViewData["PerformerRoleId"] = new SelectList(_context.PerformerRoles, "PerformerRoleId", "PerformerRoleId");
           ViewData["PerformerTrackId"] = new SelectList(_context.PerformerTracks, "PerformerTrackId", "PerformerTrackId");
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

            _context.Attach(PerformerTrackRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerformerTrackRoleExists(PerformerTrackRole.PerformerTrackRoleId))
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

        private bool PerformerTrackRoleExists(int id)
        {
            return _context.PerformerTrackRoles.Any(e => e.PerformerTrackRoleId == id);
        }
    }
}

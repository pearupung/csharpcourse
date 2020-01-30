using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace NewMusicWebApp.Pages.PerformerRoles
{
    public class DetailsModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public DetailsModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public PerformerRole PerformerRole { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PerformerRole = await _context.PerformerRoles.FirstOrDefaultAsync(m => m.PerformerRoleId == id);

            if (PerformerRole == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

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
    public class IndexModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public IndexModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<PerformerTrackRole> PerformerTrackRole { get;set; }

        public async Task OnGetAsync()
        {
            PerformerTrackRole = await _context.PerformerTrackRoles
                .Include(p => p.PerformerRole)
                .Include(p => p.PerformerTrack).ToListAsync();
        }
    }
}

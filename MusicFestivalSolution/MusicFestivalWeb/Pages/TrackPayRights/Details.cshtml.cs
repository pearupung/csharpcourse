using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace MusicFestivalWeb.Pages.TrackPayRights
{
    public class DetailsModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public DetailsModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public TrackPayRight TrackPayRight { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TrackPayRight = await _context.TrackPayRights
                .Include(t => t.Person)
                .Include(t => t.Track).FirstOrDefaultAsync(m => m.TrackPayRightId == id);

            if (TrackPayRight == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace MusicFestivalWeb.Pages.EventSets
{
    public class DetailsModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public DetailsModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public EventSet? EventSet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EventSet = await _context.EventSets
                .Include(e => e.Dj)
                .Include(e => e.Event)
                .Include(e => e.SetTracks)
                .ThenInclude(e => e.Track)
                .FirstOrDefaultAsync(m => m.EventSetId == id);
            
            if (EventSet == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace MusicFestivalWeb.Pages.FestivalEvents
{
    public class DetailsModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public DetailsModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public FestivalEvent FestivalEvent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FestivalEvent = await _context.FestivalEvents
                .Include(f => f.Event)
                .Include(f => f.Festival).FirstOrDefaultAsync(m => m.FestivalEventId == id);

            if (FestivalEvent == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

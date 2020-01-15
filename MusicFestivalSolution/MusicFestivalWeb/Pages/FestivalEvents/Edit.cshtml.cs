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

namespace MusicFestivalWeb.Pages.FestivalEvents
{
    public class EditModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public EditModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FestivalEvent? FestivalEvent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FestivalEvent = await _context.FestivalEvents
                .Include(f => f.Festival)
                .Include(f => f.OrganisedEvent).FirstOrDefaultAsync(m => m.FestivalEventId == id);

            if (FestivalEvent == null)
            {
                return NotFound();
            }
           ViewData["FestivalId"] = new SelectList(_context.Festivals, "FestivalId", "EndTime");
           ViewData["OrganisedEventId"] = new SelectList(_context.Events, "OrganisedEventId", "CleanUpTime");
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

            _context.Attach(FestivalEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FestivalEventExists(FestivalEvent.FestivalEventId))
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

        private bool FestivalEventExists(int id)
        {
            return _context.FestivalEvents.Any(e => e.FestivalEventId == id);
        }
    }
}

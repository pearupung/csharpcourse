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

namespace MusicFestivalWeb.Pages.EventSets
{
    public class EditModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public EditModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EventSet? EventSet { get; set; }

        public SelectList PersonSelectList { get; set; }
        public SelectList EventSelectlist { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EventSet = await _context.EventSets
                .Include(e => e.Dj)
                .Include(e => e.Event).FirstOrDefaultAsync(m => m.EventSetId == id);
            EventSelectlist = new SelectList(_context.Events, nameof(OrganisedEvent.OrganisedEventId), nameof(OrganisedEvent.EventName));
            PersonSelectList = new SelectList(_context.Persons, nameof(Person.PersonId), nameof(Person.LastNameFirstNameStageName));
            if (EventSet == null)
            {
                return NotFound();
            }
           ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "EmailAddress");
           ViewData["EventId"] = new SelectList(_context.Events, "OrganisedEventId", "CleanUpTime");
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

            _context.Attach(EventSet).State = EntityState.Modified;
            PersonSelectList = new SelectList(_context.Persons, nameof(Person.PersonId), nameof(Person.LastNameFirstNameStageName));

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventSetExists(EventSet.EventSetId))
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

        private bool EventSetExists(int id)
        {
            return _context.EventSets.Any(e => e.EventSetId == id);
        }
    }
}

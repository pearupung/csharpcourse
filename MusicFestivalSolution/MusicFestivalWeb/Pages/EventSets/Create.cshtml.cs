using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL;
using Domain;

namespace MusicFestivalWeb.Pages.EventSets
{
    public class CreateModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public CreateModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "EmailAddress");
        ViewData["EventId"] = new SelectList(_context.Events, "OrganisedEventId", "CleanUpTime");
            return Page();
        }

        [BindProperty]
        public EventSet EventSet { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sets.Add(EventSet);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

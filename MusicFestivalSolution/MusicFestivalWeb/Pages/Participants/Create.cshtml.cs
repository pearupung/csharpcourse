using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL;
using Domain;

namespace MusicFestivalWeb.Pages.Participants
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
        ViewData["ParticipantTypeId"] = new SelectList(_context.ParticipantTypes, "ParticipantTypeId", "ParticipantTypeId");
        ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "PersonId");
            return Page();
        }

        [BindProperty]
        public Participant Participant { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Participants.Add(Participant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

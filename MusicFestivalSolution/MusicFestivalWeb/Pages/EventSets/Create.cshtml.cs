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
        
        

        public IActionResult OnGet(int? festivalId, int? eventId)
        {
            FestivalId = festivalId;
            EventId = eventId;
            
        PersonSelectList = new SelectList(_context.Persons, nameof(Person.PersonId), nameof(Person.LastNameFirstNameStageName));
            return Page();
        }

        [BindProperty]
        public EventSet? EventSet { get; set; }

        [BindProperty(SupportsGet = true)] public int? FestivalId { get; set; }
        [BindProperty(SupportsGet = true)] public int? EventId { get; set; }
        public SelectList? PersonSelectList { get; set; }
       
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? eventId, int? festivalId)
        {
            PersonSelectList = new SelectList(_context.Persons, nameof(Person.PersonId), nameof(Person.LastNameFirstNameStageName));

            if (!ModelState.IsValid)
            {
                return Page();
            }


            if (EventId.HasValue)
            {
                EventSet.EventId = EventId.Value;
            }
            
            PersonSelectList = new SelectList(_context.Persons, nameof(Person.PersonId), nameof(Person.LastNameFirstNameStageName));

            _context.EventSets.Add(EventSet);
            await _context.SaveChangesAsync();
            //TODO goto eventid
            return RedirectToPage("/OrganisedEvents/Details", 
                new
                {
                    id = EventId,
                    festivalid = FestivalId
                });
        }
    }
}

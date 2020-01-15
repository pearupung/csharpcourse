using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL;
using Domain;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace MusicFestivalWeb.Pages.OrganisedEvents
{
    public class CreateModel : PageModel
    {
        private readonly DAL.AppDbContext _context;
        [BindProperty] public int FestivalId { get; set; }

        public CreateModel(DAL.AppDbContext context)
        {
            _context = context;
            VenueSelectList = new SelectList(_context.Venues, "VenueId", "VenueAddress");

        }

        public IActionResult OnGet(int? id, string? eventName,
        int? ticketCount,
        int? ticketPrice,
        string? startTime,
        string? startDate,
        string? endTime,
        string? endDate,
        string? prepTime,
        string? cleanTime,
        int? venueId)
        {
            
            if (!id.HasValue)
            {
                return RedirectToPage("/Festivals/Index");
            }
            OrganisedEvent = new OrganisedEvent();
            OrganisedEvent.EventName = eventName ?? "";
            OrganisedEvent.TicketCount = ticketCount ?? 0;
            OrganisedEvent.TicketPrice = ticketPrice ?? 0;
            OrganisedEvent.StartTime = startTime ?? "";
            OrganisedEvent.StartDate = startDate ?? "";
            OrganisedEvent.EndTime = endTime ?? "";
            OrganisedEvent.EndDate = endDate ?? "";
            OrganisedEvent.PreparationTime = prepTime ?? "";
            OrganisedEvent.CleanUpTime = cleanTime ?? "";
            OrganisedEvent.VenueId = venueId ?? 1;

            FestivalId = id.Value;
            VenueSelectList = new SelectList(_context.Venues, "VenueId", "VenueAddress");
            return Page();
        }

        [BindProperty(SupportsGet = true)]
        public OrganisedEvent OrganisedEvent { get; set; }

        [BindProperty] public Venue NewVenue { get; set; }
        public SelectList VenueSelectList { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            OrganisedEvent.FestivalEvents = new List<FestivalEvent>();
            if (string.IsNullOrEmpty(OrganisedEvent.EventName) ||
                string.IsNullOrEmpty(OrganisedEvent.StartTime) ||
                string.IsNullOrEmpty(OrganisedEvent.StartDate) ||
                string.IsNullOrEmpty(OrganisedEvent.EndTime) ||
                string.IsNullOrEmpty(OrganisedEvent.EndDate) ||
                string.IsNullOrEmpty(OrganisedEvent.PreparationTime) ||
                string.IsNullOrEmpty(OrganisedEvent.CleanUpTime))
            {
                return Page();
            }

            _context.Events.Add(OrganisedEvent);
            _context.SaveChanges();
            var festivalEvent = new FestivalEvent()
            {
                FestivalId = FestivalId,
                OrganisedEventId = OrganisedEvent.OrganisedEventId
            };
            OrganisedEvent.FestivalEvents.Add(festivalEvent);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Festivals/Details", new {id = Request.Query["id"]});
        }
        
        public async Task<IActionResult> OnPostNewVenue(int? id)
        {
            if (string.IsNullOrEmpty(NewVenue.VenueName) ||
                string.IsNullOrEmpty(NewVenue.VenueAddress))
            {
                return Page();
            }
            if (!id.HasValue)
            {
                return RedirectToPage("/Festivals/Index");
            }
            FestivalId = id.Value;

            _context.Venues.Add(NewVenue);
            await _context.SaveChangesAsync();
            VenueSelectList = new SelectList(_context.Venues, 
                nameof(Venue.VenueId), 
                nameof(Venue.VenueName));

            return RedirectToPage("/OrganisedEvents/Create", 
                new
                {
                    id = FestivalId,
                    eventName = OrganisedEvent.EventName,
                    ticketCount = OrganisedEvent.TicketCount,
                    ticketPrice = OrganisedEvent.TicketPrice,
                    startTime = OrganisedEvent.StartTime,
                    startDate = OrganisedEvent.StartDate,
                    endTime = OrganisedEvent.EndTime,
                    endDate = OrganisedEvent.EndDate,
                    prepTime = OrganisedEvent.PreparationTime,
                    cleanTime = OrganisedEvent.CleanUpTime,
                    venueId = OrganisedEvent.VenueId
                });
        }
    }
}

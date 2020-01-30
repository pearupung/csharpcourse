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
        public IList<Track>? AllTracks { get; set; }

        [BindProperty] public EventSet? EventSet { get; set; }
        [BindProperty(SupportsGet = true)] public string SearchString { get; set; }
        [BindProperty(SupportsGet = true)] public int? EventId { get; set; }
        [BindProperty(SupportsGet = true)] public int? FestivalId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            AllTracks = await _context.Tracks.ToListAsync();
            EventSet = await _context.EventSets
                .Include(e => e.Dj)
                .Include(e => e.Event)
                .Include(e => e.SetTracks)
                .ThenInclude(e => e.Track)
                .FirstOrDefaultAsync(m => m.EventSetId == id);
            if (string.IsNullOrEmpty(SearchString))
            {
                return Page();
            }

            var searchStrings = SearchString.ToLower().Split(' ');

            foreach (var searchString in searchStrings)
            {
                if (searchString[0] != '!')
                {
                    AllTracks = AllTracks.Where(e => e.TrackName.ToLower().Contains((searchString))).ToList();
                }
                else
                {
                    AllTracks = AllTracks.Where(e => !e.TrackName
                            .ToLower()
                            .Contains((searchString.Substring(1))))
                        .ToList();
                }
            }

            if (EventSet == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(int? id, int? submitbutton)
        {
            if (submitbutton.HasValue)
            {
                Console.WriteLine(EventSet.EventSetId);
                var track = _context.Tracks.Find(submitbutton);
                _context.SetTracks.Add(new SetTrack()
                {
                    ActualPlayTimeInSeconds = track.LengthInSeconds,
                    EventSetId = EventSet.EventSetId,
                    TrackId = track.TrackId
                });
                _context.SaveChanges();
            }

            return RedirectToPage("/EventSets/Details", new
            {
                id = EventSet.EventSetId
            });

        }
    }
}

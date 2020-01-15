using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace MusicFestivalWeb.Pages.Tracks
{
    public class IndexModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public IndexModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<Track>? Track { get;set; }
        public IList<Track>? AllTracks { get; set; }
        [BindProperty(SupportsGet = true)] public string? SearchString { get; set; }
        [BindProperty(SupportsGet = true)] public int? EventId { get; set; }
        [BindProperty(SupportsGet = true)] public int? FestivalId { get; set; }

        public async Task OnGetAsync(int? eventid)
        {
            Track = await _context.Tracks
                .Where(e => e.SetTracks.Any(r => r.EventSet.EventId == eventid))
                .ToListAsync();

            AllTracks = await _context.Tracks.ToListAsync();
            if (string.IsNullOrEmpty(SearchString))
            {
                return;
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
        }
    }
}

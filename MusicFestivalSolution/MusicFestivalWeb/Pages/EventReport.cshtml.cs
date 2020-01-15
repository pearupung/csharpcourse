using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace MusicFestivalWeb
{
    public class EventReport : PageModel
    {
        private DAL.AppDbContext _context;
        [BindProperty(SupportsGet = true)] public int? EventId { get; set; }

        public EventReport(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            SetTrack = _context.SetTracks
                .Include(e => e.EventSet)
                .Where(e => e.EventSet.EventId == EventId.Value)
                .ToList();
            Tracks = _context.Tracks
                .Include(e => e.SetTracks)
                .ThenInclude(e => e.EventSet)
                .Include(e => e.TrackAuthors)
                .ThenInclude(e => e.Author)
                .Include(e => e.TrackAuthors)
                .ThenInclude(e => e.TrackAuthorType)
                .Where(e => e.SetTracks.Any(r => r.EventSet.EventId == EventId))
                .ToList();
            OrganisedEvent = _context.Events.Find(EventId);
        }

        public IList<SetTrack> SetTrack { get; set; }
        public IList<Track> Tracks { get; set; }
        public OrganisedEvent OrganisedEvent { get; set; }
    }
}
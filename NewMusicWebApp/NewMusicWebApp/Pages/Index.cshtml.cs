using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace NewMusicWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppDbContext _context;
        public IList<Dj> Djs { get; set; }
        public Dj Dj { get; set; }
        public IList<Track> Tracks { get; set; }

        public IndexModel(ILogger<IndexModel> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            
            Djs = _context.Djs
                .Include(e => e.DjTracks)
                .ThenInclude(e => e.Track)
                .ToList();

        }
    }
}
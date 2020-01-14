using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace MusicFestivalWeb.Pages.TrackAuthors
{
    public class IndexModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public IndexModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<TrackAuthor> TrackAuthor { get;set; }

        public async Task OnGetAsync()
        {
            TrackAuthor = await _context.TrackAuthors
                .Include(t => t.Author)
                .Include(t => t.Track)
                .Include(t => t.TrackAuthorType).ToListAsync();
        }
    }
}

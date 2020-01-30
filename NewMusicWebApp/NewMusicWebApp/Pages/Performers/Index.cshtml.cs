using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace NewMusicWebApp.Pages.Performers
{
    public class IndexModel : PageModel
    {
        private readonly DAL.AppDbContext _context;
        public int DjId { get; set; }
        public int TrackId { get; set; }

        public IndexModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<Performer> Performer { get;set; }

        public async Task OnGetAsync(int? djid, int? trackid)
        {
            if (djid.HasValue)
            {
                DjId = djid.Value;
            }

            if (trackid.HasValue)
            {
                TrackId = trackid.Value;
            }
            Performer = await _context.Performers.ToListAsync();
        }
    }
}

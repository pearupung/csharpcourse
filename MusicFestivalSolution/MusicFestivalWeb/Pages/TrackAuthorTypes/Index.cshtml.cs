using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace MusicFestivalWeb.Pages.TrackAuthorTypes
{
    public class IndexModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public IndexModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<TrackAuthorType> TrackAuthorType { get;set; }

        public async Task OnGetAsync()
        {
            TrackAuthorType = await _context.TrackAuthorTypes.ToListAsync();
        }
    }
}

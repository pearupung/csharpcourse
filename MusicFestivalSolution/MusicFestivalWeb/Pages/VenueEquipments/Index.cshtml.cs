using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace MusicFestivalWeb.Pages.VenueEquipments
{
    public class IndexModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public IndexModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<VenueEquipment> VenueEquipment { get;set; }

        public async Task OnGetAsync()
        {
            VenueEquipment = await _context.VenueEquipments
                .Include(v => v.Equipment)
                .Include(v => v.Venue).ToListAsync();
        }
    }
}

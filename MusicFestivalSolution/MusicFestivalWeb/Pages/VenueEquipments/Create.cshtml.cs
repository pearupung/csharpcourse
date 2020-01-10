using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL;
using Domain;

namespace MusicFestivalWeb.Pages.VenueEquipments
{
    public class CreateModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public CreateModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["EquipmentId"] = new SelectList(_context.Equipments, "EquipmentId", "EquipmentId");
        ViewData["VenueId"] = new SelectList(_context.Venues, "VenueId", "VenueId");
            return Page();
        }

        [BindProperty]
        public VenueEquipment VenueEquipment { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.VenueEquipments.Add(VenueEquipment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

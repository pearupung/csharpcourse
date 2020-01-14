using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace MusicFestivalWeb.Pages.VenueEquipments
{
    public class EditModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public EditModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VenueEquipment VenueEquipment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VenueEquipment = await _context.VenueEquipments
                .Include(v => v.Equipment)
                .Include(v => v.OrganisedEvent).FirstOrDefaultAsync(m => m.VenueEquipmentId == id);

            if (VenueEquipment == null)
            {
                return NotFound();
            }
           ViewData["EquipmentId"] = new SelectList(_context.Equipments, "EquipmentId", "EquipmentName");
           ViewData["OrganisedEventId"] = new SelectList(_context.Events, "OrganisedEventId", "CleanUpTime");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(VenueEquipment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VenueEquipmentExists(VenueEquipment.VenueEquipmentId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VenueEquipmentExists(int id)
        {
            return _context.VenueEquipments.Any(e => e.VenueEquipmentId == id);
        }
    }
}

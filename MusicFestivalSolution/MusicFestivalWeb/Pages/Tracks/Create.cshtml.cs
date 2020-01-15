using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace MusicFestivalWeb.Pages.Tracks
{
    public class CreateModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        [BindProperty]
        public Track Track { get; set; }

        public int? SetId { get; set; }
        [BindProperty] public SetTrack SetTrack { get; set; }

        public CreateModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? setid)
        {
            SetId = setid;
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? setid)
        {
            SetId = setid;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tracks.Add(Track);
            await _context.SaveChangesAsync();
            if (SetId.HasValue)
            {
                SetTrack.TrackId = Track.TrackId;
                SetTrack.EventSetId = SetId.Value;
                _context.SetTracks.Add(SetTrack);
            }

            await _context.SaveChangesAsync();


            return RedirectToPage("./Details", 
                new
                {
                    id = Track.TrackId,
                    setid = SetId
                });
        }
    }
}

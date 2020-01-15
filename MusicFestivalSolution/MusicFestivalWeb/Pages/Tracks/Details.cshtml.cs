using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MusicFestivalWeb.Pages.Tracks
{
    public class DetailsModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public Track? Track { get; set; }

        [BindProperty] public TrackAuthor? NewTrackAuthor { get; set; }

        public SelectList AuthorSelectList { get; set; }
        public SelectList TrackAuthorTypeSelectList { get; set; }
        [BindProperty] public Person? NewAuthor { get; set; }
        [BindProperty] public TrackAuthorType? NewTrackAuthorType { get; set; }
        [BindProperty] public int? SetId { get; set; }
        [BindProperty(SupportsGet = true)] public int? EventId { get; set; }
        [BindProperty(SupportsGet = true)] public int? FestivalId { get; set; }

        public DetailsModel(DAL.AppDbContext context)
        {
            _context = context;
            AuthorSelectList = new SelectList(_context.Persons, nameof(Person.PersonId), nameof(Person.LastNameFirstNameStageName));
            TrackAuthorTypeSelectList = new SelectList(_context.TrackAuthorTypes, 
                nameof(NewTrackAuthorType.TrackAuthorTypeId), 
                nameof(NewTrackAuthorType.TrackAuthorTypeName));
        }

        public async Task<IActionResult> OnGetAsync(int? id, int? setId)
        {
            SetId = setId;
            if (id == null)
            {
                return RedirectToPage("/Tracks/Index");
            }

            Track = await _context.Tracks
                .Include(e => e.TrackAuthors)
                .ThenInclude(e => e.TrackAuthorType)
                .Include(e => e.TrackAuthors)
                .ThenInclude(e => e.Author)
                .FirstOrDefaultAsync(m => m.TrackId == id);

            if (Track == null)
            {
                return RedirectToPage("/Tracks/Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, int? setid)
        {
            SetId = setid;
            if (id == null)
            {
                return RedirectToPage("/Tracks/Index");
            }
            

            Track = await _context.Tracks
                .Include(e => e.TrackAuthors)
                .ThenInclude(e => e.TrackAuthorType)
                .Include(e => e.TrackAuthors)
                .ThenInclude(e => e.Author)
                .FirstOrDefaultAsync(m => m.TrackId == id);

            if (Track == null)
            {
                return RedirectToPage("/Tracks/Index");
            }

            Console.WriteLine("usual post");
            return RedirectToPage("./Details", new {id = id});
        }
        
        public async Task<IActionResult> OnPostTrackAuthors(int? id, int? setid)
        {
            SetId = setid;
            if (id == null)
            {
                return RedirectToPage("/Tracks/Index");
            }

            NewTrackAuthor.TrackId = id.Value;
            _context.TrackAuthors.Add(NewTrackAuthor);
            await _context.SaveChangesAsync();

            Track = await _context.Tracks
                .Include(e => e.TrackAuthors)
                .ThenInclude(e => e.TrackAuthorType)
                .Include(e => e.TrackAuthors)
                .ThenInclude(e => e.Author)
                .FirstOrDefaultAsync(m => m.TrackId == id);

            
            if (Track == null)
            {
                return RedirectToPage("/Tracks/Index");
            }

            Console.WriteLine("usual post");
            return RedirectToPage("./Details", new
            {
                id = id,
                setid = SetId
            });
        }
        
        public async Task<IActionResult> OnPostNewAuthor(int? id, int? setid)
        {
            SetId = setid;
            if (id == null)
            {
                return RedirectToPage("/Tracks/Index");
            }

            Track = await _context.Tracks
                .Include(e => e.TrackAuthors)
                .ThenInclude(e => e.TrackAuthorType)
                .Include(e => e.TrackAuthors)
                .ThenInclude(e => e.Author)
                .FirstOrDefaultAsync(m => m.TrackId == id);
            
            if (string.IsNullOrEmpty(NewAuthor.FirstName) ||
                string.IsNullOrEmpty(NewAuthor.LastName))
            {
                if (Track == null)
                {
                    return RedirectToPage("/Tracks/Index");
                }

                return Page();
            }

            _context.Persons.Add(NewAuthor);
            await _context.SaveChangesAsync();
            
            if (Track == null)
            {
                return RedirectToPage("/Tracks/Index");
            }

            return RedirectToPage("./Details", new
            {
                id = id,
                setId = SetId
            });

        }
        
        public async Task<IActionResult> OnPostNewTrackAuthorType(int? id, int? setid)
        {
            SetId = setid;
            if (id == null)
            {
                return RedirectToPage("/Tracks/Index");
            }


            Track = await _context.Tracks
                .Include(e => e.TrackAuthors)
                .ThenInclude(e => e.TrackAuthorType)
                .Include(e => e.TrackAuthors)
                .ThenInclude(e => e.Author)
                .FirstOrDefaultAsync(m => m.TrackId == id);
            
            if (string.IsNullOrEmpty(NewTrackAuthorType.TrackAuthorTypeName))
            {
                if (Track == null)
                {
                    return RedirectToPage("/Tracks/Index");
                }

                Console.WriteLine("ModelState invalid");
                return Page();
            }

            _context.TrackAuthorTypes.Add(NewTrackAuthorType);
            await _context.SaveChangesAsync();
            
            if (Track == null)
            {
                return RedirectToPage("/Tracks/Index");
            }

            Console.WriteLine("Redirected");
            return RedirectToPage("./Details", new
            {
                id = id,
                setId = SetId
            });

        }
        
    }
}

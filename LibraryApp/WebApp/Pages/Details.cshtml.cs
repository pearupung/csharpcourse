using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.DTO;

namespace WebApp.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public DetailsModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public Book Book { get; set; }
        
        [BindProperty]
        public Review Review { get; set; }
        public List<AuthorDto> Authors { get; set; }
        public List<ReviewDto> Reviews { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Reviews = _context.Reviews
                .Where(r => r.BookId == id).Select(r => new ReviewDto()
                {
                    Review = r
                }).ToList();
            
            Authors = _context.Authors.Where(a => a.AuthoredBooks.Any(a => a.BookId == id))
                .Select(a => new AuthorDto()
                {
                    Author = a,
                    BooksAuthored = a.AuthoredBooks.Count
                })
                .ToList();
            Book = await _context.Books
                .Include(b => b.Language)
                .Include(b => b.Publisher).FirstOrDefaultAsync(m => m.BookId == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid || id == null)
            {
                return Page();
            }
            
            Review.TimePosted = DateTime.Now;
            Review.BookId = id.Value;

            _context.Reviews.Add(Review);
            await _context.SaveChangesAsync();

            return RedirectToPage("Details", new {id = id});
        }
    }
}

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
    public class DeleteModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public DeleteModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }

        public List<AuthorDto> Authors { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

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
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Books.FindAsync(id);

            if (Book != null)
            {
                _context.Books.Remove(Book);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

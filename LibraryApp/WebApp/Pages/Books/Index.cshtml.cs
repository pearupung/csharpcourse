using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public IndexModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }

        public async Task OnGetAsync(string? search)
        {
            
            
            if (string.IsNullOrWhiteSpace(search))
            {
                Book = await _context.Books
                    .Include(b => b.Language)
                    .Include(b => b.Publisher).ToListAsync();
            }
            else
            {
                search = search.ToLower().Trim();
                Book = await _context.Books.Where(b => b.Title=="Sugar")
                    .Include(b => b.Language)
                    .Include(b => b.Publisher).ToListAsync()
                    ;
            }
            
        }
    }
}

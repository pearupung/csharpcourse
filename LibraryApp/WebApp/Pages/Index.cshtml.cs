using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using DAL;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DAL.AppDbContext _context;
        public List<BookIndexDto> BookIndexDtos { get; set; }

        public IList<Book> Books { get; set; }
        [BindProperty] public string SearchString { get; set; }

        public List<CheckboxAbstraction> SearchButtons { get; set; }

        public IndexModel(ILogger<IndexModel> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult OnGet(string? searchString)
        {
            //return RedirectToPage("Details", new {id= 5});
            SearchString = searchString;
            Console.WriteLine(SearchString);

            if (string.IsNullOrEmpty(SearchString))
            {
                BookIndexDtos = _context.Books
                    .Include(b => b.Reviews)
                    .Include(b => b.BookAuthors)
                    .ThenInclude(a => a.Author)
                    .Select(b => new BookIndexDto(){Book = b, ReviewCount = b.Reviews.Count, Authors = b.BookAuthors.Select(a => a.Author).ToList()})
                    .ToList();
                SearchButtons = new List<CheckboxAbstraction>()
                {
                    new CheckboxAbstraction(){Title = "Everywhere",IsChecked = true},
                    new CheckboxAbstraction() {Title = "Books", IsChecked = false},
                    new CheckboxAbstraction() {Title = "Authors", IsChecked = false},
                    new CheckboxAbstraction() {Title = "Publishers", IsChecked = false},
                };
            }
            else
            {
                BookIndexDtos = _context.Books.Where(b => b.Title.ToLower()
                        .Contains(searchString.ToLower()))
                    .Include(b=>b.Reviews)
                    .Select(b => new BookIndexDto() {
                        Book = b, 
                        ReviewCount = b.Reviews.Count})
                    .ToList();
                SearchButtons = new List<CheckboxAbstraction>()
                {
                    new CheckboxAbstraction(){Title = "Everywhere",IsChecked = true},
                    new CheckboxAbstraction() {Title = "Books", IsChecked = false},
                    new CheckboxAbstraction() {Title = "Authors", IsChecked = false},
                    new CheckboxAbstraction() {Title = "Publishers", IsChecked = false},
                };
            }

            return Page();
        }
    }
}
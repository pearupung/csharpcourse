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
        public string SearchString { get; set; }

        [BindProperty] public List<CheckboxAbstraction> SearchButtons { get; set; }

        public IndexModel(ILogger<IndexModel> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult OnGet(string? searchString, List<CheckboxAbstraction> searchButtons, string? ToDoActionReset)
        {
            //return RedirectToPage("Details", new {id= 5});
            SearchString = searchString;
            Console.WriteLine(SearchString);
            SearchButtons = searchButtons;

            if ("Reset".Equals(ToDoActionReset))
            {
                SearchString = "";
            }
            
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
                var searchStringLowered = searchString.ToLower();
                var searchEveryWhereQuery = _context.Books.Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                    .Include(b => b.Publisher).Where(
                    b =>
                        b.Title.ToLower().Contains(searchStringLowered) ||
                        b.BookAuthors.Any(a => a.Author.FirstName.ToLower().Contains(searchStringLowered)) ||
                        b.BookAuthors.Any(a => a.Author.LastName.ToLower().Contains(searchStringLowered)) ||
                        b.Publisher.PublisherName.Contains(searchStringLowered)).AsQueryable();
                
                var searchSelectiveQuery = _context.Books.Where(
                        b =>
                            SearchButtons[1].IsChecked && b.Title.ToLower().Contains(searchStringLowered) ||
                            SearchButtons[2].IsChecked && b.BookAuthors.Any(a => a.Author.FirstName.ToLower().Contains(searchStringLowered)) ||
                            SearchButtons[2].IsChecked && b.BookAuthors.Any(a => a.Author.LastName.ToLower().Contains(searchStringLowered)) ||
                            SearchButtons[3].IsChecked && b.Publisher.PublisherName.Contains(searchStringLowered))
                    .AsQueryable();
                var usedQuery = SearchButtons[0].IsChecked ? searchEveryWhereQuery : searchSelectiveQuery;
                BookIndexDtos = usedQuery
                    .Include(b=>b.Reviews)
                    .Include(b => b.BookAuthors)
                    .ThenInclude(a => a.Author)
                    .Select(b => new BookIndexDto() {
                        Book = b, 
                        ReviewCount = b.Reviews.Count,
                        Authors = b.BookAuthors.Select(a => a.Author).ToList()
                    })
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DAL.AppDbContext _context;

        public IList<Book> Books { get; set; }
        
        public List<CheckboxAbstraction> SearchButtons { get; set; }

        public IndexModel(ILogger<IndexModel> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            Books = _context.Books.ToList();
            SearchButtons = new List<CheckboxAbstraction>()
            {
                new CheckboxAbstraction(){Title = "All", IsChecked = true},
                new CheckboxAbstraction(){Title = "Books", IsChecked = false},
                new CheckboxAbstraction(){Title = "Authors",IsChecked = false},
                new CheckboxAbstraction(){Title = "Publishers",IsChecked = false},
                new CheckboxAbstraction(){Title = "All", IsChecked = true},
                new CheckboxAbstraction(){Title = "Books", IsChecked = false},
                new CheckboxAbstraction(){Title = "Authors",IsChecked = false},
                new CheckboxAbstraction(){Title = "Publishers",IsChecked = false},
                new CheckboxAbstraction(){Title = "All", IsChecked = true},
                new CheckboxAbstraction(){Title = "Books", IsChecked = false},
                new CheckboxAbstraction(){Title = "Authors",IsChecked = false},
                new CheckboxAbstraction(){Title = "Publishers",IsChecked = false}
            };

        }
    }
    
}
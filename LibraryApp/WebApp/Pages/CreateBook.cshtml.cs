using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using WebApp.Pages.Shared;
using WebApp.Pages.Shared.Publisher;

namespace WebApp.Pages
{
    public class CreateBookModel : PageModel
    {
        private readonly DAL.AppDbContext _context;
        [BindProperty] public Book Book { get; set; }
        public BookPartialModel BookPartialModel { get; set; }
        public LanguagePartialModel LanguagePartialModel { get; set; }
        public AuthorPartialModel AuthorPartialModel { get; set; }
        [BindProperty]
        public PublisherPartialModel PublisherPartialModel { get; set; }
        public SelectList PublisherSelectList { get; set; }
        
        public PickPublisherModel PickPublisherModel { get; set; }

        public CreateBookModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["LanguageId"] = new SelectList(_context.Languages, "LanguageId", "LanguageName");
            PublisherSelectList = new SelectList(_context.Publishers, "PublisherId", "PublisherName");
            PublisherPartialModel = new PublisherPartialModel(PublisherSelectList);
            
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var newPublisher = PublisherPartialModel?.NewPublisher;
                if (!string.IsNullOrEmpty(newPublisher))
                {
                    Console.WriteLine("Added Publisher" + newPublisher);
                    _context.Publishers.Add(new Publisher(newPublisher));
                    await _context.SaveChangesAsync();
                }
                else
                {
                }

                Console.WriteLine("POST HAHAHA");
                PublisherSelectList = new SelectList(_context.Publishers, "PublisherId", "PublisherName");
                PublisherPartialModel = new PublisherPartialModel(PublisherSelectList);
                return Page();
            }

            return Page();

            _context.Books.Add(Book);
            await _context.SaveChangesAsync();


            return RedirectToPage("./Index");
        }
    }
}
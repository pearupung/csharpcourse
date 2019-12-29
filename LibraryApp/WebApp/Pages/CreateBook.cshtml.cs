using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Pages.Shared;

namespace WebApp.Pages
{
    public class CreateBookModel : PageModel
    {
        private readonly DAL.AppDbContext _context;
        public Language NewLanguage { get; set; }
        public Publisher NewPublisher { get; set; }
        public Language SelectedLanguage { get; set; }
        public SelectList Languages { get; set; }
        public _ChooseOrCreatePublisher PublisherPartialModel { get; set; }
        public SelectList PublishersSelectList { get; set; }
        [BindProperty]
        public Book Book { get; set; } = new Book();

        public bool IsAddLanguageHidden { get; set; }

        public CreateBookModel(DAL.AppDbContext context)
        {
            _context = context;
        }


        public IActionResult OnGet(bool? addLanguage)
        {
            if (addLanguage.HasValue)
            {
                IsAddLanguageHidden = false;
            }
            Languages = new SelectList(_context.Languages, nameof(Language.LanguageId), nameof(Language.LanguageName));
            PublishersSelectList = new SelectList(_context.Publishers, nameof(Publisher.PublisherId), nameof(Publisher.PublisherName));

            PublisherPartialModel = new _ChooseOrCreatePublisher(PublishersSelectList);
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string submit)
        {
            Console.WriteLine(submit);
            switch (submit)
            {
                case "addPublisher":
                    Redirect("./Privacy");
                    break;
            }
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
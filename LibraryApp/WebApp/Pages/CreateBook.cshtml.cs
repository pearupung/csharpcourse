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
using WebApp.Pages.Shared.Partials;
using WebApp.Pages.Shared.Publisher;

namespace WebApp.Pages
{
    public class CreateBookModel : PageModel
    {
        private readonly DAL.AppDbContext _context;
        [BindProperty]
        public BookPartialModel BookPartialModel { get; set; }
        public AuthorPartialModel AuthorPartialModel { get; set; }
        [BindProperty]
        public PublisherPartialModel PublisherPartialModel { get; set; }
        [BindProperty]
        public PickLanguageModel PickLanguageModel { get; set; }
        public SelectList PublisherSelectList { get; set; }
        [BindProperty]
        public PickPublisherModel PickPublisherModel { get; set; }

        public SelectList LanguageSelectList { get; set; }
        [BindProperty]
        public LanguagePartialModel LanguagePartialModel { get; set; }

        public CreateBookModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            LanguageSelectList = new SelectList(_context.Languages, "LanguageId", "LanguageName");
            PublisherSelectList = new SelectList(_context.Publishers, "PublisherId", "PublisherName");
            PickPublisherModel = new PickPublisherModel(PublisherSelectList);
            PublisherPartialModel = new PublisherPartialModel();
            PickLanguageModel = new PickLanguageModel(LanguageSelectList);
            
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string? publisherPick, string? languagePick, BookPartialModel bookPartialModel, LanguagePartialModel languagePartialModel, PublisherPartialModel publisherPartialModel)
        {
            BookPartialModel = bookPartialModel;
            if (!ModelState.IsValid)
            {
                Console.WriteLine(BookPartialModel.Book);
                // PUBLISHER
                var newPublisher = PickPublisherModel?.NewPublisher;
                if (!string.IsNullOrEmpty(newPublisher) && "add".Equals(publisherPick))
                {
                    Console.WriteLine("Added Publisher" + newPublisher);
                    var publisher = new Publisher(newPublisher);
                    publisher = _context.Publishers.Add(publisher).Entity;
                    BookPartialModel.Book.Publisher = publisher;
                    Console.WriteLine(BookPartialModel.Book.Publisher.PublisherName);
                    PublisherPartialModel.Publisher = BookPartialModel.Book.Publisher;
                    await _context.SaveChangesAsync();
                }
                if ("pick".Equals(publisherPick))
                {
                    Console.WriteLine("Picked Publisher" + PickPublisherModel?.Publisher);
                    BookPartialModel.Book.Publisher = await _context.Publishers.FindAsync(PickPublisherModel?.Publisher);
                    Console.WriteLine(BookPartialModel.Book.Publisher.PublisherName);
                }
                PublisherPartialModel.Publisher = BookPartialModel.Book.Publisher;

                // LANGUAGE
                var newLanguage = PickLanguageModel?.NewLanguage;
                if (!string.IsNullOrEmpty(newLanguage) && "add".Equals(languagePick))
                {
                    Console.WriteLine("Added Language" + newLanguage);
                    var language = new Language(newLanguage);
                    language = _context.Languages.Add(language).Entity;
                    BookPartialModel.Book.Language = language;
                    Console.WriteLine(BookPartialModel.Book.Language.LanguageName);
                    LanguagePartialModel.Language = BookPartialModel.Book.Language;
                    await _context.SaveChangesAsync();
                }
                if ("pick".Equals(languagePick))
                {
                    Console.WriteLine("Picked Language" + PickLanguageModel?.Language);
                    BookPartialModel.Book.Language = await _context.Languages.FindAsync(PickLanguageModel?.Language);
                    Console.WriteLine(BookPartialModel.Book.Language.LanguageName);
                    LanguagePartialModel.Language = BookPartialModel.Book.Language;
                }
                LanguagePartialModel.Language = BookPartialModel.Book.Language;

                Console.WriteLine("POST HAHAHA");
                PublisherSelectList = new SelectList(_context.Publishers, "PublisherId", "PublisherName");
                PickPublisherModel.PublishersSelectlist = PublisherSelectList;
                LanguageSelectList = new SelectList(_context.Languages, "LanguageId", "LanguageName");
                PickLanguageModel.LanguagesSelectlist = LanguageSelectList;
            }

            Console.WriteLine("\n\nthis is the book partial " + BookPartialModel);
            return Page();

            _context.Books.Add(BookPartialModel.Book);
            await _context.SaveChangesAsync();


            return RedirectToPage("./Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using WebApp.DTO;
using WebApp.Pages.Shared;
using WebApp.Pages.Shared.Partials;
using WebApp.Pages.Shared.Publisher;

namespace WebApp.Pages
{
    public class CreateBookModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        private readonly IWebHostEnvironment _env;

        public List<AuthorDto> Authors { get; set; }
        public Author NewAuthor { get; set; }

        [BindProperty] public Book Book { get; set; }
        public MultiSelectList BookAuthorsSelectList { get; set; }
        [BindProperty] public bool LanguageIsSet { get; set; }
        [BindProperty] public bool PublisherIsSet { get; set; }
        [BindProperty] public List<int> SelectedAuthorIds { get; set; } = new List<int>();
        [BindProperty] public List<int> AuthorIds { get; set; }

        [BindProperty] public PickLanguageModel PickLanguageModel { get; set; }
        [BindProperty] public PickPublisherModel PickPublisherModel { get; set; }
        [BindProperty] public PickAuthorPartialModel PickAuthorPartialModel { get; set; }
        
        [BindProperty] public IFormFile Upload { get; set; }
        [BindProperty] public string UploadImagePath { get; set; }
        
        [BindProperty] public PickPictureEditModel PickPictureModel { get; set; }
        [BindProperty] public IFormFile FormFile { get; set; }


        public CreateBookModel(DAL.AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        public IActionResult OnGet()
        {
            PickPublisherModel ??= new PickPublisherModel();
            PickLanguageModel ??= new PickLanguageModel();
            PickAuthorPartialModel ??= new PickAuthorPartialModel();
            PickPictureModel ??= new PickPictureEditModel();
            PickLanguageModel.LanguagesSelectlist = new SelectList(_context.Languages,
                nameof(Language.LanguageId), nameof(Language.LanguageName));
            PickPublisherModel.PublishersSelectlist = new SelectList(_context.Publishers,
                nameof(Publisher.PublisherId), nameof(Publisher.PublisherName));
            PickAuthorPartialModel.BookAuthorsSelectList =
                new SelectList(_context.Authors, nameof(Author.AuthorId), nameof(Author.FirstName));
            Authors = new List<AuthorDto>();
            AuthorIds = new List<int>();
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string? languagePick,
            string? publisherPick, string? deleteLanguage, string? deletePublisher,
            string? deleteAuthor, string? authorPick, List<int>? hiddenAuthorsList,
            string? final, string? picturePick, string? deletePicture)
        {
            if (!string.IsNullOrEmpty(languagePick) && "pick".Equals(languagePick))
            {
                LanguageIsSet = true;
                Book.LanguageId = PickLanguageModel.LanguageId;
                Book.Language = _context.Languages.Find(Book.LanguageId);
            }
            else if (!string.IsNullOrEmpty(languagePick) && "add".Equals(languagePick) &&
                     !string.IsNullOrEmpty(PickLanguageModel.NewLanguageName))
            {
                LanguageIsSet = true;
                var language = new Language(PickLanguageModel.NewLanguageName, "EE");
                if (!_context.Languages.Any(l => l.LanguageName == language.LanguageName))
                {
                    _context.Languages.Add(language);
                    _context.SaveChanges();
                    Book.LanguageId = language.LanguageId;
                }
                else
                {
                    Book.LanguageId = _context.Languages
                        .First(l => l.LanguageName == language.LanguageName).LanguageId;
                }

                Book.Language = _context.Languages.Find(Book.LanguageId);
            }

            if (!string.IsNullOrEmpty(deleteLanguage))
            {
                Book.LanguageId = 0;
                LanguageIsSet = false;
            }

            if (!string.IsNullOrEmpty(publisherPick) && "pick".Equals(publisherPick) &&
                PickPublisherModel.PublisherId != null)
            {
                PublisherIsSet = true;
                Book.PublisherId = (int) PickPublisherModel.PublisherId;
                Book.Publisher = _context.Publishers.Find(Book.PublisherId);
            }
            else if (!string.IsNullOrEmpty(publisherPick) && "add".Equals(publisherPick) &&
                     !string.IsNullOrEmpty(PickPublisherModel.NewPublisherName))
            {
                PublisherIsSet = true;
                var publisher = new Publisher(PickPublisherModel.NewPublisherName);
                if (!_context.Publishers.Any(a => a.PublisherName == publisher.PublisherName))
                {
                    _context.Publishers.Add(publisher);
                    _context.SaveChanges();
                    Book.PublisherId = publisher.PublisherId;
                }
                else
                {
                    Book.PublisherId = _context.Publishers
                        .First(p => p.PublisherName == publisher.PublisherName).PublisherId;
                }

                Book.Publisher = _context.Publishers.Find(Book.PublisherId);
            }

            if (!string.IsNullOrEmpty(deletePublisher))
            {
                Book.PublisherId = 0;
                PublisherIsSet = false;
            }

            if (LanguageIsSet)
            {
                Book.Language = _context.Languages.Find(Book.LanguageId);
            }
            else
            {
                PickLanguageModel.LanguagesSelectlist = new SelectList(_context.Languages,
                    nameof(Language.LanguageId), nameof(Language.LanguageName));
            }

            if (PublisherIsSet)
            {
                Book.Publisher = _context.Publishers.Find(Book.PublisherId);
            }
            else
            {
                PickPublisherModel.PublishersSelectlist = new SelectList(_context.Publishers,
                    nameof(Publisher.PublisherId), nameof(Publisher.PublisherName));
            }

            AuthorIds = hiddenAuthorsList;
            if (!string.IsNullOrEmpty(authorPick) && "pick".Equals(authorPick))
            {
                Console.WriteLine("Got to Pick!" + SelectedAuthorIds.Count +
                                  PickAuthorPartialModel.SelectedAuthorIds.Count);
                foreach (var selectedAuthorId in PickAuthorPartialModel.SelectedAuthorIds)
                {
                    if (!AuthorIds.Contains(selectedAuthorId))
                    {
                        AuthorIds.Add(selectedAuthorId);
                    }
                }
            }

            var author = PickAuthorPartialModel.Author;

            if (!string.IsNullOrEmpty(authorPick) && "add".Equals(authorPick) &&
                !string.IsNullOrEmpty(author.FirstName) && !string.IsNullOrEmpty(author.LastName))
            {
                Console.WriteLine(author);
                if (!_context.Authors.Any(a => a.FirstName == author.FirstName &&
                                               a.LastName == author.LastName &&
                                               a.BirthYear == author.BirthYear &&
                                               a.DeathYear == author.DeathYear &&
                                               a.Description == author.Description))
                {
                    Console.WriteLine("Got to add author!");
                    _context.Authors.Add(author);
                    _context.SaveChanges();
                    AuthorIds.Add(author.AuthorId);
                }
                else
                {
                    AuthorIds.Add(_context.Authors.FirstOrDefault(a => a.FirstName == author.FirstName &&
                                                                       a.LastName == author.LastName &&
                                                                       a.BirthYear == author.BirthYear &&
                                                                       a.DeathYear == author.DeathYear &&
                                                                       a.Description == author.Description).AuthorId);
                }
            }


            if (!string.IsNullOrEmpty(deleteAuthor) && int.TryParse(deleteAuthor, out var authorId))
            {
                Console.WriteLine("AuhorInt: " + authorId);
                AuthorIds.Remove(authorId);
            }

            BookAuthorsSelectList = new SelectList(_context.Authors, nameof(Author.AuthorId), nameof(Author.FirstName));
            PickAuthorPartialModel.BookAuthorsSelectList =
                new SelectList(_context.Authors, nameof(Author.AuthorId), nameof(Author.FirstName));

            Authors =_context.Authors.Where(a => AuthorIds.Contains(a.AuthorId))
                .Select(a => new AuthorDto()
                {
                    Author = a,
                    BooksAuthored = a.AuthoredBooks.Count
                }).ToList();
            Console.WriteLine("Before picturepick!");
            if (!string.IsNullOrEmpty(picturePick) && "add".Equals(picturePick)
                && FormFile != null)
            {
                Console.WriteLine("Inside picturePick! " + FormFile.FileName);
                var file = Path.Combine(_env.WebRootPath, "resources", FormFile.FileName);
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await FormFile.CopyToAsync(fileStream);
                }

                UploadImagePath = FormFile.FileName;
                Book.PicturePath = UploadImagePath;
            }

            if (!string.IsNullOrEmpty(deletePicture) && "remove".Equals(deletePicture))
            {
                UploadImagePath = null;
                Book.PicturePath = null;
            }

            Book.PicturePath = UploadImagePath;

            if (!string.IsNullOrEmpty(final) && "Create".Equals(final)
                                             && !string.IsNullOrEmpty(Book.Title)
                                             && Book.Language != null
                                             && Book.Publisher != null
                                             && AuthorIds.Count > 0
                                             && !string.IsNullOrEmpty(Book.PicturePath))
            {
                _context.Books.Add(Book);
                _context.SaveChanges();
                Book.BookAuthors = new List<BookAuthor>();
                foreach (var id in AuthorIds)
                {
                    _context.BookAuthors.Add(new BookAuthor()
                    {
                        BookId = Book.BookId,
                        AuthorId = id,
                        Author = _context.Authors.Find(id)
                    });
                    _context.SaveChanges();
                }


                return Redirect("./Index");
            }

            return Page();
        }
    }
}
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp
{
    public class BookPartialModel
    {
        public Book Book { get; set; }

        public BookPartialModel(Book book)
        {
            Book = book;
        }

        public BookPartialModel()
        {
            
        }

        public override string ToString()
        {
            return Book.ToString();
        }
    }
}
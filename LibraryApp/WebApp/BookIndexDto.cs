using System.Collections.Generic;
using System.Linq;
using Domain;

namespace WebApp
{
    public class BookIndexDto
    {
        public Book Book { get; set; }
        public int ReviewCount { get; set; }
        public List<Author> Authors { get; set; }
        public string? LastComment { get; set; }
        public string Title => Book.Title;
        public string Summary => Book.Summary;
        public string BookAuthors => Authors.Select(a => a.FirstLastName).ToString();
    }
}
using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public int BirthYear { get; set; } = default!;
        public int? DeathYear { get; set; }
        public string FirstLastName => FirstName + " " + LastName;
        public string? Description { get; set; }

        public ICollection<BookAuthor>? AuthoredBooks { get; set; }

        public Author()
        {
        }
    }
}
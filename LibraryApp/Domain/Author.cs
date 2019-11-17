using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }
        public string Description { get; set; }

        public ICollection<BookAuthor> AuthoredBooks { get; set; }
    }
}
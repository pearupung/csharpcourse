using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class Author
    {
        public int AuthorId { get; set; }
        public ICollection<Book> Books { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public ICollection<string> Genres { get; set; }
    }
}
using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class Author
    {
        public int AuthorId { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
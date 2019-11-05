using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class Shelf
    {
        public int ShelfId { get; set; }
        public int LibraryId { get; set; }
        public Library Library { get; set; }
        public ICollection<Book> Books { get; set; }

        public int Number { get; set; }
    }
}
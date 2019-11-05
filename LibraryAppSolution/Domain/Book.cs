using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class Book
    {
        public int BookId { get; set; }
        public int ShelfId { get; set; }
        public Shelf Shelf { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
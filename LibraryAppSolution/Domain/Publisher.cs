using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public ICollection<Book> PublishedBooks { get; set; }
    }
}
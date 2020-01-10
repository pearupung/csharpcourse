using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class Publisher
    {
        public Publisher(){}
        public Publisher(string newPublisher)
        {
            PublisherName = newPublisher;
        }

        public int PublisherId { get; set; }
        public string PublisherName { get; set; }  = default!;
        public ICollection<Book>? Books { get; set; }
    }
}
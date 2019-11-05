using System;

namespace Domain
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }

        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PostedTime { get; set; }
    }
}
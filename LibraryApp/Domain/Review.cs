using System;

namespace Domain
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string? ReviewText { get; set; }
        public DateTime TimePosted { get; set; } = default!;
        public string Title { get; set; } = default!;
        public int? Stars { get; set; }

        public int BookId { get; set; } = default!;
        public Book Book { get; set; }  = default!;
    }
}
using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } = default!;
        public int PublishingYear { get; set; } = default!;
        public int AuthoredYear { get; set; } = default!;
        public int WordCount { get; set; } = default!;
        public string? Summary { get; set; }

        public ICollection<BookAuthor>? BookAuthors { get; set; }
        public int LanguageId { get; set; } = default!;
        public Language Language { get; set; } = default!;

        public int PublisherId { get; set; } = default!;
        public Publisher Publisher { get; set; } = default!;

        public ICollection<Review>? Reviews { get; set; }
    }
}
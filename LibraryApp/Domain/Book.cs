using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } = default!;
        [DisplayName("Publishing year")]
        public int PublishingYear { get; set; } = default!;
        public int AuthoredYear { get; set; } = default!;
        public int WordCount { get; set; } = default!;
        public string? Summary { get; set; }

        public ICollection<BookAuthor>? BookAuthors { get; set; }
        public int LanguageId { get; set; }
        public Language? Language { get; set; }

        public int PublisherId { get; set; }
        public Publisher? Publisher { get; set; }

        public ICollection<Review>? Reviews { get; set; }
    }
}
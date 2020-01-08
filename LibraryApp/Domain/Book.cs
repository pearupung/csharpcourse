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
        public int LanguageId { get; set; } = default!;
        public Language? Language { get; set; }

        public int PublisherId { get; set; }
        public Publisher? Publisher { get; set; }

        public ICollection<Review>? Reviews { get; set; }

        public override string ToString()
        {
            return $"{nameof(BookId)}: {BookId}, {nameof(Title)}: {Title}, {nameof(PublishingYear)}: {PublishingYear}, {nameof(AuthoredYear)}: {AuthoredYear}, {nameof(WordCount)}: {WordCount}, {nameof(LanguageId)}: {LanguageId}, {nameof(Language)}: {Language}, {nameof(PublisherId)}: {PublisherId}, {nameof(Publisher)}: {Publisher}";
        }

        public Book()
        {
            
        }
        
    }
}
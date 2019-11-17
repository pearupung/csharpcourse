using System;

namespace Domain
{
    public class Review
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public DateTime TimePosted { get; set; }
        public string Title { get; set; }
        public int Stars { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
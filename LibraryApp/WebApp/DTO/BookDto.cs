using Domain;

namespace WebApp.DTO
{
    public class BookDto
    {
        public Book Book { get; set; }
        public int CommentCount { get; set; }
        public string LastComment { get; set; }
    }
}
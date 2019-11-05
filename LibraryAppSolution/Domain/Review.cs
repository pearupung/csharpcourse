namespace Domain
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
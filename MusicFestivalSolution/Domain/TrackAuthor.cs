namespace Domain
{
    public class TrackAuthor
    {
        public int TrackAuthorId { get; set; }

        public int PersonId { get; set; } = default!;
        public Person? Author { get; set; }

        public int TrackId { get; set; } = default!;
        public Track? Track { get; set; }

        public int TrackAuthorTypeId { get; set; } = default!;
        public TrackAuthorType? TrackAuthorType { get; set; }

    }
}
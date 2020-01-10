namespace Domain
{
    public class TrackPayRight
    {
        public int TrackPayRightId { get; set; }
        public int TrackId { get; set; }
        public Track Track { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int PayRightPercentage { get; set; }
    }
}
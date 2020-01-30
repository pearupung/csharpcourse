namespace Domain
{
    public class DjTrack
    {
        public int DjTrackId { get; set; }
        public int TrackId { get; set; }
        public Track Track { get; set; }

        public int DjId { get; set; }
        public Dj Dj { get; set; }
        
    }
}
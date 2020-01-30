using System.Collections.Generic;

namespace Domain
{
    public class Track
    {
        public int TrackId { get; set; }
        public string  TrackName { get; set; }
        public int TrackLengthInSeconds { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<PerformerTrack> PerformerTracks { get; set; }
        public List<DjTrack> DjTracks { get; set; }
    }
}
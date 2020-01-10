using System;
using System.Collections.Generic;

namespace Domain.Track_sets
{
    public class Track
    {
        public string TrackName { get; set; }
        public string Artist { get; set; }

        public TimeSpan TimeSpan { get; set; }
        public string Vibe { get; set; }
        public int PopularityOutOfTen { get; set; }
        public int MinutePrice { get; set; }

        public List<SetTrack> SetTracks { get; set; }

        public int TrackPayRightId { get; set; }
        public TrackPayRight TrackPayRight { get; set; }
    }
}
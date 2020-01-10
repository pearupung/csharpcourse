using System;
using System.Collections.Generic;

namespace Domain
{
    public class Track
    {
        public int TrackId { get; set; }
        
        public string TrackName { get; set; }
        public string Artist { get; set; }

        public TimeSpan TimeSpan { get; set; }
        public string Vibe { get; set; }
        public int PopularityOutOfTen { get; set; }
        public int MinutePrice { get; set; }

        public List<SetTrack> SetTracks { get; set; }

        public List<TrackPayRight> TrackPayRights { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace Domain.Track_sets
{
    public class Set
    {
        public string SetName { get; set; }
        public TimeSpan SetDuration { get; set; }

        // Set Dj
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int EventId { get; set; }
        public Event.Event Event { get; set; }

        public List<SetTrack> SetTracks { get; set; }
    }
}
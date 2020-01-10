using System;
using System.Collections.Generic;

namespace Domain
{
    public class Set
    {

        public int SetId { get; set; }
        public string SetName { get; set; }
        public TimeSpan SetDuration { get; set; }

        // Set Dj
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }

        public List<SetTrack> SetTracks { get; set; }
    }
}
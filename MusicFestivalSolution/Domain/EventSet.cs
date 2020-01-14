using System;
using System.Collections.Generic;

namespace Domain
{
    public class EventSet
    {

        public int EventSetId { get; set; }
        public string SetName { get; set; } = default!;
        public string SetDuration { get; set; } = default!;

        // Set Dj
        public int PersonId { get; set; } = default!;
        public Person? Dj { get; set; }

        public int EventId { get; set; } = default!;
        public OrganisedEvent? Event { get; set; }

        public List<SetTrack> SetTracks { get; set; } = default!;
    }
}
using System;
using System.Collections.Generic;

namespace Domain
{
    public class EventSet
    {

        public int SetId { get; set; }
        public string SetName { get; set; }
        public string SetDuration { get; set; }

        // Set Dj
        public int? PersonId { get; set; }
        public Person? Person { get; set; }

        public int? EventId { get; set; }
        public OrganisedEvent? Event { get; set; }

        public List<SetTrack>? SetTracks { get; set; }
    }
}
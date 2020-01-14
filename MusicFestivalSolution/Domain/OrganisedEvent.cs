using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class OrganisedEvent
    {
        public int OrganisedEventId { get; set; }
        public string EventName { get; set; } = default!;

        public int TicketCount { get; set; } = default!;
        public int TicketPrice { get; set; } = default!;

        public string StartTime { get; set; } = default!;
        public string StartDate { get; set; } = default!;
        public string EndTime { get; set; } = default!;
        public string EndDate { get; set; } = default!;

        public string PreparationTime { get; set; } = default!;
        public string CleanUpTime { get; set; } = default!;

        public int VenueId { get; set; } = default!;
        public Venue? Venue { get; set; } 

        public List<VenueEquipment>? VenueEquipment { get; set; }

        public List<EventSet>? Sets { get; set; }
        public List<FestivalEvent> FestivalEvents { get; set; } = default!;
        public List<Participant>? Participants { get; set; }
    }
}
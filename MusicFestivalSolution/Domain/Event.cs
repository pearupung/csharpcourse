using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Event
    {
        public int EventId { get; set; } = default!;
        public string EventName { get; set; } = default!;

        public int? TicketCountPrediction { get; set; }
        public int? TicketPrice { get; set; }
        public DateTime StartTime { get; set; } = default;
        public DateTime EndTime { get; set; } = default!;
        public DateTime PreparationTime { get; set; } = default!;
        public DateTime CleanUpTime { get; set; } = default!;

        public int? VenueId { get; set; }
        public Venue? Venue { get; set; } 

        public List<VenueEquipment>? VenueEquipment { get; set; }

        public List<Set> Sets { get; set; }
        public List<FestivalEvent>? FestivalEvents { get; set; } = default!;
        public List<Participant>? Participants { get; set; }
    }
}
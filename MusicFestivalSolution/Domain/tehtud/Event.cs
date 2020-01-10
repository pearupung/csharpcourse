using System;
using System.Collections.Generic;

namespace Domain
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        
        public int TicketCountPrediction { get; set; }
        public int TicketPrice { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        
        public TimeSpan PreparationTime { get; set; }
        public TimeSpan CleanUpTime { get; set; }
        
        public int VenueId { get; set; }
        public Venue Venue { get; set; }

        public List<FestivalEvent> FestivalEvents { get; set; }
        public List<Participant> Participants { get; set; }
    }
}
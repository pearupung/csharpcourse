using System;
using System.Collections.Generic;

namespace Domain.Event
{
    public class Festival
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public List<FestivalEvent> FestivalEvents { get; set; }
        
        public string Venue { get; set; }
    }
}
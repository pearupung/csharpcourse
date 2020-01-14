using System;
using System.Collections.Generic;

namespace Domain
{
    public class Festival
    {
        public int FestivalId { get; set; }
        public string FestivalName { get; set; } = default!;
        public string StartTime { get; set; } = default!;
        public string EndTime { get; set; } = default!;
        
        public List<FestivalEvent>? FestivalEvents { get; set; }

        public string Venue { get; set; } = default!;
    }
}
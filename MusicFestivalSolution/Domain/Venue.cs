using System.Collections.Generic;

namespace Domain
{
    public class Venue
    {
        public int VenueId { get; set; }
        
        public string VenueName { get; set; }
        public string VenueAddress { get; set; }
        public int HourlyPrice { get; set; }
        public int SimplePrice { get; set; }

        public List<OrganisedEvent>? Events { get; set; }
    }
}
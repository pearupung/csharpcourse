using System.Collections.Generic;

namespace Domain
{
    public class Venue
    {
        public int VenueId { get; set; }

        public string VenueName { get; set; } = default!;
        public string VenueAddress { get; set; } = default!;
        public int HourlyPrice { get; set; } = default!;
        public int SimplePrice { get; set; } = default!;

        public List<OrganisedEvent>? Events { get; set; }
    }
}
using System.Collections.Generic;

namespace Domain.Venue
{
    public class Venue
    {
        public string VenueName { get; set; }
        public string VenueAddress { get; set; }
        public int HourlyPrice { get; set; }
        public int SimplePrice { get; set; }

        public List<Event.Event> Events { get; set; }
        public List<VenueEquipment> VenueEquipments { get; set; }
    }
}
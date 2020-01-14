using System;

namespace Domain
{
    public class VenueEquipment
    {
        public int VenueEquipmentId { get; set; }
        
        public int EventId { get; set; }
        public OrganisedEvent OrganisedEvent { get; set; }

        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }

        public string ArrivalTime { get; set; }
        public string ArrivalAddress { get; set; }

        public string ReturnTime { get; set; }
        public string ReturnAddress { get; set; }
    }
}
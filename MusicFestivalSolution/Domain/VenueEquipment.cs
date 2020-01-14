using System;
using System.Text;

namespace Domain
{
    public class VenueEquipment
    {
        public int VenueEquipmentId { get; set; }

        public int OrganisedEventId { get; set; } = default!;
        public OrganisedEvent? OrganisedEvent { get; set; }

        public int EquipmentId { get; set; } = default!;
        public Equipment? Equipment { get; set; }

        public string ArrivalTime { get; set; } = default!;
        public string ArrivalAddress { get; set; } = default!;

        public string ReturnTime { get; set; } = default!;
        public string ReturnAddress { get; set; } = default!;
    }
}
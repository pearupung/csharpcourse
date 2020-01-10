using System;

namespace Domain.Venue
{
    public class VenueEquipment
    {
        public int VenueId { get; set; }
        public Venue Venue { get; set; }

        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }

        public DateTime ArrivalTime { get; set; }
        public string ArrivalAddress { get; set; }

        public DateTime ReturnTime { get; set; }
        public string ReturnAddress { get; set; }
    }
}
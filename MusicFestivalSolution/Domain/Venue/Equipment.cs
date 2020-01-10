using System.Collections.Generic;

namespace Domain.Venue
{
    public class Equipment
    {
        public string EquipmentName { get; set; }
        public int EquipmentHourlyPrice { get; set; }

        public Person Lender { get; set; }
        public List<VenueEquipment> VenueEquipments { get; set; }
    }
}
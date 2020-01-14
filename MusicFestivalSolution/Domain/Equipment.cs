using System.Collections.Generic;

namespace Domain
{
    public class Equipment
    {
        public int EquipmentId { get; set; }

        public string EquipmentName { get; set; } = default!;
        public int EquipmentHourlyPrice { get; set; } = default!;

        public Person Lender { get; set; } = default!;
        public List<VenueEquipment>? VenueEquipments { get; set; }
    }
}
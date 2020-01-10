using System.Collections.Generic;

namespace Domain
{
    public class Equipment
    {
        public int EquipmentId { get; set; }
        
        public string EquipmentName { get; set; }
        public int EquipmentHourlyPrice { get; set; }

        public Person Lender { get; set; }
        public List<VenueEquipment> VenueEquipments { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Venue
    {
        [Display(Name = "Venue")]
        public int VenueId { get; set; }

        [Display(Name = "Venue", Prompt = "Enter venue name...")]
        public string VenueName { get; set; } = default!;
        
        [Display(Name = "Address", Prompt = "Enter address...")]
        public string VenueAddress { get; set; } = default!;
        
        [Display(Name = "Hourly Price", Prompt = "Insert hourly price...")]
        public int HourlyPrice { get; set; } = default!;
        
        [Display(Name = "Base Price", Prompt = "Insert base price...")]
        public int SimplePrice { get; set; } = default!;

        public List<OrganisedEvent>? Events { get; set; }
    }
}
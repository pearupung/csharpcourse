using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Domain
{
    public class EventSet
    {

        public int EventSetId { get; set; }
        
        [Display(Name = "Set Name", Prompt = "Enter set name...")]
        public string SetName { get; set; } = default!;

        [Display(Name = "Set Duration", Prompt = "Enter duration...")]
        [NotMapped]
        public int? SetDurationInSeconds => SetTracks?.Select(e => e.ActualPlayTimeInSeconds).Sum();

        // Set Dj
        public int PersonId { get; set; } = default!;
        
        [Display(Name = "DJ", Prompt = "Insert DJ...")]
        public Person? Dj { get; set; }

        public int EventId { get; set; } = default!;
        public OrganisedEvent? Event { get; set; }

        public List<SetTrack>? SetTracks { get; set; }
    }
}
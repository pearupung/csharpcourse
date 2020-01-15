using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class OrganisedEvent
    {
        public int OrganisedEventId { get; set; }
        
        [Display(Name = "Event Name", Prompt = "Enter here event name...")]
        public string EventName { get; set; } = default!;

        [Display(Name = "Ticket Count", Prompt = "Enter here ticket count...")]
        public int TicketCount { get; set; } = default!;
        
        [Display(Name = "Ticket Price", Prompt = "Enter here ticket price...")]
        public int TicketPrice { get; set; } = default!;

        [Display(Name = "Begin Time", Prompt = "hh:mm")]
        public string StartTime { get; set; } = default!;
        
        [Display(Name = "From", Prompt = "mm/dd/yyyy")]
        public string StartDate { get; set; } = default!;
        
        [Display(Name = "End Time", Prompt = "hh:mm")]
        public string EndTime { get; set; } = default!;
        
        [Display(Name = "To", Prompt = "mm/dd/yyyy")]
        public string EndDate { get; set; } = default!;

        [Display(Name = "Preparation Time", Prompt = "h:mm:ss")]
        public string PreparationTime { get; set; } = default!;
        
        [Display(Name = "Clean-Up Time", Prompt = "h:mm:ss")]
        public string CleanUpTime { get; set; } = default!;
        public int VenueId { get; set; } = default!;
        
        [Display(Prompt = "Enter location...")]
        public Venue? Venue { get; set; } 

        public List<VenueEquipment>? VenueEquipment { get; set; }

        public List<EventSet>? Sets { get; set; }
        public List<FestivalEvent>? FestivalEvents { get; set; }
        public List<Participant>? Participants { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Festival
    {
        public int FestivalId { get; set; }
        
        [Display(Name = "Name", Prompt = "Enter festival name here...")]
        public string FestivalName { get; set; } = default!;
        
        [Display(Name = "From", Prompt = "mm/dd/yyyy")]
        public string StartTime { get; set; } = default!;
        [Display(Name = "To", Prompt = "mm/dd/yyyy")]
        public string EndTime { get; set; } = default!;
        
        public List<FestivalEvent>? FestivalEvents { get; set; }

        [Display(Prompt = "Enter festival location here...")]
        public string Venue { get; set; } = default!;
    }
}
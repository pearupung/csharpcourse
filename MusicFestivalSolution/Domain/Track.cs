using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Domain
{
    public class Track
    {
        public int TrackId { get; set; }

        [Display(Name = "Track Name", Prompt = "Insert track name...")]
        public string TrackName { get; set; } = default!;
        
        [Display(Name = "Length in Seconds", Prompt = "Enter track length...")]
        public int LengthInSeconds { get; set; } = default!;

        [Display(Name = "Track Authors")]
        public List<TrackAuthor>? TrackAuthors { get; set; }
       
        public List<SetTrack>? SetTracks { get; set; }
        
    }
}
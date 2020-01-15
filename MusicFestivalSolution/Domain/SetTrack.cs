using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class SetTrack
    {
        public int SetTrackId { get; set; }

        public int QueueNumber { get; set; } = default!;
        public int PlannedPlayTimeInSeconds { get; set; } = default!;
        
        [Display(Name = "Actual PlayTime in Seconds", Prompt = "Enter actual playtime here...")]
        public int ActualPlayTimeInSeconds { get; set; } = default!;

        public int EventSetId { get; set; }
        public EventSet? EventSet { get; set; }

        public int TrackId { get; set; } = default!;
        public Track? Track { get; set; }
    }
}
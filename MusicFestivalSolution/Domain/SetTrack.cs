using System;

namespace Domain
{
    public class SetTrack
    {
        public int SetTrackId { get; set; }
        
        public int QueueNumber { get; set; }
        public int PlannedPlayTimeInSeconds { get; set; }
        public int ActualPlayTimeInSeconds { get; set; }

        public int SetId { get; set; }
        public EventSet EventSet { get; set; }

        public int TrackId { get; set; }
        public Track Track { get; set; }
    }
}
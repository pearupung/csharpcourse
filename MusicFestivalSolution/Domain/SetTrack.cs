using System;

namespace Domain
{
    public class SetTrack
    {
        public int SetTrackId { get; set; }

        public int QueueNumber { get; set; } = default!;
        public int PlannedPlayTimeInSeconds { get; set; } = default!;
        public int ActualPlayTimeInSeconds { get; set; } = default!;

        public int SetId { get; set; } = default!;
        public EventSet? EventSet { get; set; }

        public int TrackId { get; set; } = default!;
        public Track? Track { get; set; }
    }
}
using System;

namespace Domain.Track_sets
{
    public class SetTrack
    {
        public int QueueNumber { get; set; }
        public TimeSpan PlannedPlayTime { get; set; }
        public TimeSpan ActualPlayTime { get; set; }

        public int SetId { get; set; }
        public Set Set { get; set; }

        public int TrackId { get; set; }
        public Track Track { get; set; }
    }
}
using System.Collections.Generic;

namespace Domain
{
    public class PerformerTrack
    {
        public int PerformerTrackId { get; set; }
        
        public List<PerformerTrackRole> PerformerTrackRoles { get; set; }

        public int PerformerId { get; set; }
        public Performer Performer { get; set; }

        public int TrackId { get; set; }
        public Track Track { get; set; }

        public string PerformerTrackName { get; set; }
        public int CostPerSecond { get; set; }
    }
}
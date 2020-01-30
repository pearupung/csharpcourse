using System.Collections.Generic;

namespace Domain
{
    public class Performer
    {
        public int PerformerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<PerformerTrack> PerformerTracks { get; set; }
    }
}
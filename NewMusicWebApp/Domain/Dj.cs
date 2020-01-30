using System.Collections.Generic;

namespace Domain
{
    public class Dj
    {
        public int DjId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<DjTrack> DjTracks { get; set; }
    }
}
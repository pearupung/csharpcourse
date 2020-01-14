using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Track
    {
        public int TrackId { get; set; }

        public string TrackName { get; set; } = default!;
        public int LengthInSeconds { get; set; } = default!;

        public List<TrackAuthor>? TrackAuthors { get; set; }
       
        public List<SetTrack>? SetTracks { get; set; }
    }
}
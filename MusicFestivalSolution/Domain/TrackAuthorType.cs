using System.Collections.Generic;

namespace Domain
{
    public class TrackAuthorType
    {
        public int TrackAuthorTypeId { get; set; }

        public string TrackAuthorTypeName { get; set; } = default!;

        public List<TrackAuthor>? TrackAuthors { get; set; }
    }
}
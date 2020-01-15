using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class TrackAuthorType
    {
        public int TrackAuthorTypeId { get; set; }

        [Display(Name = "Author Type", Prompt = "Enter author type here...")]
        public string TrackAuthorTypeName { get; set; } = default!;

        public List<TrackAuthor>? TrackAuthors { get; set; }
    }
}
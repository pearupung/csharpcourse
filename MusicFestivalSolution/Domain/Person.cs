using System.Collections.Generic;

namespace Domain
{
    public class Person
    {
        public int PersonId { get; set; }
        public string StageName { get; set; }

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;
        public string? IdCode { get; set; }

        public string? CompanyCode { get; set; }
        public string? Address { get; set; }

        public string? PhoneNumber { get; set; } = default!;
        public string? EmailAddress { get; set; } = default!;

        public string? VatSubjectNumber { get; set; }

        public List<Participant>? Participants { get; set; }
        public List<TrackAuthor>? TrackAuthors { get; set; }
    }
}
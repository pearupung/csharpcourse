using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Person
    {
        public int PersonId { get; set; }
        
        [Display(Name = "Stage Name", Prompt = "Enter stage name here...")]
        public string? StageName { get; set; }
        
        [Display(Name = "First Name", Prompt = "Enter first name here...")]

        public string FirstName { get; set; } = default!;

        [Display(Name = "Last Name", Prompt = "Enter last name here...")]
        public string LastName { get; set; } = default!;

        [NotMapped]
        [Display(Name = "Artist")]
        public string LastNameFirstNameStageName => 
            LastName + ", " + FirstName 
            + (string.IsNullOrEmpty(StageName) ? "" :  " | " + StageName);
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
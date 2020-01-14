using System.Collections.Generic;

namespace Domain
{
    public class ParticipantType
    {
        public int ParticipantTypeId { get; set; }
        public string ParticipantTypeName { get; set; } = default!;
        
        public List<Participant>? Participants { get; set; }

        public bool GetsHourly { get; set; } = default!;
        public int HourlyWage { get; set; } = default!;

        public bool GetsFixedSum { get; set; } = default!;
        public int FixedSum { get; set; } = default!;


    }
}
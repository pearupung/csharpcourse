using System.Collections.Generic;

namespace Domain
{
    public class ParticipantType
    {
        public int ParticipantTypeId { get; set; }
        public string ParticipantTypeName { get; set; }
        
        public List<Participant> Participants { get; set; }

        public bool GetsHourly { get; set; }
        public int HourlyWage { get; set; }

        public bool GetsFixedSum { get; set; }
        public int FixedSum { get; set; }
        
        
    }
}
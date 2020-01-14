using System;

namespace Domain
{
    public class Participant
    {
        public int ParticipantId { get; set; } = default!;

        public int ParticipantTypeId { get; set; } = default!;
        public ParticipantType ParticipantType { get; set; }

        public int PersonId { get; set; } = default!;
        public Person Person { get; set; }

        public string ParticipateBeginDate { get; set; }
        public string ParticipateBeginTime { get; set; }
        public string ParticipateEndDate { get; set; }
        public string ParticipateEndTime { get; set; }
        
        
    }
}
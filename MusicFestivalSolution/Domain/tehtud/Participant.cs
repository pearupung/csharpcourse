using System;

namespace Domain
{
    public class Participant
    {
        public int ParticipantId { get; set; }
        
        public int ParticipantTypeId { get; set; }
        public ParticipantType ParticipantType { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }

        public DateTime ParticipateBegin { get; set; }
        public DateTime ParticipateEnd { get; set; }
    }
}
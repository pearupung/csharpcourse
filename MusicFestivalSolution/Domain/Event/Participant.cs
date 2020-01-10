using System;

namespace Domain.Event
{
    public class Participant
    {
        public int ParticipantTypeId { get; set; }
        public ParticipantType ParticipantType { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }

        public DateTime ParticipateBegin { get; set; }
        public DateTime ParticipateEnd { get; set; }
    }
}
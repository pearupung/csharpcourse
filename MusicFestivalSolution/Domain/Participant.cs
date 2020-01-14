using System;

namespace Domain
{
    public class Participant
    {
        public int ParticipantId { get; set; }

        public int ParticipantTypeId { get; set; } = default!;
        public ParticipantType? ParticipantType { get; set; }

        public int PersonId { get; set; } = default!;
        public Person? Person { get; set; }

        public string ParticipateBeginDate { get; set; } = default!;
        public string ParticipateBeginTime { get; set; } = default!;
        public string ParticipateEndDate { get; set; } = default!;
        public string ParticipateEndTime { get; set; } = default!;
    }
}
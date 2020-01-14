namespace Domain
{
    public class FestivalEvent
    {
        public int FestivalEventId { get; set; } = default!;
        public int EventId { get; set; } = default!;
        public OrganisedEvent OrganisedEvent { get; set; }

        public int FestivalId { get; set; } = default!;
        public Festival Festival { get; set; }

        public bool IsIncludedInFestivalPass { get; set; } = default!;

    }
}
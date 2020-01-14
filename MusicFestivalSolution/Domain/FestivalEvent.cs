namespace Domain
{
    public class FestivalEvent
    {
        public int FestivalEventId { get; set; }
        public int OrganisedEventId { get; set; } = default!;
        public OrganisedEvent? OrganisedEvent { get; set; }

        public int FestivalId { get; set; } = default!;
        public Festival? Festival { get; set; }
    }
}
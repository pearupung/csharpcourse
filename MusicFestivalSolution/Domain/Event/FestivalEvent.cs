namespace Domain.Event
{
    public class FestivalEvent
    {
        public int EventId { get; set; }
        public Event Event { get; set; }

        public int FestivalId { get; set; }
        public Festival Festival { get; set; }

        public bool IsIncludedInFestivalPass { get; set; }
        
    }
}
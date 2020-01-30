namespace Domain
{
    public class PerformerTrackRole
    {
        public int PerformerTrackRoleId { get; set; }

        public int PerformerTrackId { get; set; }
        public PerformerTrack PerformerTrack { get; set; }

        public int PerformerRoleId { get; set; }
        public PerformerRole PerformerRole { get; set; }
    }
}
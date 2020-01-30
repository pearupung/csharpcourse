using System.Collections.Generic;

namespace Domain
{
    public class PerformerRole
    {
        public int PerformerRoleId { get; set; }

        public string PerformerRoleName { get; set; }
        public List<PerformerTrackRole> PerformerTrackRoles { get; set; }
    }
}
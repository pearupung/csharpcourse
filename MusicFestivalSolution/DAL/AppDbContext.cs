using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; } = default!;
        public DbSet<OrganisedEvent> Events { get; set; } = default!;
        public DbSet<Festival> Festivals { get; set; } = default!;
        public DbSet<FestivalEvent> FestivalEvents { get; set; } = default!;
        public DbSet<Participant> Participants { get; set; } = default!;
        public DbSet<ParticipantType> ParticipantTypes { get; set; } = default!;
        public DbSet<EventSet> Sets { get; set; } = default!;
        public DbSet<SetTrack> SetTracks { get; set; } = default!;
        public DbSet<Track> Tracks { get; set; } = default!;
        public DbSet<Equipment> Equipments { get; set; } = default!;
        public DbSet<Venue> Venues { get; set; } = default!;
        public DbSet<VenueEquipment> VenueEquipments { get; set; } = default!;
        public DbSet<TrackAuthor> TrackAuthors { get; set; } = default!;
        public DbSet<TrackAuthorType> TrackAuthorTypes { get; set; } = default!;
        
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
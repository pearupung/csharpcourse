using System;
using System.Diagnostics;
using Domain;
using Domain.Event;
using Domain.Track_sets;
using Domain.Venue;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Festival> Festivals { get; set; }
        public DbSet<FestivalEvent> FestivalEvents { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<ParticipantType> ParticipantTypes { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<SetTrack> SetTracks { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<TrackPayRight> TrackPayRights { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<VenueEquipment> VenueEquipments { get; set; }
        
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
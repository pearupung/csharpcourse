using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Dj> Djs { get; set; }
        public DbSet<DjTrack> DjTracks { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<PerformerRole> PerformerRoles { get; set; }
        public DbSet<PerformerTrack> PerformerTracks { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<PerformerTrackRole> PerformerTrackRoles { get; set; }
        public AppDbContext(DbContextOptions options):base(options)
        {
        }
    }
}
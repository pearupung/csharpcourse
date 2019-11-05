using System;
using Domain;
using Game;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Menu> Menus { get; set; } = default!;
        public DbSet<MenuItem> MenuItems { get; set; } = default!;
        public DbSet<MenuItemsInMenu> MenuItemsInMenus { get; set; } = default!;
        public DbSet<Domain.Game> Games { get; set; }
        public DbSet<Move> Moves { get; set; }

        private static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
        {
            //builder.AddConsole();
        });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder
                .UseLoggerFactory(MyLoggerFactory)
                .UseSqlite("Data Source=/home/pearu/Documents/V_SEMESTER/PROGRAMMEERIMINE_CSHARP_KEELES/GIT/mydb.db"));
        }
    }
}
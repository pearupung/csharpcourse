using System;
using System.Net;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Author>? Authors{ get; set; } 
        public DbSet<Book>? Books { get; set; }
        public DbSet<BookAuthor>? BookAuthors { get; set; }
        public DbSet<Language>? Languages { get; set; }
        public DbSet<Publisher>? Publishers { get; set; }
        public DbSet<Review>? Reviews { get; set; }
        
        public AppDbContext(DbContextOptions options):base(options)
        {
        }
    }
}
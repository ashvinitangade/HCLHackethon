using Microsoft.EntityFrameworkCore;
using SharpGaming.Models;
using System.Collections.Generic;

namespace SharpGaming.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<SportModel> Sports { get; set; }
        public DbSet<CountryModel> Countries { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<Selection> Selections { get; set; }
    }
}

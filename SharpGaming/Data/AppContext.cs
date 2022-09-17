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
    }
}

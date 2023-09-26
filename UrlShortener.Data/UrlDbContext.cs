using Microsoft.EntityFrameworkCore;
using UrlShortener.Data.Configurations;
using UrlShortener.Data.Models;

namespace UrlShortener.Data
{
    public class UrlDbContext : DbContext
    {
        public UrlDbContext(DbContextOptions<UrlDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<UrlDb> Urls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UrlConfiguration());

            modelBuilder.AddData();
        }
    }
}

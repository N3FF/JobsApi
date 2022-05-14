using JobsApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JobsApi.Data.Database
{
    public class JobsContext : DbContext
    {
        public JobsContext(DbContextOptions<JobsContext> options) : base(options) { }

        public DbSet<IJobListing> JobListings { get; set; } = null!;
        public DbSet<ImageUri> ImageUris { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IJobListing>()
                .HasMany(j => j.ImageUris)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

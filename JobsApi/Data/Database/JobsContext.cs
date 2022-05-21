using ApiLibrary;

namespace JobsApi.Data.Database
{
    public class JobsContext : DbContext
    {
        public JobsContext(DbContextOptions<JobsContext> options) : base(options) { }

        public DbSet<JobListingDTO> JobListings { get; set; } = null!;
        public DbSet<ImageUriDTO> ImageUris { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobListingDTO>()
                .HasMany(j => j.ImageUris)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

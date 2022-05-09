using JobsApi.Data.Models;

namespace JobsApi.Data.Extensions
{
    public static class JobDbExtensions
    {
        public static IQueryable<JobListing> GetPage(this IQueryable<JobListing> listings, int page, int size)
        {
            page--;
            return listings
                .Skip(page * size)
                .Take(size)
                .Include(j => j.ImageUris);
        }

        public static void Update(this DbSet<JobListing> jobListings, JobListing current, JobListing updated)
        {
            current.Update(updated);
            jobListings.Update(current);
        }

        public async static Task<JobListing?> FindJobAsync(this DbSet<JobListing> jobListings, int id)
        {
            return await jobListings
                                .Include(j => j.ImageUris)
                                .FirstOrDefaultAsync(j => j.Id == id);
        }
    }
}

using JobsApi.Data.Models;

namespace JobsApi.Data.Extensions
{
    public static class JobDbExtensions
    {
        public static IQueryable<IJobListing> GetPage(this IQueryable<IJobListing> listings, int page, int size)
        {
            page--;
            return listings
                .Skip(page * size)
                .Take(size)
                .Include(j => j.ImageUris);
        }

        public static void Update(this DbSet<IJobListing> jobListings, IJobListing current, IJobListing updated)
        {
            current.Update(updated);
            jobListings.Update(current);
        }

        public async static Task<IJobListing?> FindJobAsync(this DbSet<IJobListing> jobListings, int id)
        {
            return await jobListings
                                .Include(j => j.ImageUris)
                                .FirstOrDefaultAsync(j => j.Id == id);
        }

        public async static Task<IQueryable<IJobListing>> SearchTitleAsync(this DbSet<IJobListing> jobListings, string search)
        {
            return await Task.Run(()=> jobListings); //Find way to search titles
        }
    }
}
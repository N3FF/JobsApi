using ApiLibrary;

namespace JobsApi.Data.Extensions
{
    public static class JobDbExtensions
    {
        public static IQueryable<JobListingDTO> GetPage(this IQueryable<JobListingDTO> listings, int page, int size)
        {
            page--;
            return listings
                .Skip(page * size)
                .Take(size)
                .Include(l => l.ImageUris);
        }

        public static void Update(this DbSet<JobListingDTO> listings, JobListingDTO current, JobListingDTO updated)
        {
            current.Update(updated);
            listings.Update(current);
        }

        public async static Task<JobListingDTO?> FindListingAsync(this DbSet<JobListingDTO> listings, int id)
        {
            return await listings
                                .Include(l => l.ImageUris)
                                .FirstOrDefaultAsync(l => l.Id == id);

        }
    }
}
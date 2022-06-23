using ApiLibrary;

namespace JobsApi.Data.Extensions
{
    public static class JobDbExtensions
    {
        public static IQueryable<JobListingDTO> GetPage(this IQueryable<JobListingDTO> listings, int pageNumber, int pageSize)
        {
            pageNumber--;
            return listings
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .Include(l => l.ImageUris);
        }

        public static void Update(this DbSet<JobListingDTO> listings, JobListingDTO currentListing, JobListingDTO updatedListing)
        {
            currentListing.Update(updatedListing);
            listings.Update(currentListing);
        }

        public async static Task<JobListingDTO?> FindListingAsync(this DbSet<JobListingDTO> listings, int id)
        {
            return await listings
                                .Include(l => l.ImageUris)
                                .FirstOrDefaultAsync(l => l.Id == id);

        }
    }
}
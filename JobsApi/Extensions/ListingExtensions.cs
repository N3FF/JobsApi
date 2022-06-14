using ApiLibrary;

namespace JobsApi.Data.Extensions
{
    public static class ListingExtensions
    {
        public static void Update(this JobListingDTO listing, JobListingDTO update)
        {
            listing.Title = update.Title;
            listing.Description = update.Description;
            listing.Categories = update.Categories;
            listing.Location = update.Location;
            listing.ContactInfo = update.ContactInfo;
            listing.ImageUris = update.ImageUris;
        }
    }
}

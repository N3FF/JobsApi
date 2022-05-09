using JobsApi.Data.Models;

namespace JobsApi.Data.Extensions
{
    public static class ListingExtensions
    {
        public static void Update(this JobListing listing, JobListing update)
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

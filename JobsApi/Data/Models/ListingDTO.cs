using System.ComponentModel.DataAnnotations;

namespace JobsApi.Data.Models
{
    [Serializable]
    public class ListingDTO
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(75)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(5000)]
        public string Description { get; set; } = string.Empty;

        public List<string> Images { get; set; } = new();

        public DateTime ListingTime { get; set; }

        public string Location { get; set; } = string.Empty;

        public string ContactInfo { get; set; } = string.Empty;
    }
}

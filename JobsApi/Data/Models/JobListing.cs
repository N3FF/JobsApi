using JobsApi.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobsApi.Data.Models
{
    [Serializable]
    public class JobListing
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(75)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(5)]
        public string Description { get; set; } = null!;

        public ICollection<ImageUri> ImageUris { get; set; } = new List<ImageUri>();

        [Required]
        public DateTime ListingTime { get; set; }

        [Required]
        public int ListingDuration { get; set; }

        public string? Location { get; set; }

        public string? ContactInfo { get; set; }

        public PostCategories Categories { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace JobsApi.Data.Models
{
    public class ImageUri
    {
        [Key]
        public int Id { get; set; }
        public string Uri { get; set; } = null!;
    }
}

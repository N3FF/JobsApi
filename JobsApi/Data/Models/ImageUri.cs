using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobsApi.Data.Models
{
    public class ImageUri
    {
        [Key]
        public int Id { get; set; }
        public string Uri { get; set; }
    }
}

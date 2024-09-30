using System.ComponentModel.DataAnnotations;

namespace web_api.Models
{
    public class Photo : BaseEntity
    {
        [Required]
        public string ImageUrl { get; set; }
        public bool IsPrimary { get; set; }

        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
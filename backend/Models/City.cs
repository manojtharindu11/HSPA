using System.ComponentModel.DataAnnotations;

namespace web_api.Models
{
    public class City : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Country { get; set; } = string.Empty;
    }
}

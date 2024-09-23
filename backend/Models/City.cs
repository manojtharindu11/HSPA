using System.ComponentModel.DataAnnotations;

namespace web_api.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Country { get; set; } = string.Empty;

        public DateTime LastUpdatedOn { get; set; }
        public int LastUpdatedBy { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace web_api.Models
{
    public class FurnishingType : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
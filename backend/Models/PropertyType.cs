using System.ComponentModel.DataAnnotations;

namespace web_api.Models
{
    public class PropertyType : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
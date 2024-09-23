using System.ComponentModel.DataAnnotations;

namespace web_api.DTOs
{
    public class CityDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is mandatory field")]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(".*[a-zA-Z]+.*", ErrorMessage ="Only numerics are not allowed")]

        public string Name { get; set; } = string.Empty;
        [Required]
        public string Country { get; set; } = string.Empty;

    }
}

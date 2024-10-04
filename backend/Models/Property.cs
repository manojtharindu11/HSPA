using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api.Models
{
    public class Property : BaseEntity
    {
        public int SellRent { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("PropertyType")]
        public int PropertyTypeId { get; set; }
        public PropertyType PropertyType { get; set; }

        public int BHK { get; set; }

        [ForeignKey("FurnishingType")]
        public int FurnishingTypeId { get; set; }
        public FurnishingType FurnishingType { get; set; }

        public int Price { get; set; }
        public int BuiltArea { get; set; }
        public int CarpetArea { get; set; }

        [Required]
        public string Address { get; set; }

        public string Address2 { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }
        public City City { get; set; }

        public int FloorNo { get; set; }
        public int TotalFloors { get; set; } // Fixed typo

        public bool ReadyToMove { get; set; }
        public string? MainEntrance { get; set; }

        public int? Security { get; set; }
        public bool Gated { get; set; }
        public int? Maintenance { get; set; }

        public DateTime? EstPossessionOn { get; set; } // Made nullable

        public int? Age { get; set; }
        public string Description { get; set; }

        public ICollection<Photo> Photos { get; set; }

        public DateTime PostedOn { get; set; } = DateTime.Now;

        [ForeignKey("User")]
        public int PostedBy { get; set; }
        public User User { get; set; }
    }
}

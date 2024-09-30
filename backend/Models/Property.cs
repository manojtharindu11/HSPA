﻿using System.ComponentModel.DataAnnotations.Schema;

namespace web_api.Models
{
    public class Property
    {
        public int Id { get; set; }
        public int SellRent { get; set; }
        public string Name { get; set; }
        public int PropertyTypeId { get; set; }
        public PropertyType propertyType { get; set; }
        public int BHK { get; set; }
        public int FurnishingTypeId { get; set; }

        public FurnishingType furnishingType { get; set; }
        public int Price { get; set; }
        public int BuiltArea { get; set; }
        public int CarpetArea { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public int CityId { get; set; }
        public City city { get; set; }
        public int FloorNo { get; set; }
        public int TotalFoolrs { get; set; }
        public bool ReadyToMove { get; set; }
        public string MainEntrance { get; set; }
        public int Security { get; set; }
        public int Gated { get; set; }
        public int Maintenance { get; set; }
        public DateTime EstPossessionOn { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }

        public ICollection<Photo> Photos { get; set; }
        public DateTime PostedOn { get; set; } = DateTime.Now;
        [ForeignKey("User")]
        public int PostedBy { get; set; }
        public User user { get; set; }

    }
}

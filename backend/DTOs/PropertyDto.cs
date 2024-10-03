﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using web_api.Models;

namespace web_api.DTOs
{
    public class PropertyDto
    {
        public int SellRent { get; set; }
        public string Name { get; set; }
        public int PropertyTypeId { get; set; }
        public int BHK { get; set; }
        public int FurnishingTypeId { get; set; }
        public int Price { get; set; }
        public int BuiltArea { get; set; }
        public int CarpetArea { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public int CityId { get; set; }
        public int FloorNo { get; set; }
        public int TotalFloors { get; set; }
        public bool ReadyToMove { get; set; }
        public string MainEntrance { get; set; }
        //public int Security { get; set; }
        public int Gated { get; set; }
        //public int Maintenance { get; set; }
        public DateTime? EstPossessionOn { get; set; }
        //public int Age { get; set; }
        public string Description { get; set; }
    }
}
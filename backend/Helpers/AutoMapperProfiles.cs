using AutoMapper;
using web_api.DTOs;
using web_api.Models;

namespace web_api.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<City, CityDTO>().ReverseMap();
            CreateMap<City, CityUpdateDTO>().ReverseMap();
        }
    }
}

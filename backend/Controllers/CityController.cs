using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using web_api.DTOs;
using web_api.Interfaces;
using web_api.Models;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public CityController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _unitOfWork.cityReopository.GetCitiesAsync();

            var citiesDTO = mapper.Map<IEnumerable<City>>(cities);

            //var citiesDTO = from c in cities
            //                select new CityDTO()
            //                {
            //                    Id = c.Id,
            //                    Name = c.Name,
            //                };

            if (citiesDTO.Any())
            {
                return Ok(citiesDTO);
            }
            return BadRequest("Cities not found");
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Atlanta";
        }

        //[HttpPost("add")]
        //[HttpPost("add/{cityName}")]

        //public async Task<IActionResult> AddCity(string cityName)
        //{
        //    City city = new City();
        //    city.Name = cityName;
        //    _unitOfWork.cityReopository.AddCity(city);
        //    await _unitOfWork.SaveAsync();
        //    return Ok(city);
        //}

        [HttpPost("post")]


        public async Task<IActionResult> AddCity(CityDTO cityDto)
        {
            //var city = new City
            //{
            //    Name = cityDto.Name,
            //    LastUpdatedBy = 1,
            //    LastUpdatedOn = DateTime.Now
            //};

            var city = mapper.Map<City>(cityDto);
            city.LastUpdatedBy = 1;
            city.LastUpdatedOn = DateTime.Now;

            _unitOfWork.cityReopository.AddCity(city);
            await _unitOfWork.SaveAsync();
            return StatusCode(201);
        }

        [HttpDelete("delete{id}")]


        public async Task<IActionResult> DeleteCity(int id)
        {
            _unitOfWork.cityReopository.DeleteCity(id);
            await _unitOfWork.SaveAsync();
            return Ok(id);
        }
    }
}

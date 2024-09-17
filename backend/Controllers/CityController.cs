using Microsoft.AspNetCore.Mvc;
using web_api.Data.Repo;
using web_api.Models;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityReopository _cityReopository;

        public CityController(ICityReopository cityReopository)
        {
            _cityReopository = cityReopository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _cityReopository.GetCitiesAsync();
            if (cities.Any())
            {
                return Ok(cities);
            }
            return BadRequest("Cities not found");
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Atlanta";
        }

        [HttpPost("add")]
        [HttpPost("add/{cityName}")]

        public async Task<IActionResult> AddCity(string cityName)
        {
            City city = new City();
            city.Name = cityName;
            _cityReopository.AddCity(city);
            await _cityReopository.SaveAsync();
            return Ok(city);
        }

        [HttpPost("post")]


        public async Task<IActionResult> AddCity(City city)
        {
            _cityReopository.AddCity(city);
            await _cityReopository.SaveAsync();
            return StatusCode(201);
        }

        [HttpDelete("delete{id}")]


        public async Task<IActionResult> DeleteCity(int id)
        {
            _cityReopository.DeleteCity(id);
            await _cityReopository.SaveAsync();
            return Ok(id);
        }
    }
}

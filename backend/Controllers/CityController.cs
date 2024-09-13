using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api.Data;
using web_api.Models;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private  readonly DataContext _dataContext;

        public CityController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _dataContext.Cities.ToListAsync();
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
            await _dataContext.Cities.AddAsync(city);
            await _dataContext.SaveChangesAsync();
            return Ok(city);
        }

        [HttpPost("post")]


        public async Task<IActionResult> AddCity(City city)
        {
            await _dataContext.Cities.AddAsync(city);
            await _dataContext.SaveChangesAsync();
            return Ok(city);
        }

        [HttpDelete("delete{id}")]


        public async Task<IActionResult> DeleteCity(int id)
        {
            var city = await _dataContext.Cities.FindAsync(id);
            _dataContext.Cities.Remove(city);
            await _dataContext.SaveChangesAsync();
            return Ok(city);
        }
    }
}

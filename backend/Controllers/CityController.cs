using Microsoft.AspNetCore.Mvc;
using web_api.Interfaces;
using web_api.Models;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _unitOfWork.cityReopository.GetCitiesAsync();
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
            _unitOfWork.cityReopository.AddCity(city);
            await _unitOfWork.SaveAsync();
            return Ok(city);
        }

        [HttpPost("post")]


        public async Task<IActionResult> AddCity(City city)
        {
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

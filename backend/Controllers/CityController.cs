using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api.Data;

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
        public IActionResult GetCities()
        {
            var cities = _dataContext.Cities.ToList();
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
    }
}

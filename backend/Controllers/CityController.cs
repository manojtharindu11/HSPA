using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using web_api.DTOs;
using web_api.Interfaces;
using web_api.Models;

namespace web_api.Controllers
{
    [Authorize]
    public class CityController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public CityController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [AllowAnonymous]
        [HttpGet]

        public async Task<IActionResult> GetCities()
        {
            var cities = await _unitOfWork.cityReopository.GetCitiesAsync();

            var citiesDTO = mapper.Map<IEnumerable<CityDto>>(cities);

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
        public async Task<IActionResult> AddCity(CityDto cityDto)
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

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCity(int id, CityDto cityDto)
        {
            try
            {
                if (id != cityDto.Id)
                {
                    return BadRequest("Update not allowed");

                }

                var cityFromDB = await _unitOfWork.cityReopository.FindCity(id);

                if (cityFromDB == null)
                    return BadRequest("Update not allowed");


                cityFromDB.LastUpdatedBy = 1;
                cityFromDB.LastUpdatedOn = DateTime.Now;
                mapper.Map(cityDto, cityFromDB);


                throw new Exception("Unknown error occured");
                await _unitOfWork.SaveAsync();
                return StatusCode(200);

            } catch
            {
                return StatusCode(500, "Some unknow error occured");
            }
        }

        [HttpPut("updateName/{id}")]
        public async Task<IActionResult> UpdateCityName(int id, CityUpdateDto cityDto)
        {
            var cityFromDB = await _unitOfWork.cityReopository.FindCity(id);
            cityFromDB.LastUpdatedBy = 1;
            cityFromDB.LastUpdatedOn = DateTime.Now;
            mapper.Map(cityDto, cityFromDB);
            await _unitOfWork.SaveAsync();
            return StatusCode(200);
        }

        //[HttpPatch("update/{id}")]
        //public async Task<IActionResult> UpdateCityPatch(int id, [FromBody] JsonPatchDocument<City> cityToPatch)
        //{
        //    // Find the city in the database
        //    var cityFromDB = await _unitOfWork.cityReopository.FindCity(id);

        //    // If the city doesn't exist, return 404 Not Found
        //    if (cityFromDB == null)
        //    {
        //        return NotFound();
        //    }

        //    cityToPatch.ApplyTo(cityFromDB, ModelState);

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    cityFromDB.LastUpdatedBy = 1;  // Set the user who updated the entity
        //    cityFromDB.LastUpdatedOn = DateTime.Now;  // Set the current time as last updated time

        //    await _unitOfWork.SaveAsync();

        //    return Ok();
        //}




        [HttpDelete("delete{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            _unitOfWork.cityReopository.DeleteCity(id);
            await _unitOfWork.SaveAsync();
            return Ok(id);
        }
    }
}

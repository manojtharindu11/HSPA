using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api.DTOs;
using web_api.Interfaces;
using web_api.Models;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : BaseController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PropertyController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpGet("list/{sellRent}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPropertyList(int sellRent)
        {
            var properties = await unitOfWork.propertyRepository.GetAllPropertiesAsync(sellRent);
            var propertyLIstDto = mapper.Map<IEnumerable<PropertyListDto>>(properties);
            return Ok(propertyLIstDto);
        }

        [HttpGet("detail/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPropertyDetail(int id)
        {
            var property = await unitOfWork.propertyRepository.GetPropertyDetailAsync(id);
            var propertyDto = mapper.Map<PropertyDetailDto>(property);
            return Ok(propertyDto);
        }

        [HttpPost("add")]
        [AllowAnonymous]
        public async Task<IActionResult> AddProperty(PropertyDto propertyDto)
        {
            var property = mapper.Map<Property>(propertyDto);
            property.PostedBy = 2;
            property.LastUpdatedBy = 2;
            unitOfWork.propertyRepository.AddProperty(property);
            await unitOfWork.SaveAsync();
            return StatusCode(201);
        }
    }
}

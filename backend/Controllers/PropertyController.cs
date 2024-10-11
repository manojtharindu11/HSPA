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
        private readonly IPhotoService photoService;

        public PropertyController(IUnitOfWork unitOfWork,IMapper mapper, IPhotoService photoService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.photoService = photoService;
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
        [Authorize]
        public async Task<IActionResult> AddProperty(PropertyDto propertyDto)
        {
            var property = mapper.Map<Property>(propertyDto);
            var userId = GetUserId();
            property.PostedBy = userId;
            property.LastUpdatedBy = userId;
            unitOfWork.propertyRepository.AddProperty(property);
            await unitOfWork.SaveAsync();
            return StatusCode(201);
        }

        [HttpPost("add/photo/{id}")]
        [Authorize]
        public async Task<IActionResult> AddPropertyPhoto(IFormFile photo,int propertyId)
        {
            var result = photoService.UploadImageAsync(photo);
            if (result.Exception != null)
            {
                return BadRequest(result.Exception.Message);
            }
            return Ok(201);
        }
    }
}

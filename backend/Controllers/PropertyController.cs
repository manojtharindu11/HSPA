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

        [HttpPost("add/photo/{propertyId}")]
        [Authorize]
        public async Task<IActionResult> AddPropertyPhoto(IFormFile file,int propertyId)
        {
            var result = await photoService.UploadImageAsync(file);
            if (result.Error != null)
            {
                return BadRequest(result.Error.Message);
            }
            var property = await unitOfWork.propertyRepository.GetPropertyByIdAsync(propertyId);

            var photo = new Photo
            {
                ImageUrl = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            if (property.Photos.Count == 0)
            {
                photo.IsPrimary = true;
            }

            property.Photos.Add(photo);
            await unitOfWork.SaveAsync();

            return StatusCode(201);
        }


        [HttpPost("set-primary-photo/{propertyId}/{publicPhotoId}")]
        [Authorize]
        public async Task<IActionResult> setPrimaryPhoto(int propertyId, string publicPhotoId)
        {
            var userId = GetUserId();

            var property = await unitOfWork.propertyRepository.GetPropertyByIdAsync(propertyId);



            if (property == null)
            {
                return BadRequest("No such property or photo exists");
            }

            if (property.PostedBy != userId)
            {
                return BadRequest("You are not authorized to change the photo");
            }

            var photo = property.Photos.FirstOrDefault(p => p.PublicId == publicPhotoId);

            if (photo == null)
            {
                return BadRequest("No such property or photo exists");
            }

            if (photo.IsPrimary)
            {
                return BadRequest("This is already a primary photo");
            }

            var currentPrimaryPhoto = property.Photos.FirstOrDefault(p => p.IsPrimary);
            if (currentPrimaryPhoto != null)
            {
                currentPrimaryPhoto.IsPrimary = false;
                photo.IsPrimary = true;
            }

            if (await unitOfWork.SaveAsync()) return NoContent();

            return BadRequest("Some error has occured, failed to set primary photo");
        }

        [HttpDelete("delete-photo/{propertyId}/{publicPhotoId}")]
        [Authorize]
        public async Task<IActionResult> deletePhoto(int propertyId, string publicPhotoId)
        {
            var userId = GetUserId();

            var property = await unitOfWork.propertyRepository.GetPropertyByIdAsync(propertyId);



            if (property == null)
            {
                return BadRequest("No such property or photo exists");
            }

            if (property.PostedBy != userId)
            {
                return BadRequest("You are not authorized to delete the photo");
            }

            var photo = property.Photos.FirstOrDefault(p => p.PublicId == publicPhotoId);

            if (photo == null)
            {
                return BadRequest("No such property or photo exists");
            }

            if (photo.IsPrimary)
            {
                return BadRequest("You can not delete the primary photo");
            }

            var result = await photoService.DeletePhotoAsync(photo.PublicId);

            if (result.Error != null)
            {
                return BadRequest(result.Error.Message);
            }

            property.Photos.Remove(photo);

            if (await unitOfWork.SaveAsync()) return Ok();

            return BadRequest("Some error has occured, failed to delete photo");
        }
    }
}

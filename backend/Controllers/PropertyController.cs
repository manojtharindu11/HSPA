using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api.DTOs;
using web_api.Interfaces;

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
        [HttpGet("type/{sellRent}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPropertyList(int sellRent)
        {
            var properties = await unitOfWork.propertyRepository.GetAllPropertiesAsync(sellRent);
            var propertyLIstDto = mapper.Map<IEnumerable<PropertyListDto>>(properties);
            return Ok(propertyLIstDto);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api.DTOs;
using web_api.Interfaces;

namespace web_api.Controllers
{
    public class PropertyTypeController : BaseController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PropertyTypeController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet("list")]
        [AllowAnonymous]

        public async Task<IActionResult> GetPropertyTypes()
        {
            var propertyTypes = await unitOfWork.propertyTypeRepository.GetPropertyTypeAsync();
            var propertyTypesDto = mapper.Map<IEnumerable<KeyValuePairDto>>(propertyTypes);
            return Ok(propertyTypesDto);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using web_api.DTOs;
using web_api.Interfaces;
using web_api.Models;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration configuration;

        public AccountController(IUnitOfWork unitOfWork,IConfiguration configuration)
        {
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
        }

        //api/acount/register
        [HttpPost("register")]
        public async Task<IActionResult> Register(LoginReqDto loginReqDto)
        {
            if (await unitOfWork.userRepository.UserAlreadyExist(loginReqDto.Username))
            {
                return BadRequest("User already exists, Please try something else");
            }

            unitOfWork.userRepository.Register(loginReqDto.Username, loginReqDto.Password);
            await unitOfWork.SaveAsync();
            return StatusCode(201);
        }

        //api/acount/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginReqDto loginReqDto)
        {
            var user = await unitOfWork.userRepository.Authenticate(loginReqDto.Username, loginReqDto.Password);

            if (user == null)
            {
                return Unauthorized("Invalid userId or password!");
            }

            var loginResDto = new LoginResDto();
            loginResDto.UserName = user.UserName;
            loginResDto.Token = CreateJWT(user);

            return Ok(loginResDto);
        }

        private string CreateJWT(User user)
        {
            var secreateKey = configuration.GetSection("AppSettings:Key").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secreateKey));

            var clams = new Claim[]
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            };

            var signingCredentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(clams),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}

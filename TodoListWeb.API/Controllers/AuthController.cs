using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TodoListWeb.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using TodoListWeb.API.Dtos;
using TodoListWeb.API.Models;

namespace ElearningWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public AuthController(IAuthRepository repo, IConfiguration config, IMapper mapper)
        {
            _config = config;
            _mapper = mapper;
            _repo = repo;

        }

        // Register User 
        // forAdmin RoleId: 2 
        // ForUser RoleId: 1;


        // /api/Auth/register

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDtos userForRegisterDto)
        {
            if (userForRegisterDto == null)
                return BadRequest();

            if (await _repo.IsUserExists(userForRegisterDto.Email))
                return BadRequest("User already Exist");


            var userToCreate = _mapper.Map<Users>(userForRegisterDto);

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);
            var userToReturn = _mapper.Map<UserForReturnDtos>(userToCreate);
            /* 
            return CreatedAtRoute("GetUser", new{Controller = "Users", id =userToCreate.Id}, userToReturn); */

            return Ok(userToReturn);
        }

        // Login by email & password
        // /api/Auth/register

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDtos userForLoginDto)
        {
            var userFromRepo = await _repo.Login(userForLoginDto.Email, userForLoginDto.Password);

            if (userFromRepo == null)
                return Unauthorized();

           
           var token = GenerateToken(userFromRepo.Name, userFromRepo.Role.RoleName);
            var user = _mapper.Map<UserForReturnDtos>(userFromRepo);

            return Ok(new 
            {
                token,
                user
            });
        }

        private string GenerateToken(string name, string role)
        {
             var claims = new[]
            {
                // new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var a = tokenHandler.WriteToken(token);

            HttpContext.Session.SetString("token",a);

            return a;
        }
    }
    }
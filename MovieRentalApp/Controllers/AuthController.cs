//using AutoMapper.Configuration;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MovieRentalApp.Data;
using MovieRentalApp.Dtos;
using MovieRentalApp.Interfaces;
using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public AuthController(IAuthRepository repo, IConfiguration config, IMapper mapper)
        {
            _repo = repo;
            _config = config;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.AUsername = userForRegisterDto.AUsername.ToLower();

            if (await _repo.UserExists(userForRegisterDto.AUsername))
                return BadRequest("username already exists");

            var userToCreate = _mapper.Map<TblUser>(userForRegisterDto);

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            var userToReturn = _mapper.Map<UserForDetailedDto>(createdUser);

            return CreatedAtRoute("GetUser", new
            {
                controller = "Users",
                id = createdUser.ACustomerId
            }, userToReturn
            );
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {

                var userFromRepo = await _repo.Login(userForLoginDto.AUsername.ToLower(), userForLoginDto.Password.ToLower());
                if (userFromRepo == null)
                {
                    return Unauthorized();
                }
                var claims = new[]
                {
                new Claim(ClaimTypes.NameIdentifier,userFromRepo.ACustomerId.ToString()),
                new Claim(ClaimTypes.Name,userFromRepo.AUsername)
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(10),
                    SigningCredentials = creds
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return Ok(
                    new
                    {
                        token = tokenHandler.WriteToken(token)
                    }
                    );

        }
    }
}

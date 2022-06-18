using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using TravelMoreAPI.Data;
using TravelMoreAPI.Entities;
using TravelMoreAPI.Models.Dtos;
using TravelMoreAPI.Repositories;

namespace TravelMoreAPI.Controllers
{

    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserController(UserDbContext context, IUserRepository repository, IConfiguration configuration)
        {
            _context = context;
            _userRepository = repository;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(UserDto userDto)
        {
            PasswordProcessing.CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User()
            {
                UserId = new Guid(),
                UserName = userDto.UserName,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };

            _userRepository.AddUser(user);

            return Ok(User);
        }


        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UserLoginDto request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(m => m.UserName == request.UserName);
            if (user == null)
            {
                return BadRequest("UserName not found");
            }
            if (!PasswordProcessing.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong Password");
            }

            string token = CreateToken(user);

            return Ok(token);
        }



        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return _userRepository.GetUsers();
        }


        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = _userRepository.GetUserById(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Patch(Guid id,[FromBody] JsonPatchDocument<User> userEntity)
        {
            var entity = _context.Users.FirstOrDefault(User => User.UserId == id);
           
            if (entity == null) return NotFound("User not found");

            userEntity.ApplyTo(entity, ModelState);

            return Ok(entity);  
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update (Guid id, User user)
        {
            if (id != user.UserId) return BadRequest();

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent(); 
        }
        

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userToDelete = await _context.Users.FindAsync(id);
            if (userToDelete == null) return NotFound();

            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("userName", user.UserName)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                    _configuration.GetSection("Appsettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    } 
}

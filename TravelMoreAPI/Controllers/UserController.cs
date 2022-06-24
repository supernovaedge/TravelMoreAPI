using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly ITokenCreationService _tokenCreationService;

        public UserController(UserDbContext context, IUserRepository repository, ITokenCreationService tokenCreationService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            _tokenCreationService = tokenCreationService ?? throw new ArgumentNullException(nameof(tokenCreationService));
        }

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<User> Create(UserDto userDto)
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
                UserPicture = userDto.UserPicture,
            };

            /*
            if (_userRepository.UsernameUniqueValidation(user.UserName))
            {
                return BadRequest("Username already in use");
            }

            if (_userRepository.EmailUniqueValidation(user.Email))
            {
                return BadRequest("Email already in use");
            }


            _userRepository.AddUser(user);


            return Ok("User Created");
            */
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

            string token = _tokenCreationService.CreateToken(user);

            return Ok(token);
        }



        [HttpGet("GetAllUsers")]
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

    } 
}

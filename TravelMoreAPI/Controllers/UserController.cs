using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet("void")]
        public string returnString()
        {
            return "this is test";
        }

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<User> Create(UserDto userDto)
        {
            PasswordProcessing.CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var newGuid = Guid.NewGuid();
            var user = new User()
            {
                UserId = newGuid,
                UserName = userDto.UserName.ToLower(),
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email.ToLower(),
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                UserPicture = new UserPicture64 {UserId = newGuid, UserPicture = userDto.UserPictureBase64, UserHeader = userDto.UserPictureHeader }
            };

            var usernameOwner = _userRepository.GetUserByUsername(userDto.UserName);
            if (usernameOwner != null)
            {
                return BadRequest("Username already in use");
            }

            var emailOwner = _userRepository.GetUserByEmail(userDto.Email);
            if (emailOwner != null)
            {
                return BadRequest("Email already in use");
            }


            _userRepository.AddUser(user);


            return Ok("user created");
            
        }
         

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UserLoginDto request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(m => m.UserName == request.UserName.ToLower());
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

        [Authorize]
        [HttpPost("ChangeEmail")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<User> ChangeEmail(EmailDto emailDto)
        {

            var entity = _userRepository.GetUserById(emailDto.UserId);
            if (entity == null)
            {
                return BadRequest("User not found");
            }


            var emailOwner = _userRepository.GetUserByEmail(emailDto.NewEmail.ToLower());
            if (emailOwner != null)
            {
                return BadRequest("Email already in use");
            }


            entity.Email = emailDto.NewEmail.ToLower();

            _userRepository.SaveChanges();

            return Ok("Email changed Sucessfully");
        }

        [Authorize]
        [HttpPost("ChangeUserName")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<User> ChangeUserName(UserNameDto userNameDto)
        {

            var entity = _userRepository.GetUserById(userNameDto.UserId);
            if (entity == null)
            {
                return BadRequest("User not found");
            }


            var userNameOwner = _userRepository.GetUserByUsername(userNameDto.NewUserName.ToLower());
            if (userNameOwner != null)
            {
                return BadRequest("UserName already in use");
            }


            entity.UserName = userNameDto.NewUserName.ToLower();

            _userRepository.SaveChanges();

            return Ok("UserName changed Sucessfully");
        }

        [Authorize]
        [HttpPost("ChangePassword")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<User> ChangePassword(PasswordDto passwordDto)
        {

            var entity = _userRepository.GetUserById(passwordDto.UserId);
            if (entity == null)
            {
                return BadRequest("User not found");
            }

            PasswordProcessing.CreatePasswordHash(passwordDto.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);

            entity.PasswordHash = passwordHash;
            entity.PasswordSalt = passwordSalt;
            
            _userRepository.SaveChanges();

            return Ok("Password changed Sucessfully");
        }



        [HttpGet("GetAllUsers")]
        public async Task<IEnumerable<User>> Get()
        {
            return _userRepository.GetUsers();
        }

        [AllowAnonymous]
        [HttpGet("GetUserProfile/{id:guid}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUserProfileById(Guid id)
        {
            var profile = _userRepository.GetUserProfileById(id);

            return profile == null ? NotFound() : Ok(profile);
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

            var entity = _userRepository.GetUserById(id);
           
            if (entity == null) return NotFound("User not found");

            userEntity.ApplyTo(entity, ModelState);

            _userRepository.SaveChanges(); 

            return Ok("Change was Sucessful");  
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update (Guid id, User user)
        {
            if (id != user.UserId) return BadRequest("Bad Request");

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent(); 
        }
        

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userToDelete = _userRepository.GetUserById(id);
            if (userToDelete == null) return NotFound("User not found");

            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    } 
}

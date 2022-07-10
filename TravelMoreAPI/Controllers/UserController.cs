using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TravelMoreAPI.Entities;
using TravelMoreAPI.Models.Dtos;
using TravelMoreAPI.Services.UserService;

namespace TravelMoreAPI.Controllers
{

    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }


        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult CreateUser(UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }

            var newUserId = _userService.CreateUser(userDto);
            return Created($"https://localhost:7043/api/User/Register", newUserId);         
        }
         

        [HttpPost("Login")]
        public ActionResult Login(UserLoginDto request)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            var token = _userService.Login(request);
            return token == null ? Unauthorized() : Ok(token);
        }
        
        

        [Authorize]
        [HttpPost("ChangeEmail")]
        public ActionResult ChangeEmail(EmailDto emailDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }

            var claimId = User.Claims.FirstOrDefault(x => x.Type == "UserId")!.Value;
            if (claimId != emailDto.UserId.ToString())
            {
                return Forbid();
            }

            var newEmail = _userService.ChangeEmail(emailDto);
            return newEmail == null ? BadRequest() : Ok(newEmail);
        }


        [Authorize]
        [HttpPost("ChangeUserName")]
        public ActionResult ChangeUsername(UserNameDto userNameDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }

            var claimId = User.Claims.FirstOrDefault(x => x.Type == "UserId")!.Value;
            if (claimId != userNameDto.UserId.ToString())
            {
                return Forbid();
            }

            var newUsername = _userService.ChangeUsername(userNameDto);

            return newUsername == null ? BadRequest() : Ok(newUsername);
        }


        [Authorize]
        [HttpPost("ChangePassword")]
        public ActionResult<User> ChangePassword(PasswordDto passwordDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }

            var claimId = User.Claims.FirstOrDefault(x => x.Type == "UserId")!.Value;
            if (claimId != passwordDto.UserId.ToString())
            {
                return Forbid();
            }

            var status = _userService.ChangePassword(passwordDto);
            return status == false ? BadRequest() : NoContent();
        }

        [Authorize]
        [HttpGet("GetUserProfile/{id:guid}")]
        public ActionResult GetUserProfileById(Guid id)
        {
            var claimId = User.Claims.FirstOrDefault(x => x.Type == "UserId")!.Value;
            if (claimId != id.ToString())
            {
                return Forbid();
            }
            var profile = _userService.GetUserProfileById(id);

            return profile == null ? NotFound() : Ok(profile);
        }


        /*
        [HttpGet("GetAllUsers")]
        public async Task<IEnumerable<User>> Get()
        {
            return _userRepository.GetUsers();
        }
        */
    } 
}

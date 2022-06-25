using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TravelMoreAPI.Entities;
using TravelMoreAPI.Models.Dtos;
using TravelMoreAPI.Repositories;

namespace TravelMoreAPI.Controllers
{
    
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IGuestRepository _guestRepository;
        private readonly IBookingRepository _bookingRepository;

        public GuestController(IGuestRepository guestRepository, IUserRepository userRepository, IBookingRepository bookingRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _guestRepository = guestRepository ?? throw new ArgumentNullException(nameof(guestRepository));
            _bookingRepository = bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));
        }

        [HttpGet]
        public async Task<IEnumerable<Guest>> Get()
        {
            return _guestRepository.GetGuests();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Guest), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(Guid id)
        {
            var guest = _guestRepository.GetGuestsById(id);

            return guest == null ? NotFound() : Ok(guest);
        }


        [HttpPost("AddGuest")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Guest> Create(GuestDto guestDto)
        {

            var entity = _userRepository.GetUserById(guestDto.UserId);
            if (entity == null)
            {
                throw new Exception("User not found");
            }

            var guest = new Guest()
            {
                GuestId = Guid.NewGuid(),
                ApartmentID = guestDto.ApartmentId,
                FirstName = guestDto.FirstName,
                LastName = guestDto.LastName,
                HostFrom = guestDto.HostFrom,
                HostTo = guestDto.HostTo,
                GuestStatus = false,
                UserId = guestDto.UserId,
            };
            _guestRepository.AddGuest(guest);

            _guestRepository.SaveChanges();

            return Ok("Stay requested");
        }
    }
       
}

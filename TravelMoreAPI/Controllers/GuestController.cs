using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;
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
            var entity = _userRepository.GetUserByApartmentID(guestDto.ApartmentId);
            if (entity == null)
            {
                return BadRequest("Apartment not found");
            }
            if(entity.UserId == guestDto.GuestId)
            {
                return BadRequest("Can't book your own Apartment");
            }
            var guest = new Guest()
            {
                BookingId = Guid.NewGuid(),
                GuestId = guestDto.GuestId,
                ApartmentID = guestDto.ApartmentId,
                FirstName = guestDto.FirstName,
                LastName = guestDto.LastName,
                City = guestDto.City,
                HostFrom = guestDto.HostFrom,
                HostTo = guestDto.HostTo,
                CurrentStatus = Entities.Helpers.GuestStatus.GuestStatusEnum.pending,
                UserId = entity.UserId,
            };
            var booking = _bookingRepository.GuestToBooking(guest);
            _bookingRepository.AddBooking(booking);
            _guestRepository.AddGuest(guest);

            _guestRepository.SaveChanges();
            _bookingRepository.SaveChanges();

            return Ok("Stay requested");
        }
    }
       
}

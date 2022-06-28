using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TravelMoreAPI.Entities;
using TravelMoreAPI.Models.Dtos;
using TravelMoreAPI.Repositories;
using TravelMoreAPI.Repositories.BookingT;
using static TravelMoreAPI.Entities.Helpers.GuestStatus;

namespace TravelMoreAPI.Controllers
{
    
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IBookingRepository _bookingRepository;

        public BookingController( IUserRepository userRepository, IBookingRepository bookingRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _bookingRepository = bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));
        }


        [AllowAnonymous]
        [HttpPost("Booking")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Booking> Create(BookingDto bookingDto)
        {
            var entity = _userRepository.GetUserByApartmentID(bookingDto.ApartmentId);
            if (entity == null)
            {
                return BadRequest("Apartment not found");
            }
            if(entity.UserId == bookingDto.GuestId)
            {
                return BadRequest("Can't book your own Apartment");
            }
            var booking = new Booking()
            {
                BookingId = Guid.NewGuid(),
                GuestId = bookingDto.GuestId,
                ApartmentId = bookingDto.ApartmentId,
                FirstName = bookingDto.FirstName,
                LastName = bookingDto.LastName,
                City = bookingDto.City,
                HostFrom = bookingDto.HostFrom,
                HostTo = bookingDto.HostTo,
                CurrentStatus = Entities.Helpers.GuestStatus.GuestStatusEnum.Pending,
                HostId = entity.UserId,
            };
            _bookingRepository.AddBooking(booking);
     
            _bookingRepository.SaveChanges();

            return Ok("Stay requested");
        }

        [HttpGet("BookingProfile/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetBookingProfileId(Guid id)
        {
            var booking = _bookingRepository.GetBookingProfile(id);

            return booking == null ? NotFound() : Ok(booking);
        }

        [HttpGet("GuestProfile/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetGuestProfileId(Guid id)
        {
            var booking = _bookingRepository.GetGuestProfile(id);

            return booking == null ? NotFound() : Ok(booking);
        }

        [HttpPost("GuestStatus/{id:guid}")]
        public IActionResult SetBookingStatus(Guid id,int i)
        {
            var booking = _bookingRepository.GetBookingById(id);
            if (booking == null) return NotFound("booking not found");
            if (i == 0 || i > 2) return BadRequest("Invalid Status Enumeration");
            booking.CurrentStatus = (GuestStatusEnum)i;
            _bookingRepository.SaveChanges();
            return Ok("Booking status changed");
        }
    }
       
}

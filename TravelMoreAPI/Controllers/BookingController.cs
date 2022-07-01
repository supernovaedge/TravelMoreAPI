using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TravelMoreAPI.Entities;
using TravelMoreAPI.Entities.Helpers;
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


        [Authorize]
        [HttpPost("Booking")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Booking> Create(BookingDto bookingDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }

            var entity = _userRepository.GetUserByApartmentID(bookingDto.ApartmentId);
            if (entity == null)
            {
                return BadRequest("Apartment not found");
            }
            if(entity.UserId == bookingDto.GuestId)
            {
                return BadRequest("Can't book your own Apartment");
            }
            if (bookingDto.HostFrom.Date < DateTime.Today)
            {
                return BadRequest("Can't book past days");
            }
            if(bookingDto.HostTo.Date < bookingDto.HostFrom)
            {
                return BadRequest("Start date Can't be after end Date");
            }
            foreach (BookingProfile bookingEntity in _bookingRepository.GetBookingProfile(bookingDto.GuestId))
            {
                if (bookingDto.HostFrom.Date <= bookingEntity.stayTo.Date && bookingEntity.stayFrom.Date <= bookingDto.HostTo.Date ) return BadRequest("Dates overlap with previous booking request");
            }

            var booking = new Booking()
            {
                BookingId = Guid.NewGuid(),
                GuestId = bookingDto.GuestId,
                ApartmentId = bookingDto.ApartmentId,
                FirstName = bookingDto.FirstName,
                LastName = bookingDto.LastName,
                City = bookingDto.City,
                HostFrom = bookingDto.HostFrom.Date,
                HostTo = bookingDto.HostTo.Date,
                CurrentStatus = (GuestStatusEnum)0,
                HostId = entity.UserId,
                GuestPicture = _userRepository.GetUserProfileById(bookingDto.GuestId).UserPicture,
            };
            
            _bookingRepository.AddBooking(booking);
     
            _bookingRepository.SaveChanges();

            return Ok("Stay requested");
        }

        [Authorize]
        [HttpGet("BookingProfile/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetBookingProfileId(Guid id)
        {
            var claimId = User.Claims.FirstOrDefault(x => x.Type == "UserId").Value;
            if (claimId != id.ToString())
            {
                return Forbid();
            }
            var booking = _bookingRepository.GetBookingProfile(id);

            return booking == null ? NotFound() : Ok(booking);
        }

        [Authorize]
        [HttpGet("GuestProfile/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetGuestProfileId(Guid id)
        {
            var claimId = User.Claims.FirstOrDefault(x => x.Type == "UserId").Value;
            if (claimId != id.ToString())
            {
                return Forbid();
            }
            var booking = _bookingRepository.GetGuestProfile(id);

            return booking == null ? NotFound() : Ok(booking);
        }

        [Authorize]
        [HttpPost("GuestStatus/{id:guid}")]
        public IActionResult SetBookingStatus(Guid id,int i)
        {
            var booking = _bookingRepository.GetBookingById(id);
            if (booking == null) return NotFound("booking not found");

            var claimId = User.Claims.FirstOrDefault(x => x.Type == "UserId").Value;
            if (claimId != booking.HostId.ToString())
            {
                return Forbid();
            }
            if (i == 0 || i > 2) return BadRequest("Invalid Status Enumeration");
            var userGuests = _bookingRepository.GetGuestProfile(Guid.Parse(claimId));

            if (i == 2)
            {
                foreach (GuestProfile bookingEntity in userGuests)
                {
                    if (booking.HostFrom.Date <= bookingEntity.stayTo.Date && bookingEntity.stayFrom.Date <= booking.HostTo.Date)
                    {
                        _bookingRepository.GetBookingById(bookingEntity.BookingId).CurrentStatus = GuestStatusEnum.NotPossible;
                    }
                }
            }
            
            booking.CurrentStatus = (GuestStatusEnum)i;
            _bookingRepository.SaveChanges();
            if(i==1) return Ok("Booking Denied");
            return Ok("Booking Accepted");
        }

        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteBooking(Guid id)
        {
            var bookingToDelete = _bookingRepository.GetBookingById(id);
            if (bookingToDelete == null) return NotFound("Booking not found");
            var claimId = User.Claims.FirstOrDefault(x => x.Type == "UserId").Value;
            if (claimId != bookingToDelete.GuestId.ToString())
            {
                return Forbid();
            }
            if(bookingToDelete.CurrentStatus == (GuestStatusEnum)2)
            {
                return BadRequest("Booking Already Accepted");
            }
            _bookingRepository.DeleteBooking(bookingToDelete);
            _bookingRepository.SaveChanges();

            return Ok("Booking canceled");
        }
    }    
}

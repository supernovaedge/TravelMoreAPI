using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TravelMoreAPI.Models.Dtos;
using TravelMoreAPI.Services.BookingService;


namespace TravelMoreAPI.Controllers
{
    
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService ?? throw new ArgumentNullException(nameof(bookingService));
        }


        [Authorize]
        [HttpPost("Booking")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult CreateBooking(BookingDto bookingDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            var booking = _bookingService.CreateBooking(bookingDto);
            return Created($"https://localhost:7043/api/Booking/CreateBooking", booking);
        }


        [Authorize]
        [HttpGet("BookingProfile/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetBookingProfileId(Guid id)
        {
            var claimId = User.Claims.FirstOrDefault(x => x.Type == "UserId")!.Value;
            if (claimId != id.ToString())
            {
                return Forbid();
            }
            var bookings = _bookingService.GetBookingProfileById(id);

            return bookings == null ? NotFound() : Ok(bookings);
        }

        [Authorize]
        [HttpGet("GuestProfile/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetGuestProfileId(Guid id)
        {
            var claimId = User.Claims.FirstOrDefault(x => x.Type == "UserId")!.Value;
            if (claimId != id.ToString())
            {
                return Forbid();
            }
            var guests = _bookingService.GetGuestProfileById(id);

            return guests == null ? NotFound() : Ok(guests);
        }

        [Authorize]
        [HttpPost("GuestStatus/{id:guid}")]
        public ActionResult SetBookingStatus(Guid id,int i)
        {
            var claimId = User.Claims.FirstOrDefault(x => x.Type == "UserId")!.Value;
            var booking = _bookingService.SetBookingStatus(id, i, Guid.Parse(claimId));
            return Ok(booking);
        }

        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteBooking(Guid id)
        {
            var claimId = User.Claims.FirstOrDefault(x => x.Type == "UserId")!.Value;
            var deletedBooking = _bookingService.DeleteBooking(id, Guid.Parse(claimId));
            return NoContent();
        }
    }    
}

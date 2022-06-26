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
    public class ApartmentController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IApartmentRepository _apartmentRepository;

        public ApartmentController(IApartmentRepository apartmentRepository, IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _apartmentRepository = apartmentRepository ?? throw new ArgumentNullException(nameof(apartmentRepository));
        }


        [HttpGet]
        public async Task<IEnumerable<Apartment>> Get()
        {
            return _apartmentRepository.GetApartments();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Apartment), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(Guid id)
        {
            var apartment = _apartmentRepository.GetApartmentById(id);

            return apartment == null ? NotFound() : Ok(apartment);
        }


        [HttpPost("AddApartment")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Apartment> Create(ApartmentDto apartmentDto)
        {
     
            var userId = apartmentDto.UserID;

            var entity = _userRepository.GetUserById(userId);
            if(entity == null)
            {
                return NotFound("User not found");
            }


            var apartment = new Apartment()
            {
                ApartmentId = new Guid(),
                City = apartmentDto.City,
                Address = apartmentDto.Address,
                BedsNumber = apartmentDto.BedsNumber,
                DistanceToCenter = apartmentDto.DistanceToCenter,
                ApartmentPicture = new ImageBase64 {Picture = apartmentDto.ApartmentPictureBase64, Header = apartmentDto.ApartmentPictureHeader},
                ApartmentDescription = apartmentDto.ApartmentDescription,
                ApartmentCoordinates = apartmentDto.ApartmentCoordinates,
            };
            _apartmentRepository.AddApartment(apartment);

            entity.ApartmentId = apartment.ApartmentId;

            _userRepository.SaveChanges();

            return Ok(apartment);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(Guid id)
        {
            var entity = _userRepository.GetUserById(id);
            if (entity == null)
            {
                return NotFound("User not found");
            }
            
            if(entity.Apartment == null)
            {
                return NotFound("User has no apartment");
            }
            
            _apartmentRepository.DeleteApartment(entity.Apartment);
            entity.ApartmentId = null;

            return Ok("Apartment removed");
        }
    }
}
